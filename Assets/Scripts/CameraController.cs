using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    public GameObject player; // reference to the player object

    private Vector3 offset; // hold the offset value for the camera

	// Use this for initialization
	void Start () {
        offset = transform.position - player.transform.position;
	}
	
	// Update is called once per frame - after all items have been processed in normal "Update"
	void LateUpdate () {
        transform.position = player.transform.position + offset;
	}
}
