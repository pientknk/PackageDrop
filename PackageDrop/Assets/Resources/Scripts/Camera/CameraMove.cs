using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// Allows the camera to be moved when the mouse reaches an edge of the screen, but not while hovering over ui elements.
/// </summary>
public class CameraMove : MonoBehaviour {

	//camera boundary and movement
	/// <summary>
	/// Distance from edge where scrolling starts
	/// </summary>
	public float boundary = 50.0f;
	/// <summary>
	/// The Speed the camera will move at
	/// </summary>
	public int speed = 20;

	private int theScreenWidth;
	private int theScreenHeight;

	//camera field of view
	private float minSize = 100.0f;
	private float maxSize = 300.0f;
	/// <summary>
	/// The speed that the scrollwheel will zoom in and out
	/// </summary>
	private float sensitivity = 50f;
	private Rect screenRect;

	//camera bounds and the level bounds
	private float minX;
	private float maxX;
	private float minY;
	private float maxY;
	private float camMinX;
	private float camMaxX;
	private float camMinY;
	private float camMaxY;

	private Vector3 startPos;
	private Vector3 newPos;

	private bool moveable;
	//helpers to reduce the jerkiness associated with jumping the camera to a new position
	private Vector3 freezePoint;
	private float freezeThreshold = 20f;

	void Start() 
	{
		moveable = true;
		theScreenWidth = Screen.width;
		theScreenHeight = Screen.height;
		screenRect = new Rect(0, 0, Screen.width, Screen.height);
		GameObject theLevelObject = LevelController.instance.theLevelObjects;
		Vector3 levelObjectsRect = theLevelObject.GetComponent<RectTransform> ().position;
		Rect levelObjectRect = theLevelObject.GetComponent<RectTransform> ().rect;

		minX = levelObjectsRect.x - levelObjectRect.width / 2;
		maxX = levelObjectsRect.x + levelObjectRect.width / 2;
		minY = levelObjectsRect.y - levelObjectRect.height / 2;
		maxY = levelObjectsRect.y + levelObjectRect.height / 2;

		startPos = Camera.allCameras [0].transform.position;
	}

	// Update is called once per frame
	void Update() 
	{
		
		newPos = transform.position;

		//to detemine if mouse is over UI elements
		PointerEventData cursor = new PointerEventData(EventSystem.current);                     
		cursor.position = Input.mousePosition;
		List<RaycastResult> objectsHit = new List<RaycastResult> ();
		EventSystem.current.RaycastAll(cursor, objectsHit);
		int count = objectsHit.Count;

		//This is to reduce the jerkiness of the movement. Prevents the camera from moving during scrolling
		//Also prevents camera from moving if mouse is over UI elements
		if ((Vector3.Distance(Input.mousePosition, freezePoint) > freezeThreshold) && count == 0) {
			moveable = true;
		} else {
			moveable = false;
		}


		//get the camera bounds
		camMinX = Camera.allCameras [0].ScreenToWorldPoint(new Vector3(0,0)).x;
		camMaxX = Camera.allCameras [0].ScreenToWorldPoint (new Vector3 (theScreenWidth, 0)).x;
		camMinY = Camera.allCameras [0].ScreenToWorldPoint (new Vector3 (0, 0)).y;
		camMaxY = Camera.allCameras [0].ScreenToWorldPoint (new Vector3 (0, theScreenHeight)).y;

		if (moveable == true) {
			//each if statement is for the 4 sides, testing what side the mouse is on

			if (Input.mousePosition.x > theScreenWidth - boundary && camMaxX != maxX) {
				newPos = transform.position;

				//move on the +X axis
				if (camMaxX < maxX) {
					if (camMaxX + speed > maxX) {
						newPos.x += maxX - camMaxX;
					} else {
						newPos.x += speed;
					}
					transform.position = newPos;
				}
			}

			if (Input.mousePosition.x < 0 + boundary && camMinX != minX) {
				newPos = transform.position;
	
				// move on -X axis
				if (camMinX > minX) {
					if (camMinX - speed < minX) {
						newPos.x -= camMinX - minX;
					} else {
						newPos.x -= speed;
					}
					transform.position = newPos; 
				}
			}

			if (Input.mousePosition.y > theScreenHeight - boundary && camMaxY != maxY) {
				newPos = transform.position;
			
				//move on the +Y axis
				if (camMaxY < maxY) {
					if (camMaxY + speed > maxY) {
						newPos.y += maxY - camMaxY;
					} else {
						newPos.y += speed;
					}
					transform.position = newPos;
				}
			}

			if (Input.mousePosition.y < 0 + boundary && camMinY != minY) {
				newPos = transform.position;

				// move on -Y axis
				if (camMinY > minY) {
					if (camMinY - speed < minY) {
						newPos.y -= camMinY - minY;
					} else {
						newPos.y -= speed;
					}
					transform.position = newPos; 
				}
			}
		}

		//zoom in and out according to scroll wheel input
		float size = Camera.allCameras [0].orthographicSize;
		size -= Input.GetAxis ("Mouse ScrollWheel") * sensitivity;			
		size = Mathf.Clamp (size, minSize, maxSize);
		Camera.allCameras [0].orthographicSize = size;

		if (Input.GetAxis ("Mouse ScrollWheel") > 0) {
			freezePoint = Input.mousePosition;
			moveable = false;
		} else if (Input.GetAxis ("Mouse ScrollWheel") < 0) {
			freezePoint = Input.mousePosition;
			moveable = false;

			newPos.x += ((startPos.x - newPos.x) / 5f);
			newPos.y += ((startPos.y - newPos.y) / 5f);
		}
		//move the camera position
		transform.position = newPos;
	}
}
