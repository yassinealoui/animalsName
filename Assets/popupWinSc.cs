using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class popupWinSc : MonoBehaviour {
	
	[SerializeField] delController DC;

	[SerializeField]private int correctChoices = 0;
	[SerializeField] private int attempts = 1;

	[Space]
	[Header("animation")]
	[SerializeField]private float duration = 1;
	[SerializeField]private float Actdelay = 1;
	[SerializeField]private LeanTweenType easeTypeAct;
	[SerializeField]private float DesActdelay = 1;
	[SerializeField]private LeanTweenType easeTypeDesAct;
	[Space]
	//repeatbutton
	[SerializeField]private GameObject repeatB;


	private void Start(){
		resetCC ();
		DC.resetCC += resetCC ;
		DC.incrementCC += incrementCC;
		DC.incrementAtt += incrementAttempts;
		DC.rezroAtt += resetAttempts;


		DC.next += resetAttempts;
		DC.next += DesActivateAnim; 

		DC.start += DesActivateAnim;
		DC.start += resetCC;
		DC.start += resetAttempts;


		DC.repeatLevel +=DesActivateAnim;
		DC.repeatLevel += resetCC;
		DC.repeatLevel += resetAttempts;
	}

	private void Update(){
		if (correctChoices >= 3) {
			resetCC ();
			ActivateAnim ();
			DC.StopTime();
			DC.SetStars (attempts);
			ActDesActRepeatButton ();
		}

	}


	//----corect choices
	void incrementCC(){
		correctChoices += 1;
	}
	void resetCC(){
		correctChoices =0;
	}
	//---animation
	void ActivateAnim(){
		LeanTween.scale (gameObject, Vector3.one, duration)
			.setEase(easeTypeAct).setDelay(Actdelay);
	}
	void DesActivateAnim(){
		LeanTween.scale (gameObject, Vector3.zero, duration)
			.setEase(easeTypeDesAct).setDelay(DesActdelay);
	}
	//----attempts
	private void incrementAttempts(){
		attempts += 1;
	}
	private void resetAttempts(){
		attempts =1;
	}

	//---Button
	public void repeatLevel(){
		DC.repeatLevel ();
	}

	public void next(){
		DC.next ();
		//waiting to not change the stars while the desacivation animation is playing 
		StartCoroutine (wait (duration));
	}


	IEnumerator wait(float time){
		yield return new WaitForSeconds (time);
		//7 to desactivate all stars
		DC.SetStars (7);
	}


	void ActDesActRepeatButton(){
		if (attempts == 1) {
			repeatB.SetActive (false);
		} else {
			repeatB.SetActive (true);
		}

	}

}
