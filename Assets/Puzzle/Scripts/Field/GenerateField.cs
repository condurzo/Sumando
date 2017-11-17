using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GenerateField {

	FieldType currentField;

	private int cellCount;

	private int sizeW = 34;
	private int sizeH = 30;

	private int width;
	private int height;

	public Vector3 CellPosition (int i, int j) {
		
		Vector3 cellPos;
		FieldType curField = GameManager.instance.currentField;
		cellPos = curField.startPosition + new Vector3 (i * sizeW, j * sizeH);
		if (j % 2 == 0) {
			cellPos.x += sizeW / 2;
		}
		return cellPos;
	}

	public Vector3 NextCellPosition (int i, int j){
		
		Vector3 nextCellPos;
		FieldType curField = GameManager.instance.currentField;
		nextCellPos = curField.nextCellStartPosition + new Vector3 (i * sizeW / 1.3f, j * sizeH / 1.3f);
		return nextCellPos;
	}


	public ButtonController [,] SetUpField () {

		currentField = GameManager.instance.currentField;
		int[,] numbers = Parse ();

	 	width = numbers.GetLength (0);
		height = numbers.GetLength (1);

		ButtonController [,] backField = new ButtonController[width, height];
		for (int i = 0; i < width; i++) {
			for (int j = 0; j < height; j++) {
				if (numbers [i, j] != 0) {
					GameObject obj = Pool.field.Dequeue ();
					backField [i, j] = obj.GetComponent<ButtonController> ();
					backField [i, j].i = i;
					backField [i, j].j = j;
					backField [i, j].gameObject.transform.localScale = Vector3.one;
					backField [i, j].gameObject.GetComponent<RectTransform> ().anchoredPosition3D = CellPosition (i, j);
					backField [i, j].gameObject.SetActive (true);
					GameController.instance.fieldCells++;
				} else {
					backField [i, j] = null;
				}
			}
		}
//		SetUpTile (backField);
		return backField;
	}

//	public void SetUpTile (ButtonController [,] field) {
//
//		Vector3 startPosition = CellPosition(0, 0);

//		int tWidth = Pool.TilesWidth;
//		int tHeight  =  Pool.TilesHeight;

//		GameObject[,] tiles = new GameObject[tWidth, tHeight];
//		GameObject [] tilesQueue = Pool.tiles.ToArray ();

//		int delta = -4;
//		int q = 0;
//
//		for (int i = 0; i < tWidth - 1; i++) {
//			for (int j = 0; j < tHeight - 1; j++) {
//
//				if (q < tilesQueue.Length) {
//					tiles [i, j] = tilesQueue[q];
//
//					Vector3 pos = startPosition + new Vector3 ((i+delta) * sizeW, (j+ delta) * sizeH);
//					if (i % 2 != 0) {
//						pos.y += sizeH / 2;
//					}
//
//					tiles [i, j].GetComponent<RectTransform> ().anchoredPosition3D = pos;
//					tiles [i, j].transform.localScale = Vector3.one;
//					tiles [i, j].SetActive (true);
//					q++;
//				}
//			}
//		}
//	}

	public int [,] Parse () {
		char[] lineEndings = new char[] { '\n', '\r'};
		string [] lines = currentField.field.text.Split(lineEndings, System.StringSplitOptions.RemoveEmptyEntries);
		int [,] numbers = new int [lines.Length, lines[0].Length];
		for (int i = 0; i < lines.Length; i++) {
			for (int j = 0; j < lines [i].Length; j++) {
				numbers [i, j] = int.Parse (lines [i] [j].ToString());
			}
		}
		return numbers;
	}
}
