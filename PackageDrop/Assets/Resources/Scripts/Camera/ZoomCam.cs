using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ZoomCam : MonoBehaviour {

	//Zoom Variables
	private Vector3 originalPos;
	private Vector3 newPos;
	private Vector3 zoomScale;

	//max scale value
	private float zoomMax = 4.0F;

	//boundaries for movement
	public int xLimit = 600;
	public int yLimit = 400;

	//Difference variables for movement
	public float xDiff;
	public float yDiff;

	private bool scroll;

	//Kill zone boundaries
	public bool inBoundsUp;
	public bool inBoundsDown;
	public bool inBoundsLeft;
	public bool inBoundsRight;

	private Vector3 center;

	void Start () {
		originalPos.x = gameObject.GetComponent<RectTransform> ().position.x;
		originalPos.y = gameObject.GetComponent<RectTransform> ().position.y;
		originalPos.z = gameObject.GetComponent<RectTransform> ().position.z;

		center.x = (Screen.width / 2);
		center.y = (Screen.height / 2);

		zoomScale = new Vector3 (1, 1, 1);
	}

	void Update () {

		inBoundsUp = GameObject.Find("Main Camera").GetComponent<CheckBounds> ().inBoundsUp;
		inBoundsDown = GameObject.Find("Main Camera").GetComponent<CheckBounds> ().inBoundsDown;
		inBoundsLeft = GameObject.Find("Main Camera").GetComponent<CheckBounds> ().inBoundsLeft;
		inBoundsRight = GameObject.Find("Main Camera").GetComponent<CheckBounds> ().inBoundsRight;

		newPos = transform.position;
		center.x = (Screen.width / 2);
		center.y = (Screen.height / 2);

		//to detemine if mouse is over UI elements
		PointerEventData cursor = new PointerEventData(EventSystem.current);                            // This section prepares a list for all objects hit with the raycast
		cursor.position = Input.mousePosition;
		List<RaycastResult> objectsHit = new List<RaycastResult> ();
		EventSystem.current.RaycastAll(cursor, objectsHit);
		int count = objectsHit.Count;

		if (count > 0) {
			scroll = false;
		} else {
			scroll = true;
		}

		if (scroll == true) {
			//Zoom
			if (Input.GetAxis ("Mouse ScrollWheel") < 0) {
				if (zoomScale.x > 1 && zoomScale.y > 1) {
					zoomScale.x -= 0.1F;
					zoomScale.y -= 0.1F;

					newPos.x += (originalPos.x - newPos.x) / (zoomScale.y * 5f);
					newPos.y += (originalPos.y - newPos.y) / (zoomScale.y * 5f);
				}			
			} else if (Input.GetAxis ("Mouse ScrollWheel") > 0) {

				if (zoomScale.x < zoomMax && zoomScale.y < zoomMax) {
					zoomScale.x += 0.1F;
					zoomScale.y += 0.1F;

					//1250 seems to be the required mouse delay to properly zoom in on the mouse position
					newPos.x -= ((Input.mousePosition.x - 1250) - newPos.x) / (zoomScale.x * 10f);

					//400 seems to be the Y delay
					newPos.y -= ((Input.mousePosition.y - 400) - newPos.y) / (zoomScale.y * 10.0f);
				}
			}

			gameObject.GetComponent<RectTransform> ().localScale = zoomScale;

			if (zoomScale.x <= 1) {
				newPos = originalPos;
				zoomScale.x = 1;
				zoomScale.y = 1;
			}

			//Mouse Push Movement
			if (zoomScale.x > 1) {

				if (inBoundsLeft == true) {
					if ((center.x - (xLimit / zoomScale.x)) > Input.mousePosition.x) {
						xDiff = (Input.mousePosition.x - center.x) / 60.0f;
						newPos.x -= xDiff;
					}				
				}

				if (inBoundsRight == true) {
					if((center.x + (xLimit / zoomScale.x)) < Input.mousePosition.x) {
						xDiff = (Input.mousePosition.x - center.x) / 60.0f;
						newPos.x -= xDiff;
					}
				}

				if (inBoundsUp == true) {
					if ((center.y + (yLimit / zoomScale.y)) < Input.mousePosition.y) {
						yDiff = (Input.mousePosition.y - center.y) / 40.0f;
						newPos.y -= yDiff;
					}
				}

				if (inBoundsDown == true) {
					if ((center.y - (yLimit / zoomScale.y)) > Input.mousePosition.y) {
						yDiff = (Input.mousePosition.y - center.y) / 40.0f;
						newPos.y -= yDiff;
					}
				}
			}
		}

		//print ("In Bounds Right: " + inBoundsRight + ", In Bounds Left: " + inBoundsLeft + ", In Bounds Up: " + inBoundsUp + ", In Bounds Down: " + inBoundsDown);
		gameObject.GetComponent<RectTransform> ().position = newPos;
		//print ("ZoomScale: " + zoomScale.x);

	}

}