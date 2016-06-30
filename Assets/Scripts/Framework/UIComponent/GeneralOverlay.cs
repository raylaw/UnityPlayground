using UnityEngine;
using System;
using System.Collections;
using DG.Tweening;

namespace Framework{

public class GeneralOverlay : MonoBehaviour {

		void Awake(){
			
		}

		public virtual void Show(float duration , float delay , Action onComplete){
			CanvasGroup cg = this.gameObject.GetComponent<CanvasGroup>();
			DOTween.To(()=> cg.alpha, x=> cg.alpha = x, 1, duration).SetDelay(delay).OnComplete(() => { 
				if(onComplete != null ) onComplete(); 

				onShowComplete(); } );
			SpriteRenderer[] sprites = GetComponentsInChildren<SpriteRenderer>();
			for(int i = 0; i < sprites.Length; i++){
				SpriteRenderer sprite = sprites [i];
				sprite.material.DOColor (new Color(1f,1f,1f,1f), duration).SetDelay(delay);
			}
		}

		protected virtual void onShowComplete(){
			//Destroy(gameObject);
		}

		public virtual void Hide(){
			this.Hide(0,0,null, false);
		}
			
		public virtual void Hide(float duration , float delay , Action onComplete , Boolean destory){
			CanvasGroup cg = this.gameObject.GetComponent<CanvasGroup>();
			DOTween.To(()=> cg.alpha, x=> cg.alpha = x, 0, duration).SetDelay(delay).OnComplete(() => { 
				if(onComplete != null )onComplete(); 
				if(destory) onHideComplete(); 
			} );
			SpriteRenderer[] sprites = GetComponentsInChildren<SpriteRenderer>();
			for(int i = 0; i < sprites.Length; i++){
				SpriteRenderer sprite = sprites [i];
				sprite.material.DOColor (new Color(1f,1f,1f,0f), duration).SetDelay(delay);
			}
		}

		protected virtual void onHideComplete(){
			Destroy(gameObject);
		}
	}

}
