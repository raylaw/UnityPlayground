using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Framework
{	
	
	public interface ITouchable2D
	{
		void OnTouchDown (RaycastHit2D hitInfo);

		void OnTouchUp (RaycastHit2D hitInfo);

		void OnTouchStay (RaycastHit2D hitInfo);

		void OnTouchExit (RaycastHit2D hitInfo);

		void OnTouchHover(RaycastHit2D hitInfo);
	}
}

