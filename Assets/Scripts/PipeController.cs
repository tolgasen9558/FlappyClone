using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeController : MonoBehaviour {

	public GameObject pipesPrefab;

	private List<GameObject> pipePairsArray;
	private float pipeWidth;
	private float cameraWidth;
	private int rightmostColumnIndex;
	private float distanceInbetween = 10f;
	private int numberOfPipes;


	// Use this for initialization
	void Start () {
		pipeWidth = pipesPrefab.GetComponentInChildren<SpriteRenderer>().sprite.bounds.size.x;
		cameraWidth = Camera.main.orthographicSize * 2f * Camera.main.aspect;
		pipePairsArray = new List<GameObject>();
		numberOfPipes = Mathf.CeilToInt(cameraWidth / distanceInbetween);
		initializePipes(cameraWidth / 2);
	}

	// Update is called once per frame
	void Update () {
		foreach(GameObject pipePair in pipePairsArray){
			if(pipePair.transform.position.x + pipeWidth / 2 < -cameraWidth / 2){
				Reposition(pipePair);
			}
		}
	}

	void Reposition(GameObject pipePair){
		float yPos = Random.Range(-2.5f, 3.5f);
		float xPos = pipePairsArray[rightmostColumnIndex]
			.transform.position.x +  distanceInbetween;
		
		pipePair.transform.position = new Vector3(xPos, yPos, 0);
		rightmostColumnIndex = (rightmostColumnIndex + 1) % numberOfPipes;
	}

	//Initializes pipes with given distance and initial offset
	void initializePipes(float initialOffset){
		for(int i = 0; i < numberOfPipes; i++){
			float xPos = initialOffset + i * distanceInbetween;
			GameObject pipePair = (GameObject) Instantiate(pipesPrefab, new Vector3(xPos, 0, 0), Quaternion.identity);
			pipePairsArray.Add(pipePair);
		}
		rightmostColumnIndex = numberOfPipes - 1;
	}

	public void StopScrolling(){
		foreach(GameObject pipePair in pipePairsArray){
			pipePair.GetComponent<PipeMover>().StopScrolling();
		}
	}
}
