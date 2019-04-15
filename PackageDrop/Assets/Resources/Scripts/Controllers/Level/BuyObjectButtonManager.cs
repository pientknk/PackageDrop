using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Manages all the buttons used to buy new objects.
/// </summary>
public class BuyObjectButtonManager : MonoBehaviour {

	private Button[] allButtons;

	// Use this for initialization
	void Start () {
		allButtons = gameObject.GetComponentsInChildren<Button> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (!LevelController.instance.IsPaused) {
			foreach (Button button in allButtons) {
				button.interactable = false;
			}
		} else {
			foreach (Button button in allButtons) {
				button.interactable = true;
			}
			CheckBuyButtons ();
		}
	}

	/// <summary>
	/// Updates the buttons interactive state based on how much money the player has
	/// </summary>
	private void CheckBuyButtons(){
		float currentMoney = LevelController.instance.startingMoney;
		for (int i = 0; i < allButtons.Length; i++) {
			switch (i) {
			case 0:
				if (currentMoney < LevelController.instance.SlideCost) {
					allButtons [i].interactable = false;
				} else {
					allButtons [i].interactable = true;
				}
				break;
			case 1:
				if (currentMoney < LevelController.instance.ConveyorCost) {
					allButtons [i].interactable = false;
				} else {
					allButtons [i].interactable = true;
				}
				break;
			case 2:
				if (currentMoney < LevelController.instance.TrampolineCost) {
					allButtons [i].interactable = false;
				} else {
					allButtons [i].interactable = true;
				}
				break;
			case 3:
				if (currentMoney < LevelController.instance.GlueCost) {
					allButtons [i].interactable = false;
				} else {
					allButtons [i].interactable = true;
				}
				break;
			case 4:
				if (currentMoney < LevelController.instance.FunnelCost) {
					allButtons [i].interactable = false;
				} else {
					allButtons [i].interactable = true;
				}
				break;
			case 5:
				if (currentMoney < LevelController.instance.FanCost) {
					allButtons [i].interactable = false;
				} else {
					allButtons [i].interactable = true;
				}
				break;
			case 6:
				if (currentMoney < LevelController.instance.MagnetCost) {
					allButtons [i].interactable = false;
				} else {
					allButtons [i].interactable = true;
				}
				break;
			default:
				break;
			}
		}
	




	}
}
