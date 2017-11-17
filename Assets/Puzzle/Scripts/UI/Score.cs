using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Score : MonoBehaviour {

	private Text score;

	void Start () {
		GameData.onScoresChanged.AddListener (OnScoresChanged);
	}
	
	void OnScoresChanged () {
        if (score == null)
        {
            score = GetComponent<Text>();
        }
        score.text = GameData.Score.ToString ();
	}

	void OnEnable() {
		OnScoresChanged ();
	}
}
