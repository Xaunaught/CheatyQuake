using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
    public float speed = 20.0f;
    public float life = 5.0f;

    void Start()
    {
        Invoke("Kill", life);
        GetComponent<Rigidbody>().velocity = transform.forward * speed;
    }
    void Update()
    {
        //transform.position += transform.forward * speed * Time.deltaTime;
        
    }
    void OnTriggerEnter(Collider col)
    {
        var hit = col.gameObject;
        var health = hit.GetComponent<Health>();
        if (health  != null)
        {
            health.TakeDamage(10);
        }
        Kill();
    }
    void Kill()
    {
        Destroy(gameObject);
    }
}