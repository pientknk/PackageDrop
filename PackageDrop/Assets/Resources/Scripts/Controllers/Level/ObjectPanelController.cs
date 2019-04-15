using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Controls the object panel which allows for updating the selected object in various ways.
/// </summary>
public class ObjectPanelController : MonoBehaviour {


	private Button[] allButtons;
	private GameObject selectedObject;
	public Sprite switchRight;
	public Sprite switchLeft;
	public Sprite switchDisabled;
	// Use this for initialization
	void Start () {
		allButtons = transform.GetComponentsInChildren<Button> ();
		selectedObject = LevelController.instance.selectedObject;
	}
	
	// Update is called once per frame
	void Update () {
		if (selectedObject != LevelController.instance.selectedObject) {
			selectedObject = LevelController.instance.selectedObject;
		}
		SetUpButtonActions ();
		UpdateButtons ();
		//if/else statements on input keypresses so multiple keys can't be pressed at the same time
		if (selectedObject != null && LevelController.instance.IsPaused) {
			if (Input.GetKeyDown (KeyCode.Delete) || Input.GetKeyDown(KeyCode.Backspace)) {
				Sell (selectedObject);
			} else if (Input.GetKeyDown (KeyCode.O)) {
				HitOrange (selectedObject);
			} else if (Input.GetKeyDown (KeyCode.B)) {
				HitBlue (selectedObject);
			} else if (Input.GetKeyDown (KeyCode.N)) {
				HitBoth (selectedObject);
			} else if (Input.GetKeyDown (KeyCode.LeftArrow)) {
				RotateLeft (selectedObject);
			} else if (Input.GetKeyDown (KeyCode.RightArrow)) {
				RotateRight (selectedObject);
			} else if (Input.GetKeyDown (KeyCode.S)) {
				if (allButtons [6].IsInteractable()) {
					Switch (selectedObject);
				}
			} else if (Input.GetKeyDown (KeyCode.Space)) {
				if (allButtons [7].IsInteractable()) {
					Duplicate (selectedObject);
				}
			}

			//freely rotate left or right instead of fixed 15 degree rotation
			if (Input.GetKey(KeyCode.A)) {
				FreeRotateLeft (selectedObject);
			} else if (Input.GetKey(KeyCode.D)) {
				FreeRotateRight (selectedObject);
			}

		}
	}

	/// <summary>
	/// Updates the buttons to disable them where appropriate.
	/// </summary>
	void UpdateButtons(){
		if (LevelController.instance.selectedObject == null || !LevelController.instance.IsPaused) {
			foreach (Button button in allButtons) {
				button.interactable = false;
			}
		} else {
			//set all to interactable but then check what the selected object is an update buttons accordingly.
			foreach (Button button in allButtons) {
				button.interactable = true;
			}
				if (LevelController.instance.IsPaused) {
					if (LevelController.instance.selectedObject.tag == "Conveyor") {
						allButtons [6].interactable = true;
						SurfaceEffector2D surface = LevelController.instance.selectedObject.GetComponent<SurfaceEffector2D> ();
						if (surface != null) {
							if (surface.speed < 0) {
								allButtons [6].GetComponentsInChildren<Image> () [1].sprite = switchLeft;
							} else {
								allButtons [6].GetComponentsInChildren<Image> () [1].sprite = switchRight;
							}
						} 
					} else {
						allButtons [6].GetComponentsInChildren<Image> () [1].sprite = switchDisabled;
						allButtons [6].interactable = false;
					}
					if (LevelController.instance.selectedObject.tag == "Funnel") {
						allButtons [1].interactable = false;
						allButtons [2].interactable = false;
						allButtons [3].interactable = false;
					}
					if (getSelectedObjectCost () > LevelController.instance.startingMoney) {
						allButtons [7].interactable = false;
					}
			}
		}
	}

	/// <summary>
	/// Sell the specified object for half price.
	/// </summary>
	/// <param name="theObject">The object.</param>
	private void Sell(GameObject theObject){
		LevelController.instance.startingMoney += getSelectedObjectCost() / 2;
		LevelController.instance.allBoughtObjects.Remove (theObject);
		Destroy (theObject);
		LevelController.instance.selectedObject = null;
		LevelController.instance.CurrentObjectCount--;
		UpdateButtons ();
	}

	/// <summary>
	/// Changes the object's filter to only hit orange.
	/// </summary>
	/// <param name="theObject">The object.</param>
	private void HitOrange(GameObject theObject){
		theObject.layer = 9;
		foreach (Transform child in theObject.transform) {
			child.gameObject.layer = 9;
		}
		foreach (SpriteRenderer sprite in theObject.transform.GetComponentsInChildren<SpriteRenderer> ()) {
			sprite.color = new Color (1.0f, 0.6f, 0.0f, 0.5f);
		}
	}

	/// <summary>
	/// Changes the object's filter to only hit blue.
	/// </summary>
	/// <param name="theObject">The object.</param>
	private void HitBlue(GameObject theObject){
		theObject.layer = 8;
		foreach (Transform child in theObject.transform) {
			child.gameObject.layer = 8;
		}
		foreach (SpriteRenderer sprite in theObject.transform.GetComponentsInChildren<SpriteRenderer> ()) {
			sprite.color = new Color(0.0f, 0.0f, 1.0f, 0.5f);
		}
	}

	/// <summary>
	/// Changes the object's filter to hit any color.
	/// </summary>
	/// <param name="theObject">The object.</param>
	private void HitBoth(GameObject theObject){
		theObject.layer = 0;
		foreach (Transform child in theObject.transform) {
			child.gameObject.layer = 0;
		}
		foreach (SpriteRenderer sprite in theObject.transform.GetComponentsInChildren<SpriteRenderer> ()) {
			sprite.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
		}

	}

	/// <summary>
	/// Rotates the object left by 15 degrees.
	/// </summary>
	/// <param name="theObject">The object.</param>
	private void RotateLeft(GameObject theObject){
		Vector3 rotation = theObject.transform.rotation.eulerAngles;
		rotation += (Vector3.forward * 15.0f);
		theObject.transform.eulerAngles = rotation;
	}

	/// <summary>
	/// Rotates the object left by 1 degree for every frame
	/// </summary>
	/// <param name="theObject">The object.</param>
	private void FreeRotateLeft(GameObject theObject){
		Vector3 rotation = theObject.transform.rotation.eulerAngles;
		rotation += (Vector3.forward * 1.0f);
		theObject.transform.eulerAngles = rotation;
	}

	/// <summary>
	/// Rotates the object right by 15 degrees.
	/// </summary>
	/// <param name="theObject">The object.</param>
	private void RotateRight(GameObject theObject){
		Vector3 rotation = theObject.transform.rotation.eulerAngles;
		rotation += (Vector3.back * 15.0f);
		theObject.transform.eulerAngles = rotation;
	}

	/// <summary>
	/// Rotates the object right by 1 degree for every frame
	/// </summary>
	/// <param name="theObject">The object.</param>
	private void FreeRotateRight(GameObject theObject){
		Vector3 rotation = theObject.transform.rotation.eulerAngles;
		rotation += (Vector3.back * 1.0f);
		theObject.transform.eulerAngles = rotation;
	}

	/// <summary>
	/// Switch the direction a conveyor is pushing.
	/// </summary>
	/// <param name="theObject">The object.</param>
	private void Switch(GameObject theObject){
		SurfaceEffector2D surface = theObject.GetComponent<SurfaceEffector2D> ();
		if (surface != null) {
			surface.speed *= -1;
			if (surface.speed < 0) {
				allButtons [6].GetComponentsInChildren<Image> () [1].sprite = switchLeft;
			} else {
				allButtons [6].GetComponentsInChildren<Image> () [1].sprite = switchRight;
			}
		} else {
			allButtons [6].GetComponentsInChildren<Image> () [1].sprite = switchDisabled;
		}
	}

	/// <summary>
	/// Duplicate the specified object if there is enough money available.
	/// </summary>
	/// <param name="theObject">The object.</param>
	private void Duplicate(GameObject theObject){
		int cost = getSelectedObjectCost ();
		LevelController.instance.startingMoney -= cost;
		GameObject clone = Instantiate (theObject);
		Vector3 pos = new Vector3 (theObject.transform.position.x + 20.0f, theObject.transform.position.y + 20.0f);
		clone.transform.position = pos;
		clone.transform.SetParent (LevelController.instance.theLevelObjects.transform);
		LevelController.instance.selectedObject = clone;
		LevelController.instance.CurrentObjectCount++;
		LevelController.instance.allBoughtObjects.Add (clone);
	}

	/// <summary>
	/// Sets up button actions to apply to the currently selected object.
	/// </summary>
	private void SetUpButtonActions(){
		foreach (Button button in allButtons) {
			button.onClick.RemoveAllListeners ();
		}
		allButtons[0].onClick.AddListener (delegate {
			Sell(selectedObject);
		});
		allButtons[1].onClick.AddListener (delegate {
			HitOrange(selectedObject);
		});
		allButtons[2].onClick.AddListener (delegate {
			HitBlue(selectedObject);
		});
		allButtons[3].onClick.AddListener (delegate {
			HitBoth(selectedObject);
		});
		allButtons[4].onClick.AddListener (delegate {
			RotateLeft(selectedObject);
		});
		allButtons[5].onClick.AddListener (delegate {
			RotateRight(selectedObject);
		});
		allButtons[6].onClick.AddListener (delegate {
			Switch(selectedObject);
		});
		allButtons[7].onClick.AddListener (delegate {
			Duplicate(selectedObject);
		});
	}

	/// <summary>
	/// Gets the selected object cost.
	/// </summary>
	/// <returns>The selected object cost.</returns>
	private int getSelectedObjectCost(){
		
		GameObject selectedObject = LevelController.instance.selectedObject;
		if (selectedObject != null) {
			string tag = selectedObject.tag;
			int objectCost;
			switch (tag) {
			case "Conveyor":
				objectCost = LevelController.instance.ConveyorCost;
				break;
			case "Trampoline":
				objectCost = LevelController.instance.TrampolineCost;
				break;
			case "Slide":
				objectCost = LevelController.instance.SlideCost;
				break;
			case "Fan":
				objectCost = LevelController.instance.FanCost;
				break;
			case "Glue":
				objectCost = LevelController.instance.GlueCost;
				break;
			case "Magnet":
				objectCost = LevelController.instance.MagnetCost;
				break;
			case "Funnel":
				objectCost = LevelController.instance.FunnelCost;
				break;
			default:
				objectCost = 0;
				break;
			}
			return objectCost;
		} else {
			print ("Error: no selected object...objectpanelcontroller.cs");
			return 0;
		}

	}
}
