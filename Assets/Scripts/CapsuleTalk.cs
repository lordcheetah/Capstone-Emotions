using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleTalk : MonoBehaviour {

	private Animator anim;
	private GvrAudioSource audio;

	public AudioClip[] audioClips;

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
		AngrySound ();
	}

	public void Angry_Neutral()
	{
		anim.SetTrigger ("Angry_Neutral");
	}

	public void Neutral_Fear()
	{
		anim.SetTrigger ("Neutral_Fear");
		//anim.SetTrigger ("Shake");
		CrySound ();
	}

	public void Fear_Neutral()
	{
		anim.SetTrigger ("Fear_Neutral");
		//anim.SetTrigger ("StopShaking");
		//anim.SetTrigger ("StopTalking");
		audio.Stop ();
	}

	public void AngrySound()
	{
		audio.clip = audioClips [0];
		audio.Play ();
	}

	public void MuahaSound()
	{
		audio.PlayOneShot (audioClips [1]);
	}

	public void CrySound()
	{
		audio.clip = audioClips [2];
		audio.Play ();
	}
}
