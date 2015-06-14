using UnityEngine;
using System.Collections;
using System;

namespace Asteroids {

	public class DestroyWeaponOffscreen : TransformOffscreen {

		public event Action EventDestroy;

		//===================================================
		// UNITY METHODS
		//===================================================

		/// <summary>
		/// Update.
		/// </summary>
		public override void Update() {
			base.Update();

			// if IsOffscreen, dispatch or manually destroy.
			if( isOffscreen ) {
				if( EventDestroy != null ) {
					EventDestroy();
				} else {
					Destroy( gameObject );
				}
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