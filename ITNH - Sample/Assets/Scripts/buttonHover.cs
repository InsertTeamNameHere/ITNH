using UnityEngine;
using System.Collections;

public class buttonHover : MonoBehaviour {
	public GameObject tile;
	private Animator flipController;
	// Use this for initialization
	void Start () {
		flipController = tile.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if(flipController.GetBool ("flipped") == true){
			flipController.SetBool ("flipped", false);
		}
	}

	void OnMouseOver(){
		if(flipController.GetBool ("flipped") == false){
			flipController.SetBool ("flipped", true);
		}
	}
}
