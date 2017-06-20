using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RapidFire : MonoBehaviour {
    private GameObject playerManager;
    private GameObject powerUpManager;

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
            List<GameObject> players = playerManager.GetComponent<PlayerManager>().players;
            print("Player count at the time of pickup " + players.Count);
            for (int i = 0; i < players.Count; i++)
            {
                players[i].GetComponent<PlayerController>().reloadTime = 0.1f; ;
            }
            powerUpManager.GetComponent<PowerUpManager>().StartCoroutine("Reset");
            powerUpManager.GetComponent<PowerUpManager>().StartCoroutine("PowerUpTimer");
            Destroy(gameObject);
        }
    }
}