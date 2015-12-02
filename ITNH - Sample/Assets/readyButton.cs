using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class readyButton : MonoBehaviour {
	
	public int paused;
	private TextMesh buttonText;
	private Animator tileFlip;
	private calculatedScore score;
	
	// Use this for initialization
	void Start () {
		//Time.timeScale = 0;
		buttonText = GameObject.FindGameObjectWithTag ("readyButton").GetComponent<TextMesh> ();
		tileFlip = GameObject.FindGameObjectWithTag ("anim tiles").GetComponent<Animator> ();
		score = GameObject.FindGameObjectWithTag ("world").GetComponent<calculatedScore> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (paused == 0) {
			Time.timeScale = 0;
		}
		else if (paused == 1) {
			Time.timeScale = 1;
		}
	}

	void OnMouseEnter() {
		buttonText.color = Color.green;
	}

	void OnMouseExit() {
		buttonText.color = Color.white;
	}

	void OnMouseOver() {
		if (Input.GetMouseButtonDown (0)) {
			paused = 1;
			buttonText.text = "";
			tileFlip.SetBool("flipped", false);
			score.finalScore = 0;
		}
	}
}
