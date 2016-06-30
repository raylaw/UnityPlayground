using UnityEngine;
using System.Collections;
using Framework;

public class HomeSceneManager :SceneManager{

	// Use this for initialization
	void Start () {
		//Debug.Log ("Connect server...");
		//StartCoroutine(login("raylaw","12345"));
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	 
	IEnumerator getServerState() {
		Debug.Log("getServerState...");
		string url = "http://raylawplayground.eastasia.cloudapp.azure.com:8080/";
		WWW www = new WWW(url);
		yield return www;

		Debug.Log (www.text);
	}


	IEnumerator login(string username , string password){
		string url = "http://raylawplayground.eastasia.cloudapp.azure.com:8080/api/Users/login";

		Debug.Log("login...");
		WWWForm form = new WWWForm();
		form.AddField("username", username);
		form.AddField("password", password);

		WWW www = new WWW(url,form);
		yield return www;

		if (www.error == null)
		{
			Debug.Log("WWW Ok!: " + www.text);
		} else {
			Debug.Log("WWW Error: "+ www.error);
		}    

	}
}
