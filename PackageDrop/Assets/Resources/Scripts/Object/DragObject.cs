using UnityEngine;

/// <summary>
/// Drags the selected object to wherever the mouse can go on screen.
/// </summary>
public class DragObject : MonoBehaviour{

	private Vector3 screenPoint;
	private Vector3 offset;

	/// <summary>
	/// Raises the mouse down event. updates the selected object and gets an offset from the objects center to where the mouse is on the object.
	/// </summary>
	void OnMouseDown()
	{
		if (LevelController.instance.IsPaused) {
			LevelController.instance.selectedObject = gameObject;
			screenPoint = Camera.allCameras [0].WorldToScreenPoint (gameObject.transform.position);

			offset = gameObject.transform.position - Camera.allCameras [0].ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
			transform.SetAsLastSibling ();
		}
	}
		
	/// <summary>
	/// Raises the mouse drag event. Drags the object wherever the mouse pointer is
	/// </summary>
	void OnMouseDrag()
	{
		if (LevelController.instance.IsPaused) {
			Vector3 curScreenPoint = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);

			Vector3 curPosition = Camera.allCameras [0].ScreenToWorldPoint (curScreenPoint) + offset;

			transform.position = curPosition;
		}
	}
}
