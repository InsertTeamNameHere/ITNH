using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class readyButton : MonoBehaviour {
	
	public int paused;
	private TextMesh buttonText;
	
	// Use this for initialization
	void Start () {
		//Time.timeScale = 0;
		buttonText = GameObject.FindGameObjectWithTag ("readyButton").GetComponent<TextMesh> ();
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
		}
	}
}
