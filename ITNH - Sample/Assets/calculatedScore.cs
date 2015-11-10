using UnityEngine;
using System.Collections;

public class calculatedScore : MonoBehaviour {

	private Score score;

	private int left;
	private int total;

	public int finalScore;

	private TextMesh scoreText;

	// Use this for initialization
	void Start () {
		score = GameObject.FindGameObjectWithTag ("world").GetComponent<Score> ();
		scoreText = GameObject.FindGameObjectWithTag ("score box").GetComponent<TextMesh> ();
	}
	
	// Update is called once per frame
	void Update () {
		left = (int)score.Left;
		total = (int)score.Total;

		if (left == 0) {
			finalScore = total * 100;
			finalScore = finalScore + (total * 10);
		}
		else{
			finalScore = (total * 100) - (left * 100);
		}

		scoreText.text = "Score: " + (int)finalScore;
	}
}
