using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pool : MonoBehaviour {

	public GameObject cell;
	public GameObject ground;	
	public GameObject tile;
	public RectTransform fielHolder;
	public RectTransform cellsHolder;
//	public RectTransform tilesHolder;

	public int maxW, maxH;

	[HideInInspector]public static Queue<GameObject> field = new Queue<GameObject>();
	[HideInInspector]public static Queue<GameObject> cells = new Queue<GameObject>();
//	[HideInInspector]public static Queue<GameObject> tiles = new Queue<GameObject>();


	private int poolCount
	{
		get
		{
			return GameConfig.maxWidth * GameConfig.maxHeight;
		}
	}

//	public static int TilesWidth {
//		get {
//			return (int) (GameConfig.maxWidth * 2f);
//		}
//	}
//
//	public static int TilesHeight {
//		get { 
//			return (int) (GameConfig.maxHeight * 2f);
//		}
//	}

	private int CellsPool
	{
		get 
		{
			if (CellsPool <= 0)
				CreateMoreCells ();
			return cells.Count;
		}
	}

//	private int tilesPool {
//		get {
//			if (tilesPool <= 0)
//				CreateMoreTiles ();
//			return tiles.Count;
//		}
//	}

	void Awake () {
		CreatePool ();
	}

	void CreateMoreCells () {
		cells = Generate (cell, cellsHolder, poolCount);
	}

//	void CreateMoreTiles () {
//		tiles = Generate (tile, tilesHolder, poolCount);
//	}

	void CreatePool () {
		field = Generate (ground, fielHolder, poolCount);
		cells = Generate (cell, cellsHolder, poolCount);
//		tiles = Generate (tile, tilesHolder, TilesWidth * TilesHeight);
	}

	Queue<GameObject> Generate (GameObject obj, RectTransform holder, int count) {
		
		Queue<GameObject> queue = new Queue<GameObject>();

		for (int i = 0; i < count; i++) {
			GameObject objectToSpawn = Instantiate (obj, holder.position, Quaternion.identity) as GameObject;
			objectToSpawn.transform.SetParent (holder, false);
			objectToSpawn.SetActive (false);
			objectToSpawn.transform.rotation = Quaternion.Euler(0f,0f, -90f);
			queue.Enqueue (objectToSpawn);
//			float Color1 = Random.Range (0, 2);
//			float Color2 = Random.Range (0, 2);
//			float Color3 = Random.Range (0, 2);
//			Color color = new Color(Color1, Color2,Color3, 1F);
			int Color1 = Random.Range (45, 145);
			int Color2 = Random.Range (45, 145);
			int Color3 = Random.Range (45, 145);

			Color myColor = new Color32((byte)Color1, (byte)Color2, (byte)Color3, 255);


			obj.GetComponent<Image> ().color = myColor;
//			obj.GetComponent<Image> ().color = Color2;
//			obj.GetComponent<Image> ().color = Color3;

		}
		return queue;
	}
}
