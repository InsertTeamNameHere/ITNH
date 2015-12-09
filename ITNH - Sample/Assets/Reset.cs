using UnityEngine;
using System.Collections;

public class Reset : MonoBehaviour {

	private Score score;

	private int total;

	public int SmallestAmount = 3;
	public int LargestAmount = 10;

	// Use this for initialization
	void Start () {
		score = this.GetComponent<Score> ();
	}
	
	// Update is called once per frame
	void Update () {
		total = (int)score.Total;

		if (total < SmallestAmount) {
			Application.LoadLevel(Application.loadedLevel);
		}

		else if (total > LargestAmount) {
			Application.LoadLevel(Application.loadedLevel);
		}
	}
}
