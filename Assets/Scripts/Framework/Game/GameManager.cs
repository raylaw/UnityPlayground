using UnityEngine;
using System.Collections;

namespace Framework{
	
	public class GameManager : MonoBehaviour {

		private static GameManager gameManager;

		public static GameManager instance
		{
			get
			{
				if (!gameManager)
				{
					gameManager = FindObjectOfType (typeof (GameManager)) as GameManager;

					if (!gameManager)
					{
						Debug.LogError ("There needs to be one active GameManger script on a GameObject in your scene.");
					}
					else
					{
						gameManager.Init (); 
					}
				}

				return gameManager;
			}
		}
			
		public Setting gameSetting;

		[HideInInspector]
		public ServerInfo serverInfo;

		protected virtual void Init ()
		{
			Debug.Log ("Game Manager Init");
			if (gameSetting.gameInfo.state == GameState.development) {
				serverInfo = gameSetting.devServerInfo;
			} else {
				serverInfo = gameSetting.prodServerInfo;
			}

			//Debug.Log (serverInfo.dataHost);
		}

		void Awake() {
			DontDestroyOnLoad(transform.gameObject);
		}

		public virtual void sayHi(){
			Debug.Log ("Hi");
		}
			
	}

}
