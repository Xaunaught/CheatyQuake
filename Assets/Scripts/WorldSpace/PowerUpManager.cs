using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour {
    public GameObject playerManager;
    

    public int powerUpTimer;
    public int respawnTimer;
    public GameObject[] powerUps;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public IEnumerator Reset()
    {

        yield return new WaitForSeconds(powerUpTimer);
        List<GameObject> players = playerManager.GetComponent<PlayerManager>().players;
        for (int i = 0; i < players.Count; i++)
        {
            players[i].GetComponent<PlayerController>().walkSpeed = players[i].GetComponent<PlayerController>().defaultWalkSpeed;
        }
    }
    public IEnumerator PowerUpTimer()
    {
        yield return new WaitForSeconds(respawnTimer);
        SpawnPowerUp();
    }

    void SpawnPowerUp()
    {
        Instantiate(powerUps[Random.Range(0, powerUps.Length)]);
        
    }
}
