using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	public PipeController pipeController;
	public MyBird bird;
	private BackgroundController[] backgrounds;

	// Use this for initialization
	void Start () {
		backgrounds = FindObjectsOfType<BackgroundController>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void BirdDie(){
		bird.Die();
		pipeController.StopScrolling();
		foreach(BackgroundController background in backgrounds){
			background.StopScrolling();
		}
	}
}
