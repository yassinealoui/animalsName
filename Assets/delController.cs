using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class delController : MonoBehaviour {


	//--- start
	public delegate void startDelType ();
	public startDelType start;

	//--repeat
	public delegate void repeatDelType ();
	public repeatDelType repeat;

	//--attempts delegates
	public delegate void incrementAttDelType ();
	public incrementAttDelType incrementAtt;

	public delegate void initDelType ();
	public initDelType rezroAtt;
	//--correct choices delegates
	public delegate void incrementCCDelType ();
	public incrementCCDelType incrementCC;

	public delegate void restCCDelType ();
	public restCCDelType resetCC;
	//-timer del
	public delegate void StopTimeDelType ();
	public StopTimeDelType StopTime;
	//- star del
	public delegate void SetStarsDelType (int attempts);
	public SetStarsDelType SetStars;
	//--trials
	public delegate void decreaseTrialDelType ();
	public decreaseTrialDelType decreaseTrial;
	public delegate void resetTrialDelType ();
	public resetTrialDelType resetTrial;
	//---lose
	public delegate void loseDelType ();
	public loseDelType lose;

	//--increment money
	public delegate void IncrementMoneyDelType (int amount);
	public IncrementMoneyDelType incrementMoney;

	//---next round
	public delegate void nextDelType ();
	public nextDelType next;


	//---endgamemenu
	public delegate void endGameDelType ();
	public endGameDelType endGame;

	//--repeat
	public delegate void repeatLevelDelType ();
	public repeatLevelDelType repeatLevel;
}
