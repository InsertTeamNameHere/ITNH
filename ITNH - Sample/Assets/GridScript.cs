using UnityEngine;
using System.Collections;

public class GridScript : MonoBehaviour {
	
	public int amount = 0;
	public Transform BlankWall;
	public Transform BlankWallAnim;
	public Transform CorrectWall;
	public Transform CorrectWallAnim;
	public Vector3 Size;

	// Use this for initialization
	void Start () {
		CreateGrid();
	}

	void CreateGrid(){
		//create grid here
		for (int x = 0; x < Size.x; x++) {
			for(int z = 0; z < Size.z; z++){
				Transform newCell;
				Transform autoCell;
				//int minimum = 5;
				//if(amount >= minimum){
				//	break;
				//}
				//else{
					int wallType = Random.Range (0,100);
					if(0 <= wallType && wallType < 75){
						newCell = (Transform)Instantiate (BlankWall, new Vector3(x+Size.x, 0, z), Quaternion.identity);
						newCell.name = string.Format ("({0},{1})",x,z);
						newCell.parent = transform;

						autoCell = (Transform)Instantiate (BlankWallAnim, new Vector3(x-Size.x, 0, z), Quaternion.identity);
						autoCell.name = string.Format ("({0},{1})Anim",x,z);
						autoCell.parent = transform;
					}
					else if(wallType >= 75){
						newCell = (Transform)Instantiate (CorrectWall, new Vector3(x+Size.x, 0, z), Quaternion.identity);
						newCell.name = string.Format ("({0},{1})",x,z);
						newCell.parent = transform;
						amount++;

						autoCell = (Transform)Instantiate (CorrectWallAnim, new Vector3(x-Size.x, 0, z), Quaternion.identity);
						autoCell.name = string.Format ("({0},{1})Anim",x,z);
						autoCell.parent = transform;
						
					}

				}
				/*newCell = (Transform)Instantiate (Wall, new Vector3(x, y, 0), Quaternion.identity);
				newCell.name = string.Format ("({0},{1})",x,y);
				newCell.parent = transform;*/
			}

		}

	}
	

