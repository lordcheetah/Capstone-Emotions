using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunawayMove : MonoBehaviour
{
	private Animator anim;
	private GvrAudioSource audio;

	public AudioClip[] audioClips;

	// Use this for initialization
	void Start () {
		anim = this.GetComponent<Animator> ();
		audio = this.GetComponent<GvrAudioSource> ();
	}

	public void Pulse()
	{
		anim.SetTrigger ("Pulse");
	}

	public void StopPulse()
	{
		anim.SetTrigger ("StopPulse");
	}

	public void RunawaySound()
	{
		audio.PlayOneShot (audioClips[0]);
	}
}
