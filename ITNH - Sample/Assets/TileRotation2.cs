using UnityEngine;
using System.Collections;

public class TileRotation2 : MonoBehaviour {

	public float m_speed = 20.0f;

	public float timer = 1.0f;

	public float rotationDamping;

	private Rigidbody m_rigidBody;

	public GameObject Selected;

	public GameObject Flipped;

	// Use this for initialization
	void Start () {
		if (GetComponent<Rigidbody>() == null)
		{
			initRigidBody();
		}
		else
		{
			m_rigidBody = GetComponent<Rigidbody>();
		}
	}

	private void initRigidBody()
	{
		m_rigidBody = gameObject.AddComponent<Rigidbody>();
		m_rigidBody.mass = 500;
		m_rigidBody.interpolation = RigidbodyInterpolation.Interpolate;
		m_rigidBody.collisionDetectionMode = CollisionDetectionMode.Continuous;
		m_rigidBody.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ;
	}
	
	// Update is called once per frame
	void Update () {
		// Get the horizontal and vertical axis.
		// By default they are mapped to the arrow keys.
		// The value is in the range -1 to 1
		float translation = Input.GetAxis ("Horizontal") * m_speed;
		
		// Make it move m_speed meters per second instead of m_speed meters per frame...
		//translation *= Time.deltaTime;
		
		// Move translation along the object's x-axis
		if (Selected.activeInHierarchy) {
			//transform.rotation = Quaternion.Slerp (0, 0, Time.deltaTime * rotationDamping);
			Flipped.SetActive (true);

			Selected.SetActive (false);
		}

		else if (Flipped.activeInHierarchy) {
			transform.Rotate (0, 0, 180 * Time.deltaTime);
			timer -= Time.deltaTime;
			
			if (timer <= 1) {
				Flipped.SetActive (false);
			}
		}

		else {
			timer = 2.0f;
		}
	}
}
