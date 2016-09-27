using UnityEngine;
using System.Collections;

public class CameraFollowUp : MonoBehaviour {

	public Camera cam;
	public GameObject player;

	Vector3 initpos;

	// Use this for initialization
	void Start () {
		initpos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {

		cam.transform.position = new Vector3 (player.transform.position.x, 
			cam.transform.position.y, 
			cam.transform.position.z);
	
	}
}
