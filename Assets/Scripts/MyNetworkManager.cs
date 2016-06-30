using UnityEngine;
using System.Collections;
using System;
using Framework;
using Framework.Event;
using LitJson;

public class MyNetworkManager : NetworkManager {

	void Start(){
		Debug.Log ("MyNetworkManager");
		dataHost = MyGameManager.instance.serverInfo.dataHost;
		//MyGameManager gameManager = MyGameManager.instance as MyGameManager;
		//[{"name":"Hello World","version":"0.0.1","status":"up","id":"576b64d05503a2fefdb32603"}]

		Action<string> onSuccess = (text) => {
			Debug.Log("Success");
			getData(text);
//			Debug.Log (text);
//			var N = JSON.Parse(text);
//			Debug.Log(N.Count);
//			Debug.Log (N[0]["name"].Value);
//			Debug.Log (N[0]["version"].Value);
//			Debug.Log (N[0]["status"].Value);
//			Debug.Log (N[0]["id"].Value);
		};

		Action<string> onError = (error) => {
			Debug.Log("Error");
			if(error.Contains("timed out")){
				
			}else{
				Debug.Log (error);
			}
		};

		//WWWForm form = new WWWForm ();

		StartCoroutine(callAPI ("/api/Apps", null, onSuccess, onError));

	}

	void getData(string text){

		//JsonData N = JsonMapper.ToObject(text);
//		Debug.Log(N.Count);
//		Debug.Log (N[0]["name"]);
//		Debug.Log (N[0]["version"]);
//		Debug.Log (N[0]["status"]);
//		Debug.Log (N[0]["id"]);

	}


}
