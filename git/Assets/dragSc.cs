using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI.Extensions;
using UnityEngine.UI;

public class dragSc : MonoBehaviour ,IBeginDragHandler,IEndDragHandler,IDragHandler{
	public bool isDropped = false;
	public string ImageName;

	[SerializeField] delController DC;
	[SerializeField] private Canvas canvas;

	[SerializeField] public UILineRenderer Line;
	private RectTransform tr;


	[SerializeField] private Texture2D AnimalsTexture;
	private Sprite[] sprites;
	void Start(){
		repeatFn ();
		tr = GetComponent<RectTransform> ();
		ImageName = GetComponent<Image> ().sprite.name;
		sprites = Resources.LoadAll<Sprite> (AnimalsTexture.name);

		DC.repeat += repeatFn;

		DC.next += repeatFn;

		DC.start += repeatFn;

		DC.repeatLevel += repeatFn;
	}

	void Update(){
		ImageName = GetComponent<Image> ().sprite.name;
	}

//----functions
	void repeatFn(){
		isDropped = false;
		Line.Points [1] = Line.Points [0] = Vector2.zero;
		Line.GetComponent<UILineRenderer> ().enabled = false;
	}
	
	

	public void OnBeginDrag (PointerEventData eventData){
		//not control it when its succesfully attached
		if (!isDropped) {
			Line.GetComponent<UILineRenderer> ().enabled = true;
			Line.Points [0] = tr.position / canvas.scaleFactor;
		}
		
	}

	public void OnDrag (PointerEventData eventData){
		if (!isDropped) {
			Line.Points [1] = (Vector2)(Input.mousePosition / canvas.scaleFactor);
		}
		Line.LineThickness = 30;
	}

		public void OnEndDrag (PointerEventData eventData){
		
		if (!isDropped) {
			Line.Points [1] = Line.Points [0] = Vector2.zero;
			Line.GetComponent<UILineRenderer> ().enabled = false;
		}

	}

	
}
