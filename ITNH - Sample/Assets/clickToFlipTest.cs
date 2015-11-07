using UnityEngine;
using System.Collections;

public class clickToFlipTest : MonoBehaviour {
	
	private Window times;
	private Animator flipController;
	
	// Use this for initialization
	void Start () {
		
		flipController = this.GetComponent<Animator> ();
		times = GameObject.FindGameObjectWithTag ("world").GetComponent<Window> ();
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if (times.StartTimer <= 0.5f) {
			flipController.SetBool ("flipped", true);
		}
		
		if (times.GameTimer <= 0.5f) {
			flipController.SetBool ("flipped", false);
		}
		
		
		/*
		if(Input.GetKeyDown(KeyCode.Space)){
			if(flipController.GetBool ("flipped") == false){
				flipController.SetBool ("flipped", true);
			}
			else if(flipController.GetBool("flipped") == true){
				flipController.SetBool ("flipped", false);
			}
		}
		*/
	}
}
