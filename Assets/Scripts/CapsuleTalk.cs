using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleTalk : MonoBehaviour {

	private Animator anim;

	void Start()
	{
		anim = this.GetComponent<Animator> ();
	}

	public void Walk()
	{
		anim.SetTrigger ("Walk");
	}

	public void Neutral_Angry()
	{
		anim.SetTrigger ("Neutral_Angry");
	}

	public void Angry_Neutral()
	{
		anim.SetTrigger ("Angry_Neutral");
	}
}
