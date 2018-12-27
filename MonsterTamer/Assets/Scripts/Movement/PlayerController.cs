using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public const float WALKING_MOVE_SPEED = 1.5f;
	public const float RUNNING_MOVE_SPEED = 3.5f;


	void Update()
	{
		updateMovement ();
	}

	private void updateMovement() {
		transform.Translate(getHorizontalMovement(), 0, 0);
	}

	private float getHorizontalMovement() {
		return Input.GetAxis("Horizontal") * Time.deltaTime * getMovementSpeed();
	}

	private float getMovementSpeed() {
		bool running = Input.GetKey (KeyCode.X);
		if (running) {
			return RUNNING_MOVE_SPEED;
		} else {
			return WALKING_MOVE_SPEED;
		}
	}
}