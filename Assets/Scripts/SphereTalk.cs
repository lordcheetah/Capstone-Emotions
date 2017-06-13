using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereTalk : MonoBehaviour
{
	private Animator anim;

	void Start()
	{
		anim = this.GetComponent<Animator> ();
	}

	public void Talk()
	{
		anim.SetTrigger ("Talk");
	}

	public void StopTalking()
	{
		anim.SetTrigger ("StopTalking");
	}

	public void Neutral_Angry()
	{
		anim.SetTrigger ("Neutral_Angry");
	}

	public void Angry_Neutral()
	{
		anim.SetTrigger ("Angry_Neutral");
	}

	public void Neutral_Fear()
	{
		anim.SetTrigger ("Neutral_Fear");
		anim.SetTrigger ("Shake");
	}

	public void Fear_Neutral()
	{
		anim.SetTrigger ("Fear_Neutral");
		anim.SetTrigger ("StopShaking");
	}
}
