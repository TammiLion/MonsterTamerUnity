using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AssemblyCSharp;

abstract class BaseInteractable<T> : MonoBehaviour {

	protected TextBubble textBubble;

	void Awake() {
		GameObject bubble = transform.parent.Find ("Bubble").gameObject;
		textBubble = bubble.GetComponent<TextBubble> ();
		onAwake ();
	}

	protected virtual void onAwake () {
		//optional
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == Tags.PLAYER) {
			playerEntered (other);
		}
	}

	public virtual void playerEntered (Collider2D player) {
	}

	void OnTriggerExit2D(Collider2D other) {
		if (other.tag == Tags.PLAYER) {
			playerExited (other);
		}
	}

	public abstract void playerExited (Collider2D player);

	public abstract void interact (T interactor);

	public virtual string getOnTriggerExitMessage() {
		return "";
	}
}
