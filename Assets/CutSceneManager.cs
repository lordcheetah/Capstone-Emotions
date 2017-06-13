using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutSceneManager : MonoBehaviour {
	public enum Characters { LittleSphereOne, LittleSphereTwo};
	public Characters whichChar = Characters.LittleSphereOne;
	public GameObject[] sceneCharacters;

	private const float standTalkTime = 3.0f;
	private float talkTime = standTalkTime;


	private float waitStart = 5.0f;
	private bool bStart = true;

	private bool whichSphereTalking = false;
	private bool SpheresTalking = false;


	void Update()
	{
		// wait to start animation
		if (bStart) {
			waitStart -= Time.deltaTime;
			if (waitStart <= 0) {
				bStart = false;
				SpheresTalking = true;
			}
		} else
		{
			// Start talking
			if (SpheresTalking)
				if (!whichSphereTalking)
				{
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
				}
				else
				{
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
		}
	}
}
