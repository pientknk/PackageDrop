using UnityEngine;

/// <summary>
/// Destroys any package that comes into contact with the object with this script and updates everything neccessary.
/// </summary>
public class DestroyPackage : MonoBehaviour {

	/// <summary>
	/// Raises the collision enter2d event. Checks the tag of the colliding object to update package information
	/// </summary>
	/// <param name="col">Col.</param>
	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.tag == "blue item" || col.gameObject.tag == "orange item") {
			LevelController.instance.FailurePackages++;
			LevelController.instance.CurrentMoney -= (int)LevelController.instance.packageWorth / 2;
			Destroy (col.gameObject);
			LevelController.instance.NumPackagesLeft--;
			checkPackageDestructionCount ();
		} else {
			Destroy (col.gameObject);
		}
	}

	/// <summary>
	/// Checks the package destruction count to set the summary canvas if no more packages are left.
	/// </summary>
	private void checkPackageDestructionCount(){
		if (LevelController.instance.summaryCanvas != null) {
			if (LevelController.instance.NumPackagesLeft == 0) {
				LevelController.instance.summaryCanvas.SetActive (true);
				Time.timeScale = LevelController.instance.PauseGameSpeed;
				LevelController.instance.canvas.GetComponent<CanvasGroup> ().interactable = false;
			}
		} else {
			print ("Summary canvas is not set");
		}
	}
}
