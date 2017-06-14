using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour {
    public GameObject playerManager;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public IEnumerator Reset()
    {
        
        yield return new WaitForSeconds(2);
        List<GameObject> players = playerManager.GetComponent<PlayerManager>().players;
        for (int i = 0; i < players.Count; i++)
        {
            players[i].GetComponent<PlayerController>().walkSpeed = players[i].GetComponent<PlayerController>().walkSpeed / 2;
        }
    }
}
