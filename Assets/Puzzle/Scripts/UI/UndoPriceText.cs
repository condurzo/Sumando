using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UndoPriceText : MonoBehaviour {

	private Text price;

	void OnEnable () {
		price = GetComponent<Text> ();
		price.text = GameData.UndoPrice.ToString () + "  ?";
	}
}
