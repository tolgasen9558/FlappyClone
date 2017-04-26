using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyBird : MonoBehaviour {

	public float jumpSpeed = 4.0f;
	public bool isDead = false;

	private Rigidbody2D rb2d;
	private GameController gameController;
	private float defaultGravityScale;
	private bool flag = false;


	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D>();
		gameController = FindObjectOfType<GameController>();
		defaultGravityScale = rb2d.gravityScale;
		rb2d.gravityScale = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) && isDead == false){
			if(flag == false){
				rb2d.gravityScale = defaultGravityScale;
				
			}
			flag = true;
			Jump();
		}
	}

	private void Jump(){
		rb2d.velocity = new Vector2(0, jumpSpeed);
	}

	public void Die(){
		isDead = true;
		rb2d.velocity = Vector2.zero;
	}

	public void OnCollisionEnter2D(Collision2D collision){
		gameController.BirdDie();
	}
}
