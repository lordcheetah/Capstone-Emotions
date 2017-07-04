using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutSceneManager : MonoBehaviour {
	public enum Characters { LittleSphereOne, LittleSphereTwo};
	public Characters whichChar = Characters.LittleSphereOne;
	public GameObject[] sceneCharacters;
	public SocialAchievements sa;

	private const float standTalkTime = 3.0f;
	private float talkTime = standTalkTime;


	private float waitStart = 1.0f;
	private bool bStart = true;

	private bool whichSphereTalking = false;
	private bool SpheresTalking = false;

	private float walkTime = 33f;

	private bool bFear = false;
	private float waitTime = .5f;

	public bool readyChoose = false;

	private int chosen = 0;

	private float saveWait = 2f;
	private bool bSaveWait = false;
	private float saveWait2 = 3f;
	private bool bSaveWait2 = false;

	private float hurtWait = 3f;
	private bool bHurtWait = false;

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
			if (SpheresTalking) { // start talking, they're not talking at regular intervals, but it looks more natural, wish I had done that on purpose
				if (!whichSphereTalking) { // LittleSphereOne talking
					talkTime -= Time.deltaTime;
					if (talkTime <= 0) {
						//Debug.Log ("One Stop Talking");
						sceneCharacters [0].GetComponent<SphereTalk> ().StopTalking ();
						whichSphereTalking = !whichSphereTalking;
						talkTime = standTalkTime;
						//Debug.Log ("Two Start Talking");
						sceneCharacters [1].GetComponent<SphereTalk> ().Talk ();
					}
				} else { // LittleSphereTwo talking
					talkTime -= Time.deltaTime;
					if (talkTime <= 0) {
						//Debug.Log ("Two Stop Talking");
						sceneCharacters [1].GetComponent<SphereTalk> ().StopTalking ();
						whichSphereTalking = !whichSphereTalking;
						talkTime = standTalkTime;
						//Debug.Log ("One Start Talking");
						sceneCharacters [0].GetComponent<SphereTalk> ().Talk ();
					}
				}
				walkTime -= Time.deltaTime;
				if (walkTime <= 0)
				{ // Bully
					SpheresTalking = false;
					sceneCharacters [0].GetComponent<SphereTalk> ().StopTalking ();
					sceneCharacters [1].GetComponent<SphereTalk> ().StopTalking ();
					sceneCharacters [2].GetComponent<CapsuleTalk> ().Neutral_Angry ();
					bFear = true;
				}
			} else
			{
				if (bFear)
				{
					waitTime -= Time.deltaTime;
					if (waitTime <= 0)
					{ // cry
						sceneCharacters [0].GetComponent<SphereTalk> ().Neutral_Fear ();
						sceneCharacters [1].GetComponent<SphereTalk> ().Neutral_Fear ();
						bFear = false;
						sceneCharacters [3].SetActive (true);
						readyChoose = true;
						bSaveWait = true;
					}
				} else
				{
					switch (chosen) // It's the choices we make
					{
						case 1: // Save the spheres
							if (bSaveWait)
							{
								saveWait -= Time.deltaTime;
								if (saveWait <= 0)
								{
									sceneCharacters [0].GetComponent<SphereTalk> ().Neutral_Angry ();
									sceneCharacters [1].GetComponent<SphereTalk> ().Neutral_Angry ();
									sceneCharacters [2].GetComponent<CapsuleTalk> ().Neutral_Fear ();
									sceneCharacters [4].GetComponent<CameraCharacter> ().SaveAnim ();
									bSaveWait = false;
									bSaveWait2 = true;
								}
							} else if (bSaveWait2)
							{
								saveWait2 -= Time.deltaTime;
								if (saveWait2 <= 0)
								{
									sceneCharacters[0].GetComponent<SphereTalk>().CheerSound();
									//readyChoose = true;
									sa.UnlockHelpAchievement ();
									bSaveWait2 = false;
								}
							}
							break;
						case 2: // Bully the spheres
							if (bHurtWait)
							{
								hurtWait -= Time.deltaTime;
								if (hurtWait <= 0)
								{
									sceneCharacters[2].GetComponent<CapsuleTalk>().MuahaSound();
									sa.UnlockScaredAchievement ();
									bHurtWait = false;
								}
							}
							break;
						case 3: // Exit not so gracefully
							break;
					}
				}
			}
		}
	}

	public void OnHoverLittleSphere()
	{  //muahahaha
		if (!readyChoose)
			return;
		sceneCharacters[2].GetComponent<CapsuleTalk>().MuahaSound();
	}

	public void OnHoverBigCapsule()
	{ //cheer
		if (!readyChoose)
			return;
		sceneCharacters[0].GetComponent<SphereTalk>().CheerSound();
	}

	public void OnHoverRunAway()
	{ // runawayrunway
		if (!readyChoose)
			return;
		sceneCharacters[3].GetComponent<GvrAudioSource>().Play();
	}

	public void OnClickLittleSphere()
	{ // Give in to the Dark Side
		if (!readyChoose)
			return;
		readyChoose = false;
		chosen = 2;
		sceneCharacters [4].GetComponent<CameraCharacter> ().SaveAnim ();
		sceneCharacters [3].SetActive (false);
		bHurtWait = true;
	}

	public void OnClickBigCapsule()
	{ //Help the little buggers
		if (!readyChoose)
			return;
		readyChoose = false;
		chosen = 1;
		sceneCharacters [0].GetComponent<SphereTalk> ().Fear_Neutral ();
		sceneCharacters [1].GetComponent<SphereTalk> ().Fear_Neutral ();
		sceneCharacters [2].GetComponent<CapsuleTalk> ().Angry_Neutral ();
		sceneCharacters [3].SetActive (false);
	}

	public void OnClickRunAway()
	{ // Bravely run away, away
		if (!readyChoose)
			return;
		readyChoose = false;
		chosen = 3;
		sceneCharacters[3].GetComponent<GvrAudioSource>().Play();
	}

	void Reset()
	{

	}
}
