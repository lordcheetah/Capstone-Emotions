using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereTalk : MonoBehaviour
{
	private Animator anim;
	private GvrAudioSource audio;

	public AudioClip[] audioClips;

	void Start()
	{
		anim = this.GetComponent<Animator> ();
		audio = this.GetComponent<GvrAudioSource> ();
	}

	public void Talk()
	{
		anim.SetTrigger ("Talk");
		audio.clip = audioClips [0];
		audio.Play ();
	}

	public void StopTalking()
	{
		audio.Stop ();
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

		audio.clip = audioClips [1];
		audio.Play ();
	}

	public void Fear_Neutral()
	{
		anim.SetTrigger ("Fear_Neutral");
		anim.SetTrigger ("StopShaking");
		anim.SetTrigger ("StopTalking");
	}
}
