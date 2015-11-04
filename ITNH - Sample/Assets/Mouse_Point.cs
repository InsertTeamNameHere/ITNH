using UnityEngine;
using System.Collections;

public class Mouse_Point : MonoBehaviour {

	public float timer = 5.0f;

	RaycastHit hit;

	public static GameObject CurrentlySelectedUnit;

	public static ArrayList CurrentlySelectedUnits = new ArrayList ();

	public GameObject RightClickMarker;

	public static Vector3 mouseDownPoint = Vector3.zero;

	public static bool UserIsDragging;
	private static float TimeLimitBeforeDeclareDrag = 1f;
	private static float TimeLeftBeforeDeclareDrag;
	private static Vector2 MouseDragStart;

	private static float clickDragZone = 1.3f;

	// Issue: the scene restarts, but unable to click the tiles.
	/////////////////////////////////////////////////////////////////
	// (MissingReferenceException: The object of type 'GameObject' has been destroyed but you are still trying to access it.
	// Your script should either check if it is null or you should not destroy the object.)
	/////////////////////////////////////////////////////////////////
	void Start () {
		
		Time.timeScale = 1;
		
	}


	// The scene pauses after 5 seconds. After 3 seconds of pausing, the scene restarts.
	void Update () {

		timer -= Time.deltaTime;





		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		
		if (Physics.Raycast (ray, out hit, Mathf.Infinity)) {

			if (Input.GetMouseButtonDown (0))
				mouseDownPoint = hit.point;

		
			//MouseClick
			if (!UserIsDragging)
			{
				if (hit.collider.name == "Terrain") {
					if (Input.GetMouseButtonDown (1)) {
						GameObject Marker = Instantiate (RightClickMarker, hit.point, Quaternion.identity) as GameObject;
						Marker.name = "Marker Instantiated";
					} else if (Input.GetMouseButtonUp (0) && DidUserClickLeftMouse (mouseDownPoint)) {
						if (!ShiftKeysDown ())
							DeselectGameobjectsIfSelected ();
					}
				} else {
					//Hitting other objects
					if (Input.GetMouseButtonUp (0) && DidUserClickLeftMouse (mouseDownPoint)) {
						//is the user hitting a unit?
						if (hit.collider.transform.FindChild ("Selected")) {
							//found a unit we can select
							Debug.Log ("Found a unit!");

							//are we selecting a different object?
							if (!UnitAlreadyInCurrentlySelectedUnits (hit.collider.gameObject)) {
								//if the shift key is not down, remove the rest of the units
								if (!ShiftKeysDown ())
									DeselectGameobjectsIfSelected ();

								GameObject SelectedObj = hit.collider.transform.FindChild ("Selected").gameObject;
								SelectedObj.SetActive (true);
								//add unit to currently selected units
								CurrentlySelectedUnits.Add (hit.collider.gameObject);
							} else {
								//remove unit from currently selected units
								if (ShiftKeysDown ())
									RemoveUnitFromCurrentlySelectedUnits (hit.collider.gameObject);
								else {
									DeselectGameobjectsIfSelected ();
									GameObject SelectedObj = hit.collider.transform.FindChild ("Selected").gameObject;
									SelectedObj.SetActive (true);
									CurrentlySelectedUnits.Add (hit.collider.gameObject);
								}
							}
						} else {
							//if this object is not a unit
							if (!ShiftKeysDown ())
								DeselectGameobjectsIfSelected ();
						}
					}
				}

			} else {
				if (Input.GetMouseButtonUp (0) && DidUserClickLeftMouse (mouseDownPoint))
				if (!ShiftKeysDown ())
					DeselectGameobjectsIfSelected ();
			}
		}
		
		Debug.DrawRay (ray.origin, ray.direction * Mathf.Infinity, Color.red);
	}

	//Is the user dragging, relative to the mouse drag start point?
	public bool UserDraggingByPosition(Vector2 DragStartPoint, Vector2 NewPoint)
	{
		if ((NewPoint.x > DragStartPoint.x + clickDragZone || NewPoint.x < DragStartPoint.x - clickDragZone) ||
			(NewPoint.y > DragStartPoint.y + clickDragZone || NewPoint.y < DragStartPoint.y - clickDragZone))
			return true;
		else
			return false;
	}

	//Did user perform a mouse click?
	public bool DidUserClickLeftMouse(Vector3 hitPoint)
	{
		if((mouseDownPoint.x < hitPoint.x + clickDragZone && mouseDownPoint.x > hitPoint.x - clickDragZone) &&
		   (mouseDownPoint.y < hitPoint.y + clickDragZone && mouseDownPoint.y > hitPoint.y - clickDragZone) &&
		   (mouseDownPoint.z < hitPoint.z + clickDragZone && mouseDownPoint.z > hitPoint.z - clickDragZone))
			return true;
		else
			return false;
	}

	//Deselects units if selected
	public void DeselectGameobjectsIfSelected()
	{
		if(CurrentlySelectedUnits.Count > 0) {
			for(int i = 0; i < CurrentlySelectedUnits.Count; i++)
			{
				GameObject ArrayListUnit = CurrentlySelectedUnits[i] as GameObject;
				ArrayListUnit.transform.FindChild("Selected").gameObject.SetActive(false);
			}
			CurrentlySelectedUnits.Clear();
		}
	}

	//check if a unit is already in the currently selected units arraylist
	public static bool UnitAlreadyInCurrentlySelectedUnits(GameObject Unit)
	{
		if (CurrentlySelectedUnits.Count > 0) {
			for (int i = 0; i < CurrentlySelectedUnits.Count; i++) {
				GameObject ArrayListUnit = CurrentlySelectedUnits [i] as GameObject;
				if (ArrayListUnit == Unit)
					return true;
			}
			return false;
		} else
			return false;
	}

	//remove a unit from the currently selected units arraylist
	public void RemoveUnitFromCurrentlySelectedUnits(GameObject Unit)
	{
		if (CurrentlySelectedUnits.Count > 0) {
			for (int i = 0; i < CurrentlySelectedUnits.Count; i++) {
				GameObject ArrayListUnit = CurrentlySelectedUnits [i] as GameObject;
				if (ArrayListUnit == Unit)
				{
					CurrentlySelectedUnits.RemoveAt(i);
					ArrayListUnit.transform.FindChild("Selected").gameObject.SetActive(false);
				}
			}
			return;
		} else
			return;
	}

	//are the shift keys being held down?
	public static bool ShiftKeysDown()
	{
		if (Input.GetKey (KeyCode.LeftShift) || Input.GetKey (KeyCode.RightShift))
			return true;
		else
			return false;
	}

	// Wait 3 seconds 
	public IEnumerator autoRestart() {

		yield return new WaitForSeconds (3);

	}
}
