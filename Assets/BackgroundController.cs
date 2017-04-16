using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour {

	public float scrollSpeed = 2.0f;

	private float backgroundWidth;
	private float cameraWidth;

	void Start(){
		backgroundWidth = GetComponentInChildren<SpriteRenderer>().sprite.bounds.size.x;
		cameraWidth = Camera.main.orthographicSize * 2f * Camera.main.aspect;
	}
	
	// Update is called once per frame
	void Update () {
		if(transform.position.x + backgroundWidth / 2f <= -cameraWidth / 2f){
			Reposition();
			return;
		}
		transform.Translate(new Vector3(-scrollSpeed * Time.deltaTime, 0, 0));
	}

	void Reposition(){
		transform.Translate(new Vector3(backgroundWidth*2, 0, 0));
	}
}
