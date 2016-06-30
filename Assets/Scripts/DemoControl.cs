using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class DemoControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
		EventTrigger trigger = GetComponent<EventTrigger>( );
		trigger.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void onRollOver(){
		Debug.Log("Hey Men");
	}
}
