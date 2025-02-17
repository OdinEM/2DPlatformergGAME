using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	public float resetSpeed = 0.5f;
	public float cameraSpeed = 0.3f;

	public Bounds cameraBounds;

	private Transform target; //GameObject transform holding reference to the player.

	private float offsetZ;
	private Vector3 currentVelocity;

	private bool followsPlayer;

	void Awake() {
		BoxCollider2D myCol = GetComponent<BoxCollider2D> ();
		myCol.size = new Vector2 (Camera.main.aspect * 2f * Camera.main.orthographicSize, 15f);
		cameraBounds = myCol.bounds;
	}

	void Start () { 

		if (target == null) {
			GameObject Player = GameObject.FindGameObjectWithTag("Player"); // if the gameoject is null/cant be found,use the "GameObject.FindGameObjectWithTag" method to assign whatever object has that tag to the Player Game object

			if (Player != null)
			{
				target = Player.transform; //the players position is now assigned to "target"
                Debug.Log( target.name + "has been located");
            }
			else
			{
				Debug.LogError("Dude we cant find your Gameobject");
			}
		}

		
		if (target != null)
		{
			offsetZ = (transform.position - target.position).z;
			followsPlayer = true;
            Debug.Log("the camera is following the " + target.name);
        }
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (followsPlayer) {
			Vector3 aheadTargetPos = target.position + Vector3.forward * offsetZ;

			if (aheadTargetPos.x >= transform.position.x) {
				Vector3 newCameraPosition = Vector3.SmoothDamp (transform.position, aheadTargetPos,
					ref currentVelocity, cameraSpeed);

				transform.position = new Vector3 (newCameraPosition.x, transform.position.y,
					newCameraPosition.z);

			}
		}
	}


} // class




































