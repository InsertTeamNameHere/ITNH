using UnityEngine;
using System.Collections;

public class flip : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (180 * Time.deltaTime, 0, 0);
	}
}
