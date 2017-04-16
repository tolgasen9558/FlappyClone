using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour {

	private float scrollSpeed = 10.0f;
	private float backgroundWidth;
	private float cameraWidth;
	private Rigidbody2D rb2d;

	void Start(){
		rb2d = GetComponent<Rigidbody2D>();
		rb2d.velocity = new Vector2(-scrollSpeed, 0);
		backgroundWidth = GetComponentInChildren<SpriteRenderer>().sprite.bounds.size.x;
		cameraWidth = Camera.main.orthographicSize * 2f * Camera.main.aspect;
		print(backgroundWidth.ToString());
	}
	
	// Update is called once per frame
	void Update () {
		if(transform.position.x < -backgroundWidth){
			Reposition();
		}
	}

	void Reposition(){
		print("background.transform.x = " + transform.position.x.ToString() + " BEFORE");
		transform.position += new Vector3(backgroundWidth * 2f, 0, 0);
		print("background.transform.x = " + transform.position.x.ToString() + " AFTER");
	}
}
