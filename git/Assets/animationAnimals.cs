using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationAnimals : MonoBehaviour {
	[SerializeField] delController DC;

	[Space]
	[Header("animation")]
	[SerializeField]private float duration = 1;
	[SerializeField]private float add = 360;
	[SerializeField]private float delay = 0;
	[SerializeField]private LeanTweenType easeTypeAct;
	void Start () {
		DC.start += ActivateAnim;
		DC.next += ActivateAnim;

		DC.repeatLevel += ActivateAnim;
	}

	void ActivateAnim(){
		LeanTween.rotateAround(gameObject,
			new Vector3(0,1,0),add,duration)
			.setEase(easeTypeAct).setDelay(delay);
	}

}
