using UnityEngine;
using System.Collections;

public class newInteractFlip : MonoBehaviour {

	private Animator flipController;
	// Use this for initialization
	void Start () {
		flipController = this.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {


	}

	void OnMouseDown(){
		if (Input.GetMouseButton (0)) {
			if(flipController.GetBool ("flipped") == false){
				flipController.SetBool ("flipped", true);
			}
			else if(flipController.GetBool("flipped") == true){
				flipController.SetBool ("flipped", false);
			}
		}
	}
}
