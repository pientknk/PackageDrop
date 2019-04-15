using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Controls and updates the summary canvas at the end of the level.
/// </summary>
public class SummaryController : MonoBehaviour {

	public Text label;
	//set one of these bools to true in order to show the updated progress
	public bool package = false;
	public bool money = false;
	public bool items = false;
	public Sprite filledStar;
	public Image packageImage;
	public Image moneyImage;
	public Image itemsImage;

	// Use this for initialization
	void Start () {
		label = GetComponent<Text> ();
		if (package) {
			label.text = (LevelController.instance.SuccessfulPackages.ToString() + "/" + LevelController.instance.packagesFor1Star.ToString());
			if (LevelController.instance.SuccessfulPackages >= LevelController.instance.packagesFor1Star) {
				packageImage.sprite = filledStar;
				packageImage.color = Color.white;
				LevelController.instance.starsEarned++;
			}
		} else if (money) {
			label.text = (LevelController.instance.CurrentMoney.ToString() + "/" + LevelController.instance.moneyFor1Star.ToString());
			if (LevelController.instance.CurrentMoney >= LevelController.instance.moneyFor1Star) {
				moneyImage.sprite = filledStar;
				moneyImage.color = Color.white;
				LevelController.instance.starsEarned++;
			}
		} else if (items) {
			label.text = (LevelController.instance.CurrentObjectCount.ToString() + "/" + LevelController.instance.maxObjectsUsedFor1Star.ToString());
			if (LevelController.instance.CurrentObjectCount <= LevelController.instance.CurrentObjectCount) {
				itemsImage.sprite = filledStar;
				itemsImage.color = Color.white;
				LevelController.instance.starsEarned++;
			}
		} else {
			print ("you must select one of the public bools to true in the summary panel");
		}
	}
}
