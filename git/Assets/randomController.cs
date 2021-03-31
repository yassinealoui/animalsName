using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class randomController : MonoBehaviour {

	[SerializeField] delController DC;

	[SerializeField] private Texture2D AnimalsTexture;
	private Sprite[] sprites;

	[SerializeField] private GameObject[] SceneImages;
	[SerializeField] private GameObject[] SceneTextes;

	private List<int> usedImagesId = new List<int> (); 

	void Start(){
		sprites = Resources.LoadAll<Sprite> (AnimalsTexture.name);


		DC.next += randomize;

		DC.start += randomize; 
		DC.start += resetRandomize ;

	}

	//------fn
	void randomize(){
			List<int> used = new List<int> (); 
			int randImageId = -1;
			int rand = -1;
			for (int i = 0; i < SceneImages.Length; i++) {
				//rand images
				do {
					randImageId = Random.Range (0, sprites.Length);
				} while(usedImagesId.Contains (randImageId));
				usedImagesId.Add (randImageId);
				
				//set text
				SceneTextes [i].GetComponent<Text> ().text 
				= sprites [randImageId].name; 

				do {
					rand = Random.Range (0, SceneImages.Length);
				} while(used.Contains (rand));
				used.Add (rand);

				//set images
				SceneImages [rand].GetComponent<Image> ().sprite 
				= sprites [randImageId];
			}
			
	}

	void resetRandomize(){
		usedImagesId.Clear();
	}
}
