using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Manages the arrows on the conveyor belt, ensuring that they indicate which direction the conveyor will push objects
/// </summary>
public class ConveyorArrowManager : MonoBehaviour {

	public GameObject rightArrow;
	public GameObject leftArrow;
	public SurfaceEffector2D effector;
	
	// Update is called once per frame
	void Update () {

		if (effector != null && rightArrow != null) {
			if (effector.speed < 0) {
				rightArrow.SetActive (false);
				leftArrow.SetActive (true);

			} else {
				rightArrow.SetActive (true);
				leftArrow.SetActive (false);
			}
		} else {
			print ("Need to assign right arrow and/or effector");
		}
	}
}
