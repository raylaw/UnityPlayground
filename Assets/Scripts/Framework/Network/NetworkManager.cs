using UnityEngine;
using System;
using System.Collections;
using Framework.Event;

namespace Framework{

	public class NetworkManager : MonoBehaviour {


		private static NetworkManager networkManager;
	
		public static NetworkManager instance
		{
			get
			{
				if (!networkManager)
				{
					networkManager = FindObjectOfType (typeof (NetworkManager)) as NetworkManager;

					if (!networkManager)
					{
						Debug.LogError ("There needs to be one active NetworkManager script on a GameObject in your scene.");
					}
					else
					{
						networkManager.Init (); 
					}
				}

				return networkManager;
			}
		}

		protected string dataHost;

		protected virtual void Init ()
		{
			
		}
			
		protected IEnumerator getServerState(Action<string> onSuccess , Action<string> onError) {
			string url = dataHost;
			WWW www = new WWW(url);
			//yield return StartCoroutine (WaitForTimeout (www , onError));

			var goalTime = Time.time + 10.0;

			while(Time.time < goalTime && !www.isDone){
				yield return null;
			}

			if (Time.time >= goalTime) {
				www.Dispose ();
				onError ("timed out");
			}else if (!string.IsNullOrEmpty (www.error)) {
				onError (www.error);
			} else {
				onSuccess (www.text);
			}
		}

		protected IEnumerator callAPI(string url , WWWForm form , Action<string> onSuccess , Action<string> onError){
			string api = dataHost + url;


			WWW www;

			if (form != null) {
				www = new WWW (api, form);
			} else {
				www = new WWW (api);
			}

			var goalTime = Time.time + 10.0;

			while(Time.time < goalTime && !www.isDone){
				yield return null;
			}

			if (Time.time >= goalTime) {
				www.Dispose ();
				onError ("timed out");
			}else if (!string.IsNullOrEmpty (www.error)) {
				onError (www.error);
			} else {
				onSuccess (www.text);
			}
		}

	
	}

}

