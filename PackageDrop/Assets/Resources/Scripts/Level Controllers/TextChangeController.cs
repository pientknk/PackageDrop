using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Controls how text used with this script will slowly change rather than jump to another value. Useful for money earned and money the user has.
/// </summary>
public class TextChangeController : MonoBehaviour {

	private Text label;
	private int initialValue;
	private int finalValue;
	/// <summary>
	/// The duration of time it takes for the text to change from value a to b.
	/// </summary>
	private float duration = 150.0f;
	private float timeElapsed;
	private bool addedDif = false;

	/// <summary>
	/// assignes a Text element, with an initial and final value.
	/// </summary>
	/// <param name="textLabel">Text label.</param>
	/// <param name="initial">Initial.</param>
	/// <param name="final">Final.</param>
	public void Create(Text textLabel, int initial, int final){
		label = textLabel;
		initialValue = initial;
		finalValue = final;
		duration += Time.realtimeSinceStartup;
	}
	
	// Update is called once per frame
	void Update () {
		timeElapsed += Time.realtimeSinceStartup;
		if (timeElapsed > duration) {
			label.text = finalValue.ToString ();
			Destroy (this);
		} else {
			if (!addedDif) {
				float valDif = Mathf.Abs (initialValue - finalValue);
				duration += valDif;
				addedDif = true;
			}
			float value = Mathf.Lerp (initialValue, finalValue, (timeElapsed / duration));
			label.text = value.ToString ("####");
		}
	}
}
