using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Gets the cost of the object this script is attached to.
/// </summary>
public class UsableObjectCost : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Text label = GetComponent<Text> ();
		switch (this.tag){
		case "Conveyor":
			label.text = "Conveyor - $" + LevelController.instance.ConveyorCost;
			break;
		case "Trampoline":
			label.text = "Trampoline - $" + LevelController.instance.TrampolineCost;
			break;
		case "Slide":
			label.text = "Slide - $" + LevelController.instance.SlideCost;
			break;
		case "Fan":
			label.text = "Fan - $" + LevelController.instance.FanCost;
			break;
		case "Glue":
			label.text = "Glue - $" + LevelController.instance.GlueCost;
			break;
		case "Magnet":
			label.text = "Magnet - $" + LevelController.instance.MagnetCost;
			break;
		case "Funnel":
			label.text = "Funnel - $" + LevelController.instance.FunnelCost;
			break;
		default:
			label.text = "Unknown";
			print ("Error: " + this.tag + " - must have an appropriate tag. e.g. Conveyor");
			break;
		}
	}
}
