using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCharacter : MonoBehaviour {

	private Animator anim;

	void Start()
	{
		anim = this.GetComponent<Animator> ();
	}

	public void SaveAnim()
	{
		anim.SetTrigger ("Save");
	}
}
