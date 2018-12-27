using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {

	public GameObject objectToFollow;
	public float cameraSpeed = 2.0f;

	public float shakeAmount = 0.1f;
	public Vector3 originalPosition;

	void Start() {
		originalPosition = transform.localPosition;
	}

	// Update is called once per frame
	void LateUpdate () {
		if (shouldResetScreenShake ()) {
			transform.localPosition = originalPosition;
		} else if (shouldScreenShake()) {
			transform.localPosition = originalPosition + Random.insideUnitSphere * shakeAmount;
		} else {
			follow ();
			originalPosition = transform.localPosition;
		}
	}

	private void follow() {
		Vector3 currentPosition = transform.position;
		Vector3 playerPosition = objectToFollow.transform.position;

		if (Mathf.Abs (currentPosition.x - playerPosition.x) > 3) {
			float step = cameraSpeed * Time.deltaTime;
			float x = Vector3.MoveTowards (transform.position, playerPosition, step).x;
			transform.position = new Vector3 (x, currentPosition.y, currentPosition.z);
		}
	}

	private bool shouldScreenShake() {
		return Input.GetKey (KeyCode.C);
	}

	private bool shouldResetScreenShake() {
		return Input.GetKeyUp (KeyCode.C);
	}
}
