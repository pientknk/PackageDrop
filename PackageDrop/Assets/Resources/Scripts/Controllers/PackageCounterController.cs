using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Updates the text to show how many packages are left in the level.
/// </summary>
public class PackageCounterController : MonoBehaviour {

	private Text label;
	// Use this for initialization
	void Start () {
		label = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		label.text = "x" + LevelController.instance.NumPackagesLeft;
	}
}
