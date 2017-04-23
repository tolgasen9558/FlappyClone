using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyBird : MonoBehaviour {

	public float jumpSpeed = 4.0f;

	private Rigidbody2D rb2d;
	private GameController gameController;

	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D>();
		gameController = FindObjectOfType<GameController>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Space)){
			Jump();
		}
	}

	private void Jump(){
		rb2d.velocity = new Vector2(0, jumpSpeed);
	}

	public void Die(){
		rb2d.velocity = Vector2.zero;
	}

	public void OnTriggerEnter2D(Collider2D other){
		print(other.gameObject.tag);
		if(other.gameObject.CompareTag("Pipe")){
			gameController.BirdDie();
		}
	}
}
