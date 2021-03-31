using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class moneySc : MonoBehaviour {

	[SerializeField] delController DC;
	[SerializeField] private Text textm;
	[Space]
	[SerializeField] private int Money;
	[SerializeField] private int Max = 1000000;

	private void Start () {
		DC.incrementMoney += incrementMoney;
		resetMoney ();
	}

	private void Update () {
		MoneyTostring ();
	}



	//-----fn
	void resetMoney(){
		Money = 0;
	}

	void MoneyTostring(){
		textm.text = Money.ToString();
	}
	void incrementMoney(int amount){
		Money += amount;
		Money = Mathf.Clamp (Money, 0, Max);
	}

}
