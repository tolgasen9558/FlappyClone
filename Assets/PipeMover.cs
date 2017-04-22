﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMover : MonoBehaviour {


	private float moveSpeed;
	private Rigidbody2D rb2d;

	// Use this for initialization
	void Start () {
		moveSpeed = FindObjectOfType<BackgroundController>().scrollSpeed;
		rb2d = GetComponent<Rigidbody2D>();
		rb2d.velocity = new Vector2(-moveSpeed, 0);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
