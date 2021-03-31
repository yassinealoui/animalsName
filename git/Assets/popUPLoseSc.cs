using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class popUPLoseSc : MonoBehaviour {

	[SerializeField] delController DC;
	[Space]
	[Header("animation")]
	[SerializeField]private float duration = 1;
	[SerializeField]private float delay = 1;
	[SerializeField]private LeanTweenType easeTypeAct;
	[SerializeField]private LeanTweenType easeTypeDesAct;

	void Start () {
		DC.lose += ActivateAnim;
		DC.start += DesActivateAnim;

	}
		


	//-----fn
	void ActivateAnim(){
		LeanTween.scale (gameObject, Vector3.one, duration)
			.setEase(easeTypeAct);
	}
	void DesActivateAnim(){
		LeanTween.scale (gameObject, Vector3.zero, duration).setEase(easeTypeDesAct);
	}
}
