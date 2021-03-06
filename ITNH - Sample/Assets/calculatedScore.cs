﻿using UnityEngine;
using System.Collections;

public class calculatedScore : MonoBehaviour {

	private Score score;

	private float left;
	private float total;
	private float incorrect;

	private float x;
	private float z;
	private float amount;

	public float finalScore;

	private TextMesh scoreText;

	private Window time;

	// Use this for initialization
	void Start () {
		score = GameObject.FindGameObjectWithTag ("world").GetComponent<Score> ();
		scoreText = GameObject.FindGameObjectWithTag ("score box").GetComponent<TextMesh> ();

		time = GameObject.FindGameObjectWithTag ("world").GetComponent<Window> ();

		x = GameObject.FindGameObjectWithTag ("grid").GetComponent<GridScript> ().Size.x;
		z = GameObject.FindGameObjectWithTag ("grid").GetComponent<GridScript> ().Size.z;
	}
	
	// Update is called once per frame
	void Update () {
		left = score.Left;
		total = score.Total;
		incorrect = score.Incorrect;
		amount = (x * z);

		if (left == 0 && incorrect == 0) {
			finalScore = 1000;
		}
		else{
			finalScore = (1000 * ((total-left)/total)) - (1000 * (incorrect/25));
		}

		if (time.GameTimer <= 0) {
			/*if (left == 0) {
				finalScore = total * 100;
				finalScore = finalScore + (total * 10);
			}
			else{
				finalScore = (total * 100) - (left * 100);
			}*/

			scoreText.text = "Score: " + (int)finalScore;
		}


	}
}
