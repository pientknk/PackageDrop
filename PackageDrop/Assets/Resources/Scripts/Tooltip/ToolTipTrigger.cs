using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// the Tool tip trigger handles pointer events to determine mouse position and what object is hovered over. 
/// Then determines an adjusted position to place the tooltip on screen.
/// </summary>
public class ToolTipTrigger : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, ISelectHandler, IDeselectHandler{

	public string text;
	public GameObject toolTip;

	private bool shouldShow;
	private Vector2 cameraPos;

	void Start(){
		shouldShow = GameController.tooltip;
		if (toolTip == null) {
			print ("Tooltip not set for tool tip trigger on: " + gameObject.name);
		} 
	}

	public void OnPointerEnter(PointerEventData eventData){
		if (shouldShow) {
			Vector3 pos = new Vector3 (eventData.position.x, eventData.position.y - 140.0f);
			StartHover (pos);
		}
	}

	public void OnSelect(BaseEventData eventData){
		if (shouldShow) {
			StartHover (transform.position);
		}
	}

	public void OnPointerExit(PointerEventData eventData){
		StopHover ();
	}

	public void OnDeselect(BaseEventData eventData){
		StopHover ();
	}

	private void StartHover(Vector3 position){
		ToolTip.Instance.ShowTooltip (text, position);
	}

	private void StopHover(){
		ToolTip.Instance.HideTooltip ();
	}
}
