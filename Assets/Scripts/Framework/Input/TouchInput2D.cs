using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using _Input = UnityEngine.Input;

namespace Framework.Input{

		public class TouchInput2D : MonoBehaviour {

			public LayerMask touchInputMask;

			private List<GameObject> touchList = new List<GameObject> ();
			private GameObject[] touchesOld;
			private RaycastHit hit;

			// Update is called once per frame
			void Update () {

				#if UNITY_EDITOR

			if (_Input.GetMouseButton(0) || _Input.GetMouseButtonDown(0) || _Input.GetMouseButtonUp(0) || (_Input.GetAxis("Mouse X") != 0) || (_Input.GetAxis("Mouse Y") != 0) ) {

					touchesOld = new GameObject[touchList.Count];
					touchList.CopyTo (touchesOld);
					touchList.Clear ();

					Vector2 pos = new Vector2(_Input.mousePosition.x, _Input.mousePosition.y);
					RaycastHit2D hitInfo = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(pos), Vector2.zero , Mathf.Infinity , touchInputMask );
					// RaycastHit2D can be either true or null, but has an implicit conversion to bool, so we can use it like this

					if(hitInfo)
					{
						//Debug.Log(touchInputMask.value);
						GameObject recipient = hitInfo.transform.gameObject;
						touchList.Add (recipient);

						// Here you can check hitInfo to see which collider has been hit, and act appropriately.
					if (_Input.GetMouseButtonDown(0)) {
							
							recipient.SendMessage ("OnTouchDown", hitInfo, SendMessageOptions.DontRequireReceiver);
						}
					if (_Input.GetMouseButtonUp(0)) {
							recipient.SendMessage ("OnTouchUp", hitInfo, SendMessageOptions.DontRequireReceiver);
						}
					if (_Input.GetMouseButton(0)) {
							recipient.SendMessage ("OnTouchStay", hitInfo, SendMessageOptions.DontRequireReceiver);
						}

					if (!_Input.GetMouseButton(0) && ((_Input.GetAxis("Mouse X") != 0) || (_Input.GetAxis("Mouse Y") != 0))) {
							recipient.SendMessage ("OnTouchHover", hitInfo, SendMessageOptions.DontRequireReceiver);
						}

					}

					foreach (GameObject g in touchesOld) {
						if (!touchList.Contains (g)) {
							g.SendMessage("OnTouchExit", hitInfo, SendMessageOptions.DontRequireReceiver);
						}
					}

				}

				#endif

				if (_Input.touchCount > 0) {

					touchesOld = new GameObject[touchList.Count];
					touchList.CopyTo (touchesOld);
					touchList.Clear ();

					foreach (Touch touch in _Input.touches) {

						RaycastHit2D hitInfo = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(touch.position), Vector2.zero , Mathf.Infinity , touchInputMask.value);

						if (hitInfo) {

							GameObject recipient = hitInfo.transform.gameObject;
							touchList.Add (recipient);

							if (touch.phase == TouchPhase.Began) {
								recipient.SendMessage ("OnTouchDown", hitInfo, SendMessageOptions.DontRequireReceiver);
							}
							if (touch.phase == TouchPhase.Ended) {
								recipient.SendMessage ("OnTouchUp", hitInfo, SendMessageOptions.DontRequireReceiver);
							}
							if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved) {
								recipient.SendMessage ("OnTouchStay", hitInfo, SendMessageOptions.DontRequireReceiver);
							}
							if (touch.phase == TouchPhase.Canceled) {
								recipient.SendMessage ("OnTouchExit", hitInfo, SendMessageOptions.DontRequireReceiver);
							}
						}
					}

					foreach (GameObject g in touchesOld) {
						if (!touchList.Contains (g)) {
							g.SendMessage("OnTouchExit", hit.point, SendMessageOptions.DontRequireReceiver);
						}
					}
				}
			}
		}
	}

