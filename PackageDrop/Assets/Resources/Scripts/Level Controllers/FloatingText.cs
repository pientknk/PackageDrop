using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Takes an animation and sets the text to display, and destroys that object after the animation is done.
/// </summary>
public class FloatingText : MonoBehaviour {

	public Animator animator;
	private Text damageText;

	void OnEnable(){
		AnimatorClipInfo[] clipInfo = animator.GetCurrentAnimatorClipInfo (0);
		Destroy (gameObject, clipInfo [0].clip.length);
		damageText = animator.GetComponent<Text> ();
	}

	/// <summary>
	/// Sets the text.
	/// </summary>
	/// <param name="text">Text.</param>
	public void setText(string text){
		damageText.text = text;
	}
}
