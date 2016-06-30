using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

namespace Framework{

	public class SceneManager : MonoBehaviour {

		// Use this for initialization
		void Start () {

		}

		// Update is called once per frame
		void Update () {

		}

		public virtual void OnButtonClick(string name){
			Debug.Log (name);
			UnityEngine.SceneManagement.SceneManager.LoadScene("Register");
		}
	}

}
