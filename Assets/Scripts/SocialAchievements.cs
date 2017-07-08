using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SocialAchievements : MonoBehaviour {
	public Canvas canvas;
	public Text text;
	public CutSceneManager csm;
	private static bool helpAchievement = false;
	private static bool scaredAchievement = false;
	private static bool mehAchievement = false;

	void Start () {
		canvas.gameObject.SetActive(false);
	}

	public void UnlockHelpAchievement()
	{
		/*if (!csm.readyChoose)
			return;*/
		StartCoroutine (HelpAchievement());
	}

	IEnumerator HelpAchievement()
	{
		Debug.Log ("Help Ach");
		if (helpAchievement)
		{
			csm.Reset ();
			yield break;
		}

		helpAchievement = true;

		text.text = "Help Achievement\n\nYou helped the little spheres!";
		canvas.gameObject.SetActive(true);
		yield return new WaitForSeconds(5);
		canvas.gameObject.SetActive(false);
		csm.Reset ();
	}

	public void UnlockScaredAchievement()
	{
		/*if (!csm.readyChoose)
			return;*/
		StartCoroutine (ScaredAchievement());
	}

	IEnumerator ScaredAchievement()
	{
		Debug.Log ("Scared Ach");
		if (scaredAchievement)
		{
			csm.Reset ();
			yield break;
		}

		scaredAchievement = true;

		text.text = "Scared Achievement\n\nYou scared the little spheres. What's wrong with you? Try again.";
		canvas.gameObject.SetActive(true);
		yield return new WaitForSeconds(5);
		canvas.gameObject.SetActive(false);
		csm.Reset ();
	}

	public void UnlockMehAchievement()
	{
		/*if (!csm.readyChoose)
			return;*/
		StartCoroutine (MehAchievement());
	}

	IEnumerator MehAchievement()
	{

		Debug.Log ("Meh Ach");
		if (mehAchievement)
		{
			csm.Reset ();
			yield break;
		}

		mehAchievement = true;

		text.text = "Meh Achievement\n\nYou ignored the little spheres. What are you doing? Go back and help them!";
		canvas.gameObject.SetActive(true);
		yield return new WaitForSeconds(5);
		canvas.gameObject.SetActive(false);
		csm.Reset ();
	}
}