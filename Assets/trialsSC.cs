using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class trialsSC : MonoBehaviour {

	[SerializeField] delController DC;

	[Space]
	[SerializeField] private GameObject[] trials;
	private int currentTrial = 0;

	private void Start () {
		resetTrails ();
		DC.decreaseTrial += desAActTrial;
		DC.resetTrial += resetTrails;

		DC.next += resetTrails;

		DC.start += resetTrails;

		DC.repeatLevel += resetTrails;
	}

	private void Update () {
		if (currentTrial >= trials.Length){
			DC.lose ();
			DC.StopTime ();
		}
	
	}


	//--------fn
	void desAActTrial(){
		trials [currentTrial].GetComponent<Image> ().color = Color.red; 
		currentTrial++;
		currentTrial = Mathf.Clamp (currentTrial, 0, trials.Length );
	}

	void resetTrails(){
		for (int i = 0; i < trials.Length; i++) {
			trials [i].GetComponent<Image> ().color = new Color(51,255,0); 
		}
		currentTrial = 0;
	}
}
