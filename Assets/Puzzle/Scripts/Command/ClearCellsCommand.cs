using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCellsCommand : Command {

	public override void Execute ()
	{
		GameController.instance.ClearCell (GameManager.instance.countToClear);
	}
}
