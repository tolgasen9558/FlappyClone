using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	public PipeController pipeController;
	public MyBird bird;
	public GameObject panel;
	public Animation flashAnimation;

	public Text scoreText;
	public Text gameOverText;

	private bool inputEnabled = true;
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
		if(bird.isDead && inputEnabled){
			if(Input.GetMouseButton(0) || Input.GetKey(KeyCode.Space)){
				SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
			}
		}
	}

	public void BirdDie(){
		inputEnabled = false;
		if(bird.isDead == true){
			return;
		}
		bird.Die();
		pipeController.StopScrolling();
		foreach(BackgroundController background in backgrounds){
			background.StopScrolling();
		}
		panel.GetComponent<Animator>().SetTrigger("flash_trigger");
		Invoke("SetGameOverVisible", 2f);
	}

	private void SetGameOverVisible(){
		gameOverText.enabled = true;
		inputEnabled = true;
	}

	public void Score(){
		score++;
		updateScoreText();
	}

	private void updateScoreText(){
		scoreText.text = "Score : " + score;
	}
}
