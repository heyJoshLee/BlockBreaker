﻿using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {

	float mousePosInBlocks;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	Vector3 paddlePos = new Vector3 (0.5f, this.transform.position.y, 0f);
	mousePosInBlocks = (Input.mousePosition.x / Screen.width * 16 - 7);
	print (mousePosInBlocks);
	paddlePos.x = Mathf.Clamp(mousePosInBlocks, -8f, 7f);
	this.transform.position = paddlePos;
	}
}
