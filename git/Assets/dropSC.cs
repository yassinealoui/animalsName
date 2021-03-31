using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI.Extensions;
using UnityEngine.UI;
public class dropSC : MonoBehaviour ,IDropHandler {
	[SerializeField] private Canvas canvas;
	[SerializeField] delController DC;
	private string TextName;


	public void OnDrop (PointerEventData eventData){
		if (eventData.pointerDrag != null) {
			dragSc lineSc = 
				eventData.pointerDrag
					.GetComponent<dragSc> ();
			if (!lineSc.isDropped) {

				TextName = GetComponent<Text> ().text;
				//if the name matches the true card
				if (TextName == lineSc.ImageName) {
					print ("droped suscess");
					//dropped successfully
					lineSc.isDropped = true;
					lineSc.Line.enabled = true;
					lineSc.Line.Points [1] 
					= this.GetComponent<RectTransform> ().position / canvas.scaleFactor;
					DC.incrementCC ();
				} else {

					//attempts
					DC.repeat ();
					DC.incrementAtt ();
					//rest correct choices
					DC.resetCC ();
					// trials
					DC.decreaseTrial ();


					if (!lineSc.isDropped) {
						lineSc.Line.Points [1] 
							= lineSc.Line.Points [0]
								= Vector2.zero;
						lineSc.Line.enabled = false;
			
					}
				}
			}

		}
	}

}
