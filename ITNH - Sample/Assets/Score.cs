using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {

	public GridScript Grid;

	public float Left = 0.0f;

	public float Total = 0.0f;

	public float Incorrect = 0.0f;

	static int Check = 1;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		Total = Grid.amount;

		if (Check > 0) 
		{
			Left = Total;
			Check = 0;
		}
	}
}
