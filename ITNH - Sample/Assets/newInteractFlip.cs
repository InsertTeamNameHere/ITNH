using UnityEngine;
using System.Collections;

public class newInteractFlip : MonoBehaviour {

	private Animator flipController;
	private Score score;
	// Use this for initialization
	void Start () {
		flipController = this.GetComponent<Animator> ();
		score = GameObject.FindGameObjectWithTag ("world").GetComponent<Score> ();
	}
	
	// Update is called once per frame
	void Update () {


	}

	void OnMouseDown(){
		if (Input.GetMouseButton (0)) {
			if(flipController.GetBool ("flipped") == false){
				flipController.SetBool ("flipped", true);
				score.Incorrect++;
			}
			else if(flipController.GetBool("flipped") == true){
				flipController.SetBool ("flipped", false);
				score.Incorrect--;
			}
		}
	}
}
