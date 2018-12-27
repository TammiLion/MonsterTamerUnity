using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextBubble : MonoBehaviour {

	public const float DISSAPEAR_TIME_PER_CHAR = 0.1f;

	private GameObject bubble;
	private TextMesh textMesh;
	private MeshRenderer meshRenderer;
	private float dissapearTime = 0;
	private float time = 0;

	void Awake() {
		textMesh = gameObject.GetComponent<TextMesh> ();
		meshRenderer = gameObject.GetComponent<MeshRenderer> ();
	}

	void Update() {
		if (meshRenderer.enabled) {
			time += Time.deltaTime;
			if (time > dissapearTime) {
				hide ();
			}
		}
	}

	public void show(string text) {
		if (text != null && text.Length > 0) {
			meshRenderer.enabled = true;
			dissapearTime = DISSAPEAR_TIME_PER_CHAR * text.Length;
			textMesh.text = text;
		}
	}

	public void hide() {
		textMesh.text = "";
		meshRenderer.enabled = false;
		time = 0;
		dissapearTime = 0;
	}
}
