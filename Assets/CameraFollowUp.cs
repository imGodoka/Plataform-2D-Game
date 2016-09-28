using UnityEngine;
using System.Collections;

public class CameraFollowUp : MonoBehaviour {

	float dampTime = 0.15f;
	Vector3 velocity = Vector3.zero;
	public Transform target;
	public Camera cam;


	void Update(){
		if (target) {
			Vector3 point = cam.WorldToViewportPoint (target.position);
			Vector3 delta = target.position - cam.ViewportToWorldPoint (new Vector3 (0.5f, 0.5f, point.z));
			Vector3 destination = transform.position + delta;

			transform.position = Vector3.SmoothDamp (transform.position, destination, ref velocity, dampTime);
		}
	}


}