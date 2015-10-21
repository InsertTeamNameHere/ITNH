using UnityEngine;
using System.Collections;

public class Window : MonoBehaviour {

	public float StartTimer = 5.0f;

	public float GameTimer = 60.0f;

	public float EndTimer = 5.0f;

	public GameObject Divider;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		StartTimer -= Time.deltaTime;
		
		if (StartTimer <= 0) 
		{
			Divider.SetActive (false);
			StartTimer = 0;

			GameTimer -= Time.deltaTime;
			
			if (GameTimer <= 0) 
			{
				Divider.SetActive (true);
				GameTimer = 0;
			}
		}
	}
}
