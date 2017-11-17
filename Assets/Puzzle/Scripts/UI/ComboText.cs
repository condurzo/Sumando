using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComboText : MonoBehaviour {

	public Sprite [] sprites;
	public Image textImage;
	public UITweenRectPosition tweenPosition;

	private Image image;

	void OnEnable () {
		textImage.sprite = sprites [Random.Range (0, sprites.Length)];
		tweenPosition.OnFinished = null;
		tweenPosition.OnFinished += StopAnim;
	}

	void StopAnim () {
		tweenPosition.OnFinished -= StopAnim;

		this.gameObject.SetActive (false);
	}
}
