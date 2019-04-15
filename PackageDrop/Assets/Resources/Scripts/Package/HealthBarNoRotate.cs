using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Stops the health bar from rotating with the package its connected to.
/// </summary>
public class HealthBarNoRotate : MonoBehaviour {

	private Quaternion rotation;
	private Vector3 offset;

	// Use this for initialization
	void Awake () {
		rotation = transform.rotation;
		offset = transform.position - transform.parent.position;
	}

	void LateUpdate () {
		transform.rotation = rotation;
		transform.position = transform.parent.position + offset;
	}
}
