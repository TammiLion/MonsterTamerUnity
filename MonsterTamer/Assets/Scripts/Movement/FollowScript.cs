using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowScript : MonoBehaviour {

	public GameObject objectToFollow;
	public float cameraSpeed = 2.0f;
	public int distanceToFollow = 2;
	public bool shouldFlipSprite = false;

	private SpriteRenderer spriteRenderer;

	void Start() {
		if (shouldFlipSprite) {
			spriteRenderer = gameObject.GetComponent<SpriteRenderer> ();
		}
	}

	// Update is called once per frame
	void Update () {
		follow ();
	}

	private void follow() {
		Vector3 currentPosition = transform.position;
		Vector3 playerPosition = objectToFollow.transform.position;

		if (Mathf.Abs (currentPosition.x - playerPosition.x) > distanceToFollow) {
			float step = cameraSpeed * Time.deltaTime;
			float x = Vector3.MoveTowards (transform.position, playerPosition, step).x;
			transform.position = new Vector3 (x, currentPosition.y, currentPosition.z);

			if (shouldFlipSprite) {
				if (x > currentPosition.x) {
					spriteRenderer.flipX = false;
				} else if (x < currentPosition.x) {
					spriteRenderer.flipX = true;
				}
			}
		}
	}
}
