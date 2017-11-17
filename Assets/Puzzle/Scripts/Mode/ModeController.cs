using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModeController : MonoBehaviour {

	public class Count
	{
		public int minimum;             
		public int maximum;            

		public Count (int min, int max)
		{
			minimum = min;
			maximum = max;
		}
	}

	public Field fields;
	[HideInInspector] public static List<FieldType> currentModefields = new List<FieldType>();

    private void Start()
    {
	    foreach (FieldType types in fields.fields) {
			currentModefields.Add (types);
	    }
    }

	public static void GetCurrentShape (Shape shape) {
		foreach (FieldType types in currentModefields) {
			if (types.shape == shape)
			{
				GameManager.instance.countToClear = types.cellsToSpawn;
				GameManager.instance.countToSpawn = types.cellsToSpawn;
				GameManager.instance.SetUpField (types);
				break;
			}
		}
	}
}
