﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockPosition : MonoBehaviour {

	private Vector3 startPos;

	void Start () {
		startPos = transform.position;
	}
	
	void Update () {
		transform.position = startPos;
	}
}
