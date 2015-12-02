using UnityEngine;
using System.Collections;

public class PlayTimer : MonoBehaviour {
	
	private Window times;
	private TextMesh timerPlayText;
	private calculatedScore score;
	
	// Use this for initialization
	void Start () {
		
		times = GameObject.FindGameObjectWithTag ("world").GetComponent<Window> ();
		timerPlayText = GameObject.FindGameObjectWithTag ("play timer").GetComponent<TextMesh> ();
		timerPlayText.text = "";
		score = GameObject.FindGameObjectWithTag ("world").GetComponent<calculatedScore> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (times.StartTimer <= 0) {
			timerPlayText.text = "Time Remaining: " + (int)times.GameTimer;
			score.finalScore = score.finalScore - 1000;
		}
		if (times.GameTimer < 3) {
			timerPlayText.color = Color.yellow;
		} 
		if (times.GameTimer < 2) {
			timerPlayText.color = Color.red;
		}
		if (times.GameTimer <= 0) {
			timerPlayText.text = "";
		}
	}
}