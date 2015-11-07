using UnityEngine;
using System.Collections;

public class PlayTimer : MonoBehaviour {
	
	private Window times;
	private TextMesh timerPlayText;
	
	// Use this for initialization
	void Start () {
		
		times = GameObject.FindGameObjectWithTag ("world").GetComponent<Window> ();
		timerPlayText = GameObject.FindGameObjectWithTag ("play timer").GetComponent<TextMesh> ();
		timerPlayText.text = "";
	}
	
	// Update is called once per frame
	void Update () {
		if (times.StartTimer <= 0) {
			timerPlayText.text = "Time Remaining: " + (int)times.GameTimer;
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