using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class clickScore : MonoBehaviour {
	//int playerScore = 0;

	int increaseScore = 100;
	int decreaseScore = -25;
	
	public GameObject countText;
	public GameObject gameManager;
	
	public void updateScore(int amount)
	{
		gameManager.GetComponent<ScoreKeeper> ().score += amount;
	}
	// Use this for initialization
	void Start () {

	}

	void OnMouseEnter() { 
		//GetComponent<Renderer>().material.color = Color.red;
	}

	void OnMouseOver(){
		if (Input.GetMouseButtonDown(0))
		{
			updateScore(increaseScore);
		}
		else if (Input.GetMouseButtonDown(1))
		{
			updateScore(decreaseScore);
		}
	}
	// Update is called once per frame
	void Update () {

		countText.GetComponent<TextMesh>().text = "Score: " + gameManager.GetComponent<ScoreKeeper> ().score;


	}
}
