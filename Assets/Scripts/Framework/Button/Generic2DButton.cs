using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using UnityEngine.EventSystems;


namespace Framework{

	namespace Button{

		[System.Serializable]
		public class OnTouchEvent : UnityEvent<Generic2DButton , RaycastHit2D >{ }

		[RequireComponent(typeof(Collider2D))]
		public class Generic2DButton : MonoBehaviour, ITouchable2D {

			public OnTouchEvent onTouchDownEvent;

//			public EventTrigger.TriggerEvent onTouchDownCallback;
//			public EventTrigger.TriggerEvent onTouchUpCallBack;
//			public EventTrigger.TriggerEvent onTouchStayCallback;
//			public EventTrigger.TriggerEvent onTouchExitCallback;
//			public EventTrigger.TriggerEvent onTouchHoverCallback;

	


			// Use this for initialization
			void Start () {
			
			}
			
			// Update is called once per frame
			void Update () {
			
			}

			public virtual void OnTouchDown(RaycastHit2D hitInfo){

			}

			public virtual void OnTouchUp(RaycastHit2D hitInfo){

			}

			public virtual void OnTouchStay(RaycastHit2D hitInfo){

			}

			public virtual void OnTouchExit(RaycastHit2D hitInfo){

			}

			public virtual void OnTouchHover(RaycastHit2D hitInfo){

			}
		}

	}
}
