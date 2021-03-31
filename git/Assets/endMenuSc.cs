using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class endMenuSc : MonoBehaviour {

	[SerializeField] delController DC;
	[Space]
	[Header("animation")]
	[SerializeField]private float duration = 1;
	[SerializeField]private LeanTweenType easeTypeAct;
	[SerializeField]private float add = 360;
	private void Start () {
		DC.endGame += ActivateAnim;

		DC.start += DesActivateAnim;
	}

	//------------fn
	//animation
	void ActivateAnim(){
		LeanTween.scale (gameObject, Vector3.one, duration)
			.setEase (easeTypeAct);

		LeanTween.rotateAround (gameObject,
			new Vector3 (0, 0,1), add, duration)
			.setEase (easeTypeAct);

		DC.StopTime ();
	}

	void DesActivateAnim(){
		LeanTween.scale (gameObject, Vector3.zero , duration)
			.setEase (easeTypeAct);

		LeanTween.rotateAround (gameObject,
			new Vector3 (0, 0,1), -add, duration)
			.setEase (easeTypeAct);
		
	}

	public void exit(){
		print ("exit");
		Application.Quit ();
	}

}
