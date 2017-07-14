using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCharacter : MonoBehaviour {

	private Animator anim;

	public Transform target;            // The position that that camera will be following.
	public float smoothing = 5f;        // The speed with which the camera will be following.

	private bool move = false;

	void Start()
	{
		anim = this.GetComponent<Animator> ();
	}

	void Update()
	{
		if (move)
			transform.position = Vector3.Lerp (transform.position, target.position, smoothing * Time.deltaTime);
	}

	public void SaveAnim()
	{
		anim.SetTrigger ("Save");
	}

	public void Normal()
	{
		anim.SetTrigger ("Normal");
	}

	public void Move()
	{
		anim.enabled = false;
		move = true;
	}
}
