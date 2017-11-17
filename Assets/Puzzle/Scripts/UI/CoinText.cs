using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinText : MonoBehaviour {

	public UITweenPosition positionTween;
	public Text coinsText;
	public Image coin;

	void OnEnable () {

//		GameController.instance.CoinsUpAnim (coinsText, coin);
		coinsText.text = "+ " + GameData.CoinsUp.ToString ();

		positionTween.autoClearCallbacks = false;
		positionTween.OnFinished = null;
		positionTween.OnFinished += CoinUpFinished;
	}

	void CoinUpFinished () {
		positionTween.Stop ();
		positionTween.OnFinished -= CoinUpFinished;
		gameObject.SetActive (false);
	}
}
