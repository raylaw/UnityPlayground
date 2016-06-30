using UnityEngine;
using System;
using System.Collections;
using UnityEngine.Events;
using UnityEngine.EventSystems;

using Framework.Button;

public class ButtonController : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	public void Hey(Generic2DButton obj ,RaycastHit2D hitInfo ){

		SpriteButton target = obj as SpriteButton;
		Debug.Log (target.name+" "+hitInfo.point+" "+target.myState);
		target.whoAmI ();

	}

	public void HelloWorld(object parameter){
		try{
			if (parameter == null) {
				Debug.Log ("NULL");
			}else{
				Debug.Log (((GameObject)parameter).name);
			}
			Debug.Log ("HelloWorld");
		}catch(Exception e){
			Debug.LogError(e);
		}
	}

	public void SayHi(object parameter){
		try{
			if (parameter == null) {
				Debug.Log ("NULL");
			}else{
				Debug.Log (((GameObject)parameter).name);
			}
			Debug.Log ("SayHi");
		}catch(Exception e){
			Debug.LogError (e);
		}
	}
}
