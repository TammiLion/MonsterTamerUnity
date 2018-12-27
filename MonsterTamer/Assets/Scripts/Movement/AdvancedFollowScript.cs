using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdvancedFollowScript : MonoBehaviour {

		public GameObject objectToFollow;
		public float cameraSpeed = 2.0f;
		public int distanceToFollow = 2;
		public bool shouldFlipSprite = false;

		private SpriteRenderer spriteRenderer;
		private Animator animator;
	private Rigidbody2D body;

		void Start() {
			if (shouldFlipSprite) {
				spriteRenderer = gameObject.GetComponent<SpriteRenderer> ();
				animator = gameObject.GetComponent<Animator> ();
				body = gameObject.GetComponent<Rigidbody2D> ();
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
				
			flipIfNeeded (x, currentPosition.x);

		}
		Debug.Log ("speed set: " + body.velocity.x);
		animator.SetFloat ("speed", body.velocity.x);
		}

	private void flipIfNeeded(float oldX, float newX) {
		if (shouldFlipSprite) {
			if (newX > oldX) {
				spriteRenderer.flipX = true;
			} else if (newX < oldX) {
				spriteRenderer.flipX = false;
			}
		}
	}
}
