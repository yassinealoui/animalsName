using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class starsSC : MonoBehaviour {

	[SerializeField] private GameObject[] stars;
	[SerializeField] delController DC;
	private void Start () {
		DC.SetStars = setStars; 

		DC.start += resetStars;

		DC.repeatLevel += resetStars;
	}
	


	//---fn
	void setStars(int attempts){
		if (attempts == 1) {
			for (int i = 0; i < stars.Length; i++) {
				stars [i].SetActive (true);
			}
			DC.incrementMoney (100);
		} else if (attempts > 1 && attempts < 4) {
			for (int i = 0; i < stars.Length - 1; i++) {
				stars [i].SetActive (true);
			}
			DC.incrementMoney (60);
		} else if (attempts > 3 && attempts < 6) {
			for (int i = 0; i < stars.Length - 2; i++) {
				stars [i].SetActive (true);
			}
			DC.incrementMoney (30);
		} else {
			for (int i = 0; i < stars.Length; i++) {
				stars [i].SetActive (false);
			}
			DC.incrementMoney (10);
		}


	}

	void resetStars(){
		for (int i = 0; i < stars.Length; i++) {
			stars [i].SetActive (false);
		}
		
	}
}
