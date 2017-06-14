using UnityEngine;
using System.Collections;

public class Billboard : MonoBehaviour {
    public GameObject playerCamera;
    void Update () {
		transform.LookAt(playerCamera.GetComponent<Camera>().transform);
        
	}
}