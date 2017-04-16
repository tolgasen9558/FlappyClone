﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyBird : MonoBehaviour {

	public float jumpSpeed = 4.0f;
	private Rigidbody2D rb2d;

	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Space)){
			Jump();
		}
	}

	private void Jump(){
		rb2d.velocity = new Vector2(rb2d.velocity.x, jumpSpeed);
	}
}
