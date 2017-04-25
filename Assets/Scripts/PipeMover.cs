using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMover : MonoBehaviour {


	private float moveSpeed;
	private Rigidbody2D rb2d;
	private GameController gameController;

	// Use this for initialization
	void Start () {
		moveSpeed = FindObjectOfType<BackgroundController>().scrollSpeed;
		gameController = FindObjectOfType<GameController>();

		rb2d = GetComponent<Rigidbody2D>();
		StartScrolling();
	}
	
	public void StopScrolling(){
		rb2d.velocity = Vector2.zero;
	}

	public void StartScrolling(){
		rb2d.velocity = new Vector2(-moveSpeed, 0);
	}

	void OnTriggerEnter2D(Collider2D other){
		MyBird bird = other.GetComponent<MyBird>();
		if(bird != null){
			if(!bird.isDead)
			gameController.Score();
		}
	}
}
