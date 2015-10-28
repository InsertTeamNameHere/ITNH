using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class clickScoreCorrect: MonoBehaviour {
	//int playerScore = 0;

	int increaseScore = 100;
	int decreaseScore = -25;
	
	GameObject countText;
	GameObject gameManager;
	
	public void updateScore(int amount)
	{
		gameManager.GetComponent<ScoreKeeper> ().score += amount;
	}
	// Use this for initialization
	void Start () {
		countText = GameObject.FindGameObjectWithTag ("score box");
		gameManager = GameObject.FindGameObjectWithTag ("world");
	}

	void OnMouseEnter() { 
		//GetComponent<Renderer>().material.color = Color.red;
	}

	void OnMouseOver(){
		if (Input.GetMouseButtonDown(0))
		{
			updateScore(increaseScore);
		}
	}
	// Update is called once per frame
	void Update () {

		countText.GetComponent<TextMesh>().text = "Score: " + gameManager.GetComponent<ScoreKeeper> ().score;


	}
}
