using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Rotates an object left or right slowly depeding on what the rotateRight bool is set at.
/// Made mostly for a moving background image (gears).
/// </summary>
public class GearRotation : MonoBehaviour {

	public bool rotateRight = true;

	// Update is called once per frame
	void Update () {
		if (rotateRight) {
			transform.Rotate (new Vector3 (0, 0, Time.deltaTime * -100));
		} else {
			transform.Rotate (new Vector3 (0, 0, Time.deltaTime * 100));
		}

	}
}
