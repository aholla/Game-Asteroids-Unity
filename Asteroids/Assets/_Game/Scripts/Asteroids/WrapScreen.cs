using UnityEngine;
using System.Collections;

namespace Asteroids {

	public class WrapScreen : TransformOffscreen {

		//===================================================
		// UNITY METHODS
		//===================================================

		/// <summary>
		/// Update. Check if transform is outside the offscreen positions and if so move to the opposite.
		/// </summary>
		public override void Update() {
			base.Update();

			// if IsOffscreen, convert viewport pos back to world pos and apply to transform.
			if( isOffscreen ) {
				transform.position = Camera.main.ViewportToWorldPoint( viewportPos );
			}
		}

		//===================================================
		// PUBLIC METHODS
		//===================================================


		//===================================================
		// PRIVATE METHODS
		//===================================================


		//===================================================
		// EVENTS METHODS
		//===================================================


	}
}