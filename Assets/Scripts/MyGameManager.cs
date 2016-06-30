using UnityEngine;
using System.Collections;
using Framework;

public class MyGameManager : GameManager {

	public LoadingOverlay loadingPrefab;
	public GameObject popUpGroup;

	private LoadingOverlay loading;

	protected override void Init ()
	{
		Debug.Log ("My Game Manager Init");
		base.Init ();

		//Debug.Log (serverInfo.dataHost);
	}

	void Start(){
		//loading.setText ("YEAH YEAH YEAH");
		//loading.Hide ();
		//loading.Show (0.5f,0.2f, null);

		//ShowLoading ("Connection server...");

		//StartCoroutine(step2(2));

	}

	IEnumerator step2(float delay){
		yield return new WaitForSeconds(delay);
		ShowLoading ("Step1");

		yield return new WaitForSeconds(delay);
		ShowLoading ("Step2");

		yield return new WaitForSeconds(delay);
		ShowLoading ("Step3");
	}

	void ShowLoading(string text){

		if (loading == null) {
			loading = (LoadingOverlay)Instantiate (loadingPrefab, loadingPrefab.transform.position, loadingPrefab.transform.rotation);
			loading.transform.SetParent(popUpGroup.transform, false);
		}

		if (text != null) {
			loading.setText (text);
		}
			
	}

	void HideLoading(){
		Destroy (loading);
	}

	public virtual void sayHello(){
		Debug.Log ("Hello");
	}

}
