using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
    public float speed = 20.0f;
    public float life = 5.0f;
    public float radius = 2;
    public float explosionPower = 5;
    public int damage = 10;
    public GameObject explosionParticle;
    public bool instakill = false;
    public bool noDamage = false;

    void Start()
    {
        Invoke("Kill", life);
        GetComponent<Rigidbody>().velocity = transform.forward * speed;
    }
    void Update()
    {
        //transform.position += transform.forward * speed * Time.deltaTime;
        
    }
    void OnCollisionEnter(Collision col)
    {
        ContactPoint contact = col.contacts[0];
        //Quaternion rotation = Quaternion.FromToRotation(Vector3.up, contact.normal);
        Vector3 position = contact.point;
        ExplosionDamage(position, radius);
        Instantiate(explosionParticle, transform.position, transform.rotation);
        Kill();
    }

    void ExplosionDamage(Vector3 explosionPosition, float radius)
    {
        //gets array of everything in an explosion
        Collider[] hitColliders = Physics.OverlapSphere(explosionPosition, radius);
        for (int i = 0; i < hitColliders.Length; i++)
        {
            //print("checking for players");
            if (hitColliders[i].tag == "Player")
            {
                print("hit a player");
                Vector3 direction = hitColliders[i].transform.position - explosionPosition;
                float force = Mathf.Clamp(explosionPower / 3, 0, 100000);
                hitColliders[i].GetComponent<ImpactReceiver>().AddImpact(direction, force);
                if(instakill == true)
                {
                    hitColliders[i].GetComponent<Health>().TakeDamage(999);
                }
                if(noDamage == true)
                {
                    hitColliders[i].GetComponent<Health>().TakeDamage(0);
                }
                else
                {
                    hitColliders[i].GetComponent<Health>().TakeDamage(damage);
                }
                
            }
        }
    }

    void Kill()
    {
        Destroy(gameObject);
    }
}