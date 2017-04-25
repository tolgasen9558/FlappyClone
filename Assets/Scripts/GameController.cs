using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	public PipeController pipeController;
	public MyBird bird;

	[SerializeField]
	public Text scoreText;
	[SerializeField]
	public Text gameOverText;

	private int score = 0;
	private BackgroundController[] backgrounds;

	// Use this for initialization
	void Start () {
		backgrounds = FindObjectsOfType<BackgroundController>();
		updateScoreText();
		gameOverText.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(bird.isDead){
			if(Input.GetMouseButton(0) || Input.GetKey(KeyCode.Space)){
				SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
			}
		}
	}

	public void BirdDie(){
		bird.Die();
		pipeController.StopScrolling();
		foreach(BackgroundController background in backgrounds){
			background.StopScrolling();
		}
		gameOverText.enabled = true;
	}

	public void Score(){
		score++;
		updateScoreText();
	}

	private void updateScoreText(){
		scoreText.text = "Score : " + score;
	}
}
