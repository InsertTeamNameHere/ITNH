using UnityEngine;
using System.Collections;

public class Reset : MonoBehaviour {

	public Score score;

	private int total;

	public int SmallestAmount = 3;
	public int LargestAmount = 10;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		total = (int)score.Total;

		if (total < SmallestAmount) {
			Application.LoadLevel("Game [Updated]");
		}

		else if (total > LargestAmount) {
			Application.LoadLevel("Game [Updated]");
		}
	}
}
