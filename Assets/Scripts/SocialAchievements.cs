using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SocialAchievements : MonoBehaviour {
	public Canvas canvas;
	public Text text;
	public CutSceneManager csm;
	private bool helpAchievement = false;
	private bool scaredAchievement = false;
	private bool mehAchievement = false;

	void Start () {
		canvas.gameObject.SetActive(false);
	}

	public void UnlockHelpAchievement()
	{
		if (!csm.enableChoice)
			return;
		StartCoroutine (HelpAchievement());
	}

	IEnumerator HelpAchievement()
	{
		Debug.Log ("Help Ach");
		if (helpAchievement)
			yield break;

		helpAchievement = true;

		text.text = "Help Achievement\n\nYou helped the little spheres!";
		canvas.gameObject.SetActive(true);
		yield return new WaitForSeconds(5);
		canvas.gameObject.SetActive(false);
	}

	public void UnlockScaredAchievement()
	{
		if (!csm.enableChoice)
			return;
		StartCoroutine (ScaredAchievement());
	}

	IEnumerator ScaredAchievement()
	{
		Debug.Log ("Scared Ach");
		if (scaredAchievement)
			yield break;

		scaredAchievement = true;

		text.text = "Scared Achievement\n\nYou scared the little spheres. What's wrong with you? Try again.";
		canvas.gameObject.SetActive(true);
		yield return new WaitForSeconds(5);
		canvas.gameObject.SetActive(false);
	}

	public void UnlockMehAchievement()
	{
		if (!csm.enableChoice)
			return;
		StartCoroutine (MehAchievement());
	}

	IEnumerator MehAchievement()
	{

		Debug.Log ("Meh Ach");
		if (mehAchievement)
			yield break;

		mehAchievement = true;

		text.text = "Meh Achievement\n\nYou ignored the little spheres. What are you doing? Go back and help them!";
		canvas.gameObject.SetActive(true);
		yield return new WaitForSeconds(5);
		canvas.gameObject.SetActive(false);
	}
}