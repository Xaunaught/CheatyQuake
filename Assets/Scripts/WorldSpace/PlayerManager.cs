using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {
    public List<GameObject> players;
    public GameObject powerUp;

    // Use this for initialization
    void Awake () {

    }
	
	// Update is called once per frame
	void Update () {
        GameObject[] temp = GameObject.FindGameObjectsWithTag("Player");
        players.Clear();
        for (int i = 0; i < temp.Length; i++)
        {
            players.Add(temp[i]);
            print(players.Count);
        }
    }
    
}
