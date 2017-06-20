using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instakill : MonoBehaviour {
    private GameObject playerManager;
    private GameObject powerUpManager;
    public GameObject bulletPrefab;

    void Awake()
    {
        playerManager = GameObject.Find("PlayerManager");
        powerUpManager = GameObject.Find("PowerUpManager");
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            bulletPrefab.GetComponent<Bullet>().instakill = true;
            powerUpManager.GetComponent<PowerUpManager>().StartCoroutine("Reset");
            powerUpManager.GetComponent<PowerUpManager>().StartCoroutine("PowerUpTimer");
            Destroy(gameObject);
        }
    }


}