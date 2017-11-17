using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ModePriceText : MonoBehaviour {

//    public Size size = Size.EXTRA;

	private Text price;

	void OnEnable () {
		price = GetComponent<Text> ();
		Debug.Log (_price.ToString ());
		price.text = _price.ToString () + "  ?";
	}

    int _price
    {
        get
        {
            int value = 0;
//            switch (size)
//            {
//                case Size.BIG:
//                    value = GameConfig.openBigSizeModePrice;
//                    break;
//                case Size.EXTRA:
//                    value = GameConfig.openXTraModePrice;
//                    break;
//            }
            return value;
        }
    }
}
