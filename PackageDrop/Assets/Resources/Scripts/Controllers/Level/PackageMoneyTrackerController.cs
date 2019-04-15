using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Controls and manages the amount of money earned, successful packages, and failed packages.
/// </summary>
public class PackageMoneyTrackerController : MonoBehaviour {

	private Text successText;
	private Text failText;
	public Text moneyLabel;
	private int money;
	// Use this for initialization
	void Start () {
		successText = GetComponentsInChildren<Text> () [0];
		failText = GetComponentsInChildren<Text> () [1];
		money = LevelController.instance.CurrentMoney;
	}
	
	// Update is called once per frame
	void Update () {
		int successCount = LevelController.instance.SuccessfulPackages;
		int failureCount = LevelController.instance.FailurePackages;
		successText.text = "x" + successCount;
		failText.text = "x" + failureCount;
		if (money != LevelController.instance.CurrentMoney) {
			int initial = money;
			money = LevelController.instance.CurrentMoney;
			gameObject.AddComponent<TextChangeController> ().Create (moneyLabel, initial, money);
		} else {
			moneyLabel.text = money.ToString ();
		}
	}
}
