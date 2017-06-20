using UnityEngine;
using UnityEngine.Networking;

public class PlayerController : NetworkBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public GameObject playerCamera;
    private CharacterController controller;

    public float rotationSpeed = 2.0f;
    public float defaultWalkSpeed = 10.0f;
    public float walkSpeed;
    public Transform head;

    public float maxHeadRotation = 80.0f;
    public float minHeadRotation = -80.0f;
    private float currentHeadRotation = 0;

    public float reloadTime = 0.5f;
    public float defaultReloadTime = 0.5f;
    private float lastTimeFired;

    private float yVelocity = 0;
    public float jumpSpeed;
    public float defaultJump = 15f;
    public float gravity = 30.0f;

    private Vector3 moveVelocity = Vector3.zero;
    Vector3 jumpVelocity;


    void Start()
    {
        controller = GetComponent<CharacterController>();
        walkSpeed = defaultWalkSpeed;
        jumpSpeed = defaultJump;
    }

    void Update()
    {
        if (!isLocalPlayer)
        {
            return;
        }
        if (Input.GetButtonDown("Fire1") && Time.time > lastTimeFired + reloadTime)
        {
            CmdFire();
        }
        if (controller.isGrounded)
        {
            yVelocity = -1;



            if (Input.GetButtonDown("Jump"))
            {
                yVelocity = jumpSpeed;
                jumpVelocity = controller.velocity / 1.5f;
            }
        }

        if (!controller.isGrounded)
        {
            moveVelocity = transform.TransformDirection(new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"))) * (walkSpeed / 2);
            moveVelocity += jumpVelocity;
        }
        else
            moveVelocity = transform.TransformDirection(new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"))) * walkSpeed;

        //Vector3 velocity = moveVelocity + yVelocity * Vector3.up;
        Vector2 mouseInput = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        yVelocity -= gravity * Time.deltaTime;

        moveVelocity.y = yVelocity;
        controller.Move(moveVelocity * Time.deltaTime);


        transform.Rotate(Vector3.up, mouseInput.x * rotationSpeed);
        currentHeadRotation = Mathf.Clamp(currentHeadRotation + mouseInput.y * rotationSpeed, minHeadRotation, maxHeadRotation);
        head.localRotation = Quaternion.identity;
        head.Rotate(Vector3.left, currentHeadRotation);



    }
    [Command]
    void CmdFire()
    {
        // Create the Bullet from the Bullet Prefab
        var bullet = Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);

        // Add velocity to the bullet
        //bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 6;

        // Spawn the bullet on the Clients
        NetworkServer.Spawn(bullet);

        lastTimeFired = Time.time;

        // Destroy the bullet after 2 seconds
        //Destroy(bullet, 2.0f);        
    }

    public override void OnStartLocalPlayer()
    {
        GetComponent<MeshRenderer>().material.color = Color.blue;
        print(GetComponentInChildren<Camera>());
        playerCamera.SetActive(true);
        //playerCamera.GetComponent<AudioListener>().enabled = true;
    }

}