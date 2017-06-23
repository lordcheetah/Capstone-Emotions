using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleTalk : MonoBehaviour {

	private Animator anim;
	private GvrAudioSource audio;

	void Start()
	{
		anim = this.GetComponent<Animator> ();
		audio = this.GetComponent<GvrAudioSource> ();
	}

	public void Walk()
	{
		anim.SetTrigger ("Walk");
	}

	public void Neutral_Angry()
	{
		anim.SetTrigger ("Neutral_Angry");
		audio.Play ();
	}

	public void Angry_Neutral()
	{
		anim.SetTrigger ("Angry_Neutral");
	}
}
