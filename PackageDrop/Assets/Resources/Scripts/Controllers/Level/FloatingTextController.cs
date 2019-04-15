using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The controller that manages floating text to appear at the given location.
/// </summary>
public class FloatingTextController : MonoBehaviour {

	private static FloatingText popupTextPrefab;
	private static GameObject canvas;

	/// <summary>
	/// Initialize this instance and assign the object to the canvas so it displays correctly.
	/// </summary>
	public static void Initialize(){
		popupTextPrefab = Resources.Load<FloatingText>("Prefabs/UI/Popup Text Parent");
		canvas = LevelController.instance.levelCanvas;
	}

	/// <summary>
	/// Creates the floating text object.
	/// </summary>
	/// <param name="text">Text.</param>
	/// <param name="location">Location.</param>
	public static void CreateFloatingText(string text, Vector3 location){
		FloatingText instance = Instantiate (popupTextPrefab);
		instance.transform.SetParent (canvas.transform, false);
		float height = 10.0f;
		//Vector3 screenLocation = Camera.allCameras[0].WorldToScreenPoint(location);
		Vector3 modifiedLocation = new Vector3 (location.x, location.y + height, location.z);
		instance.transform.position = modifiedLocation;
		instance.setText (text);
	}
}
