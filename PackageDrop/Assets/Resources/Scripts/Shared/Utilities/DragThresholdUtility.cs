using UnityEngine;
using UnityEngine.EventSystems;

public class DragThresh : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int defaultValue = EventSystem.current.pixelDragThreshold;
        EventSystem.current.pixelDragThreshold =
                Mathf.Max(
                     defaultValue,
                     (int)(defaultValue * Screen.dpi / 160f));
    }
}
