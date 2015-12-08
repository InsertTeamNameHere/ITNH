using UnityEngine;
using System.Collections;

public class StartTimer : MonoBehaviour {
	
	private Window times;
	private TextMesh timerShowText;
	private TextMesh instruction1;
	public GameObject timerShowObject;
	
	// Use this for initialization
	void Start () {
		times = GameObject.FindGameObjectWithTag ("world").GetComponent<Window> ();
		timerShowText = GameObject.FindGameObjectWithTag ("start timer").GetComponent<TextMesh> ();
		instruction1 = GameObject.FindGameObjectWithTag ("inst1").GetComponent<TextMesh> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (times.StartTimer < 3) {
			timerShowText.color = Color.yellow;
		} 
		if (times.StartTimer < 2) {
			timerShowText.color = Color.red;
		}
		if (times.StartTimer <= 0) {
			timerShowObject.SetActive(false);
			instruction1.text = "";
		}
		timerShowText.text = "Time Remaining: " + (int)times.StartTimer;
	}
}