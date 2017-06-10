using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereTalk : MonoBehaviour {
	private Animator anim;
	private float talkTime = 3.0f;

	void Start()
	{
		anim = this.GetComponent<Animator> ();

		Talk ();
		Neutral_Fear ();
	}

	void Update()
	{
		talkTime -= Time.deltaTime;
		if (talkTime <= 0)
		{
			Fear_Neutral ();
			StopTalking ();
		}
	}

	void Talk()
	{
		anim.SetTrigger ("Talk");
	}

	void StopTalking()
	{
		anim.SetTrigger ("StopTalking");
	}

	void Neutral_Angry()
	{
		anim.SetTrigger ("Neutral_Angry");
	}

	void Angry_Neutral()
	{
		anim.SetTrigger ("Angry_Neutral");
	}

	void Neutral_Fear()
	{
		anim.SetTrigger ("Neutral_Fear");
		anim.SetTrigger ("Shake");
	}

	void Fear_Neutral()
	{
		anim.SetTrigger ("Fear_Neutral");
		anim.SetTrigger ("StopShaking");
	}
}
