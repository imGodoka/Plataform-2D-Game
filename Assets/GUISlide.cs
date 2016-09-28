using UnityEngine;
using System.Collections;

public class GUISlide : MonoBehaviour {

	public Texture2D swImage;

	// Use this for initialization
	void OnGui(){
		GUI.DrawTexture (new Rect (0, 0, Screen.currentResolution.width, Screen.currentResolution.height / 4), swImage);
	}
}
