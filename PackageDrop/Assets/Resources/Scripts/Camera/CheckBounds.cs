
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckBounds : MonoBehaviour {

	private Camera camera;

	private GameObject rightBound;
	private GameObject leftBound;
	private GameObject upperBound;
	private GameObject lowerBound;

	private GameObject lvlObjects;
	private RectTransform lvlRect;
	private Vector3 objPos;

	//From ZoomCam script
	private float xDiff;
	private float yDiff;

	public bool inBoundsUp;
	public bool inBoundsDown;
	public bool inBoundsLeft;
	public bool inBoundsRight;


	// Use this for initialization
	void Start () {
		camera = GetComponent<Camera>();

		//rightBound = GameObject.Find ("RightBound");
		//leftBound = GameObject.Find ("LeftBound");
		//upperBound = GameObject.Find ("UpperBound");
		//lowerBound = GameObject.Find ("LowerBound");

		rightBound = GameObject.Find ("Kill Zone Right");
		leftBound = GameObject.Find ("Kill Zone Left");
		upperBound = GameObject.Find ("Kill Zone Ceiling");
		lowerBound = GameObject.Find ("Kill Zone Floor");

		lvlObjects = GameObject.Find ("TheLevelObjects");
		lvlRect = lvlObjects.GetComponent<RectTransform>();
		objPos = lvlRect.localPosition;

		inBoundsUp = true;
		inBoundsDown = true;
		inBoundsLeft = true;
		inBoundsRight = true;
	}

	// Update is called once per frame
	void Update () {
		//xDiff = GameObject.Find("TheLevelObjects").GetComponent<ZoomCam> ().xDiff;
		//yDiff = GameObject.Find("TheLevelObjects").GetComponent<ZoomCam> ().yDiff;

		Vector3 rightPos = camera.WorldToViewportPoint(rightBound.transform.position);
		Vector3 leftPos = camera.WorldToViewportPoint(leftBound.transform.position);
		Vector3 upperPos = camera.WorldToViewportPoint(upperBound.transform.position);
		Vector3 lowerPos = camera.WorldToViewportPoint(lowerBound.transform.position);

		//print ("Right pos: " + rightPos.x + ", Left pos:" + leftPos.x + " Upper Pos: " + upperPos.y + " Lower Pos: " + lowerPos.y);

		objPos = lvlRect.localPosition;

		if (rightPos.x < 0.1F) {
			//objPos.x += 12;
			inBoundsRight = false;
		} else {
			inBoundsRight = true;
		}

		if (leftPos.x > -1.165F) {
			//objPos.x -= 12;
			inBoundsLeft = false;
		} else {
			inBoundsLeft = true;
		}

		if (upperPos.y < 0.825F) {
			//objPos.y += 12;
			inBoundsUp = false;
		} else {
			inBoundsUp = true;
		}

		if (lowerPos.y > -0.45F) {
			//objPos.y -= 12;
			inBoundsDown = false;
		} else {
			inBoundsDown = true;
		}

		lvlRect.localPosition = objPos;

	}
}

