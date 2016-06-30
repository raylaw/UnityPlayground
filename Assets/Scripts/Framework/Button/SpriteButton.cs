using UnityEngine;
using System;
using System.Collections;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using DG.Tweening;

namespace Framework{

	namespace Button{

		[RequireComponent(typeof(SpriteRenderer))]
		public class SpriteButton : Generic2DButton  {

			public Sprite normal; 
			public Sprite pressed;
			public Sprite hover; 
			public Sprite disabled;

			public GameObject textContainer;

			private SpriteRenderer spriteRenderer;

			[HideInInspector]
			public string myState;
			public bool isPressed;


			// Use this for initialization
			void Start () {
				myState = "Hahahaha";
				spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
				isPressed = false;


			}

			// Update is called once per frame
			void Update () {

			}

			public void whoAmI(){

				Debug.Log ("WHO AM I ?");
			}

			private void OnPressedEffect(){

				if (isPressed)
					return;

				isPressed = true;

				//AudioController.GetAudioItem ("Hat").ResetSequence ();

				AudioController.Play( "Hat"  );

				spriteRenderer.sprite = pressed;

				if(textContainer != null){
					textContainer.transform.localPosition = new Vector3(textContainer.transform.localPosition.x, 0f, 0f);
				}
				
			}

			private void OnReleaseEffect(){

				isPressed = false;
				spriteRenderer.sprite = normal;

				if(textContainer != null){
					textContainer.transform.localPosition = new Vector3(textContainer.transform.localPosition.x, 0.06f, 0f);
				}
			}

			public override void OnTouchDown(RaycastHit2D hitInfo){

				try{

					//AudioController.Play( "Hat" );

					//transform.DOMove(new Vector3(2,2,0), 1).SetDelay(2).SetEase(Ease.OutQuad);


					if(onTouchDownEvent != null){
						onTouchDownEvent.Invoke(this , hitInfo );
					}

				
					OnPressedEffect();


				}catch(Exception e){
					Debug.LogException(e, this);
				}

			}

			public override void OnTouchUp(RaycastHit2D hitInfo){
				OnReleaseEffect ();
			}

			public override void OnTouchStay(RaycastHit2D hitInfo){
				OnPressedEffect();
			}

			public override void OnTouchExit(RaycastHit2D hitInfo){
				OnReleaseEffect ();
			}

			public override void OnTouchHover(RaycastHit2D hitInfo){
				spriteRenderer.sprite = hover;
			}


		}

	}

}
