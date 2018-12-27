using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract class BaseInteractor<T> : MonoBehaviour {

	protected T currentlyInteractable;
	protected TextBubble textBubble;

	public virtual KeyCode getInteractKey () {
		return KeyCode.Z;
	}

	void Awake() {
		GameObject bubble = transform.Find ("Bubble").gameObject;
		textBubble = bubble.GetComponent<TextBubble> ();
		onAwake ();
	}

	protected virtual void onAwake () {
		//optional
	}

	void Update() {
		if (currentlyInteractable != null && isInteracting()) {
			onInteract ();
		}
	}

	public virtual bool isInteracting() {
		return Input.GetKey (getInteractKey());
	}

	protected abstract void onInteract ();

	void OnTriggerEnter2D(Collider2D other) {
		T interactable = other.GetComponent<T> ();
		if (interactable != null) {
			currentlyInteractable = interactable;
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		T interactable = other.GetComponent<T> ();
		if (currentlyInteractable != null && currentlyInteractable.Equals(interactable)) {
			onExitingInteractable (interactable);
			currentlyInteractable = default(T);
		}
	}

	protected virtual void onExitingInteractable (T interactable) {
		//optional
	}
}
