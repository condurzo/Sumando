using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TopScore : MonoBehaviour {

	private Text topScore;

	void Start () {
		topScore = GetComponent<Text> ();
		GameData.onScoresChanged.AddListener (OnValueChanged);
		OnValueChanged ();
	}
	
	void OnValueChanged () {
		topScore.text = GameData.TopScore.ToString ();
	}
}
