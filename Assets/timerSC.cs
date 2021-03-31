using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class timerSC : MonoBehaviour {
	[SerializeField] delController DC;
	[SerializeField]private Text Timertext;
	private bool Count = true;


	private void Start () {
		resetCounter ();
		StopCounter ();
		Timertext.text = tostringTime (sec, min);
		DC.StopTime += StopCounter;

		DC.start += resetCounter;
		DC.start += startCounter;

		DC.next += resetCounter;
		DC.next += startCounter;

		DC.repeatLevel += resetCounter;
		DC.repeatLevel += startCounter;

		DC.endGame += resetCounter;
		DC.endGame += StopCounter;
	}

	private void Update () {
		if (Count) {
			timer ();
			Timertext.text = tostringTime (sec, min);
		}

		if (min >= 1) {
			DC.lose ();
			DC.StopTime ();
		}

	}


	//---fn
	private float sec;
	private float min;
	void timer(){ 
		sec+= Time.deltaTime;
		if (sec >= 59) {
			sec = 0;
			min++;
		}
	}


	void startCounter(){
		Count = true;
	}
	void StopCounter(){
		Count = false;
	}
	void resetCounter(){
		sec = min = 0;
	}

	 string tostringTime(float sec , float min) {
		return string.Format ("{0:00}:{1:00}", min, sec);
	}
}
