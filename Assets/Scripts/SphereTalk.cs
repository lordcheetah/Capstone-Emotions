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
		TalkSound ();
	}

	public void StopTalking()
	{
		audio.Stop ();
		anim.SetTrigger ("StopTalking");
	}

	public void Neutral_Angry()
	{
		anim.SetTrigger ("Neutral_Angry");
		AngrySound ();
	}

	public void Angry_Neutral()
	{
		anim.SetTrigger ("Angry_Neutral");
	}

	public void Neutral_Fear()
	{
		anim.SetTrigger ("Neutral_Fear");
		anim.SetTrigger ("Shake");

		CrySound ();
	}

	public void Fear_Neutral()
	{
		anim.SetTrigger ("Fear_Neutral");
		anim.SetTrigger ("StopShaking");
		//anim.SetTrigger ("StopTalking");
		audio.Stop ();
		audio.clip = null;
	}

	public void StopShaking()
	{
		anim.SetTrigger ("StopShaking");
	}


	public void RunAway()
	{
		anim.SetTrigger ("Run");
	}

	public void TalkSound()
	{
		audio.clip = audioClips [0];
		audio.Play ();
	}

	public void CrySound()
	{
		audio.clip = audioClips [1];
		audio.Play ();
	}

	public void CheerSound()
	{
		audio.PlayOneShot (audioClips [2]);
	}

	public void AngrySound()
	{
		audio.Stop ();
		audio.clip = null;
		audio.PlayOneShot(audioClips [3]);
	}
}
