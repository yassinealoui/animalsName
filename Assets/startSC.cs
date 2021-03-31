using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startSC : MonoBehaviour {
	[SerializeField] delController DC;

	[Space]
	[Header("animation")]
	[SerializeField]private float duration = 1;
	[SerializeField]private float Actdelay = 1;
	[SerializeField]private LeanTweenType easeTypeAct;
	[SerializeField]private float DesActdelay = 1;
	[SerializeField]private LeanTweenType easeTypeDesAct;


	private void Start () {
		ActivateAnim ();
		DC.start += DesActivateAnim;
	}
		

	//----fn
	//animation
	void ActivateAnim(){
		LeanTween.scale (gameObject, Vector3.one, duration)
			.setEase(easeTypeAct).setDelay(Actdelay);
	}
	void DesActivateAnim(){
		LeanTween.scale (gameObject, Vector3.zero, duration)
			.setEase(easeTypeDesAct).setDelay(DesActdelay);
	}

	//button
	public void startFn(){
		DC.start ();
	}

}
