using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

/// <summary>
/// Allows any panel to be drug around on the screen using pointer and drag handlers
/// </summary>
public class DragPanel : MonoBehaviour, IPointerDownHandler, IDragHandler {

	private Vector2 pointerOffset;
	private RectTransform canvasRectTransform;
	private RectTransform panelRectTransform;

	void Start () {
		GameObject canvas = LevelController.instance.canvas;

		if (canvas != null) {
			canvasRectTransform = canvas.transform as RectTransform;
			panelRectTransform = transform.parent as RectTransform;
		}
	}

	public void OnPointerDown (PointerEventData data) {
		panelRectTransform.SetAsLastSibling ();
		RectTransformUtility.ScreenPointToLocalPointInRectangle (panelRectTransform, data.position, data.pressEventCamera, out pointerOffset);
	}

	public void OnDrag (PointerEventData data) {
		if (this.tag == "inventory") {
			if (panelRectTransform == null)
				return;

			Vector2 pointerPostion = data.position;
			Vector2 localPointerPosition;
			if (RectTransformUtility.ScreenPointToLocalPointInRectangle (
				canvasRectTransform, pointerPostion, data.pressEventCamera, out localPointerPosition
			)) {
				panelRectTransform.localPosition = localPointerPosition - pointerOffset;
			}
		} else {
			
				if (panelRectTransform == null)
					return;

			Vector2 pointerPostion = data.position;

				Vector2 localPointerPosition;
				if (RectTransformUtility.ScreenPointToLocalPointInRectangle (
				     canvasRectTransform, pointerPostion, data.pressEventCamera, out localPointerPosition
			     )) {
				
				panelRectTransform.localPosition = localPointerPosition - pointerOffset;
			}
		}

	}
}