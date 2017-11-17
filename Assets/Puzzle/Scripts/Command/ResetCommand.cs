using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetCommand : Command {

	public override void Execute ()
	{
		GameController.instance.ResetCells();
	}
}
