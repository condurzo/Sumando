using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveProgress : Command {

	public List<CellProperties> cells = new List<CellProperties> ();
	public List<int> nextCells = new List<int> ();

	public int score;
	public int topScore;

	public int undoLevel;
	public int hummerLevel;

	public override void Execute () {
		;
	}
}
