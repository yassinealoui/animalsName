using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class progressBarSc : MonoBehaviour {

	[SerializeField] delController DC;
	[SerializeField] private Image progressImage;

	[Space]
	[SerializeField] int TotalRoundsNb;
	private int roundNb = 0;
	private void Start () {
		resetRoundNb ();
		progressImage.fillAmount = 0;
		DC.next += IncrementRoundNb;


		DC.start += resetRoundNb;
		DC.start += setProgress;
	}

	private void Update () {
		setProgress ();
	}



	//----------fn
	void setProgress(){
		//float to not get the int div
		progressImage.fillAmount = (roundNb-1) /(float)TotalRoundsNb;
	}

	void resetRoundNb(){
		roundNb = 1;
	}

	void IncrementRoundNb(){
		roundNb++;
		//15 to avoid the infinite loop when all sprites of animals are all used
		roundNb = Mathf.Clamp (roundNb, 1, 15);
		check ();
	}

	void check(){
		if (roundNb > TotalRoundsNb) {
			StartCoroutine (wait (0.2f));
		}

	}
	// to not conflict with the "next" delegate
	IEnumerator wait(float time){
		yield return new WaitForSeconds (time);
		DC.endGame ();
	}
}








