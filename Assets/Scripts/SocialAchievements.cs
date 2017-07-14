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
	private static bool allEndingsAchievement = false;

	void Start () {
		canvas.gameObject.SetActive(false);
	}

	public void UnlockHelpAchievement()
	{
		StartCoroutine (HelpAchievement());
	}

	IEnumerator HelpAchievement()
	{
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
		UnlockAllEndingsAchievement ();
	}

	public void UnlockScaredAchievement()
	{
		StartCoroutine (ScaredAchievement());
	}

	IEnumerator ScaredAchievement()
	{
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
		UnlockAllEndingsAchievement ();
	}

	public void UnlockMehAchievement()
	{
		StartCoroutine (MehAchievement());
	}

	IEnumerator MehAchievement()
	{
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
		UnlockAllEndingsAchievement ();
	}

	public void UnlockAllEndingsAchievement()
	{
		StartCoroutine (AllEndingsAchievement());
	}

	IEnumerator AllEndingsAchievement()
	{
		if(!helpAchievement || !mehAchievement || !scaredAchievement || allEndingsAchievement)
		{
			csm.Reset ();
			yield break;
		}

		allEndingsAchievement = true;

		text.text = "All Endings Achievement\n\nYou've found all the endings!";
		canvas.gameObject.SetActive(true);
		yield return new WaitForSeconds(5);
		canvas.gameObject.SetActive(false);
		//csm.Reset ();
	}
}