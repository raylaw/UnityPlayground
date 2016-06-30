using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Framework;

public class LoadingOverlay : GeneralOverlay {

	void Start(){
		//setText ("Hello World");
	}
	
	public void setText(string text){
		Text txt = GetComponentInChildren<Text> ();
		txt.text = text;
	}
}
