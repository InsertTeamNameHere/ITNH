using UnityEngine;
using System.Collections;

public class GridScript : MonoBehaviour {
	
	public Transform BlankWall;
	public Transform CorrectWall;
	public Vector3 Size;

	// Use this for initialization
	void Start () {
		CreateGrid();
	}

	void CreateGrid(){
		//create grid here
		int amount = 0;
		for (int x = 0; x < Size.x; x++) {
			for(int z = 0; z < Size.z; z++){
				Transform newCell;
				//int minimum = 5;
				//if(amount >= minimum){
				//	break;
				//}
				//else{
					int wallType = Random.Range (0,100);
					if(0 <= wallType && wallType < 75){
						newCell = (Transform)Instantiate (BlankWall, new Vector3(x, 0, z), Quaternion.identity);
						newCell.name = string.Format ("({0},{1})",x,z);
						newCell.parent = transform;
					}
					else if(wallType >= 75){
						newCell = (Transform)Instantiate (CorrectWall, new Vector3(x, 0, z), Quaternion.identity);
						newCell.name = string.Format ("({0},{1})",x,z);
						newCell.parent = transform;
						amount++;
						Debug.Log (amount);

					}

				}


				/*newCell = (Transform)Instantiate (Wall, new Vector3(x, y, 0), Quaternion.identity);
				newCell.name = string.Format ("({0},{1})",x,y);
				newCell.parent = transform;*/
			}

		}

	}
	

