using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Updates the money available for the user on the current level.
/// </summary>
public class SpendingMoney : MonoBehaviour {

	private Text label;
	private int money;
	// Use this for initialization
	void Start () {
		label = GetComponent<Text> ();
		money = LevelController.instance.startingMoney;
	}
	
	// Update is called once per frame
	void Update () {
		// if the amount of money has changed, run textchangecontroller
		if (money != LevelController.instance.startingMoney) {
			int initial = money;
			money = LevelController.instance.startingMoney;
			gameObject.AddComponent<TextChangeController> ().Create (label, initial, money);
		} else {
			label.text = money.ToString();
		}	
	}
}
