using UnityEngine;

/// <summary>
/// Rotates the object this script is attached to, and only rotates while the game is in play mode. 
/// This is made for the fan or other rotating usable objects.
/// </summary>
public class RotateAnimation : MonoBehaviour {
	
	public float speed = -550.0f;


	// Update is called once per frame
	void Update () {
		if (!LevelController.instance.IsPaused) {
			transform.Rotate (new Vector3 (0, 0, Time.deltaTime * speed));
		}
	}
}
