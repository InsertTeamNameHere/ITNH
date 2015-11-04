using UnityEngine;
using System.Collections;

public class clickToFlipTest : MonoBehaviour {

	private Window times;
	public float timerShow;
	public float timerPlay;
	public GUIStyle guiStyle = new GUIStyle ();

	private Animator flipController;
	// Use this for initialization
	void Start () {
		flipController = this.GetComponent<Animator> ();
		times = GameObject.FindGameObjectWithTag ("world").GetComponent<Window> ();

		timerShow = times.StartTimer;
		timerPlay = times.GameTimer;
	}
	
	// Update is called once per frame
	void Update () {

		timerShow -= Time.deltaTime;
		if (timerShow <= 0) {
			flipController.SetBool ("flipped", true);
			timerPlay -= Time.deltaTime;
		}

		if (timerPlay <= 0) {
			flipController.SetBool ("flipped", false);
		}



		if(Input.GetKeyDown(KeyCode.Space)){
			if(flipController.GetBool ("flipped") == false){
				flipController.SetBool ("flipped", true);
			}
			else if(flipController.GetBool("flipped") == true){
				flipController.SetBool ("flipped", false);
			}
		}

	}

	void OnGUI() {
		guiStyle.fontSize = 25;
		guiStyle.normal.textColor = Color.green;
		guiStyle.font = (Font)Resources.Load ("Fonts/Sketch_Block");

		if (timerShow > 0) {
			GUI.TextArea (new Rect (50, 50, 100, 100), "Time Remaining: " + (int)timerShow, guiStyle);
		} else if (timerShow <= 0 && timerPlay > 0) {
			GUI.TextArea (new Rect (50, 50, 100, 100), "Time Remaining: " + (int)timerPlay, guiStyle);
		}
	}
}
