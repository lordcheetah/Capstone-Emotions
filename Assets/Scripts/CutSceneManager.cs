using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutSceneManager : MonoBehaviour {
	public enum Characters { LittleSphereOne, LittleSphereTwo};
	public Characters whichChar = Characters.LittleSphereOne;
	public GameObject[] sceneCharacters;

	private const float standTalkTime = 3.0f;
	private float talkTime = standTalkTime;


	private float waitStart = 1.0f;
	private bool bStart = true;

	private bool whichSphereTalking = false;
	private bool SpheresTalking = false;

	private float walkTime = 31f;

	void Update()
	{
		// wait to start animation
		if (bStart)
		{
			waitStart -= Time.deltaTime;
			if (waitStart <= 0) {
				bStart = false;
				SpheresTalking = true;
				sceneCharacters [2].GetComponent<CapsuleTalk> ().Walk ();
			}
		} else
		{
			if (SpheresTalking)
			{ // start talking, they're not talking at regular intervals, but it looks more natural, wish I had done that on purpose
				if (!whichSphereTalking)
				{ // LittleSphereOne talking
					talkTime -= Time.deltaTime;
					if (talkTime <= 0)
					{
						Debug.Log ("One Stop Talking");
						sceneCharacters [0].GetComponent<SphereTalk> ().StopTalking ();
						whichSphereTalking = !whichSphereTalking;
						talkTime = standTalkTime;
						Debug.Log ("Two Start Talking");
						sceneCharacters [1].GetComponent<SphereTalk> ().Talk ();
					}
				} else
				{ // LittleSphereTwo talking
					talkTime -= Time.deltaTime;
					if (talkTime <= 0)
					{
						Debug.Log ("Two Stop Talking");
						sceneCharacters [1].GetComponent<SphereTalk> ().StopTalking ();
						whichSphereTalking = !whichSphereTalking;
						talkTime = standTalkTime;
						Debug.Log ("One Start Talking");
						sceneCharacters [0].GetComponent<SphereTalk> ().Talk ();
					}
				}
				walkTime -= Time.deltaTime;
				if (walkTime <= 0)
				{
					SpheresTalking = false;
					sceneCharacters [0].GetComponent<SphereTalk> ().StopTalking ();
					sceneCharacters [1].GetComponent<SphereTalk> ().StopTalking ();
					sceneCharacters [2].GetComponent<CapsuleTalk> ().Neutral_Angry ();
					sceneCharacters [0].GetComponent<SphereTalk> ().Neutral_Fear ();
					sceneCharacters [1].GetComponent<SphereTalk> ().Neutral_Fear ();
				}
			}
		}
	}
}
