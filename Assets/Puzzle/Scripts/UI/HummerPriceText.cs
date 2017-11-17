using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HummerPriceText : MonoBehaviour {

	private Text price;

	void OnEnable () {
		price = GetComponent<Text> ();
		price.text = GameData.HummerPrice.ToString () + "  ?";
	}
}
