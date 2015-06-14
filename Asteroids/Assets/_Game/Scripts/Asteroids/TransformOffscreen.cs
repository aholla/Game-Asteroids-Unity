using UnityEngine;
using System.Collections;

namespace Asteroids {

	public class TransformOffscreen : MonoBehaviour {

		[SerializeField]
		private float padding = 0.1f;

		protected bool isOffscreen;
		protected Vector3 viewportPos;

		private float top;
		private float bottom;
		private float left;
		private float right;

		//===================================================
		// UNITY METHODS
		//===================================================

		/// <summary>
		/// Awake.
		/// </summary>
		public virtual void Awake() {
			top = 0.0f - padding;
			bottom = 1.0f + padding;
			left = 0.0f - padding;
			right = 1.0f + padding;
		}

		/// <summary>
		/// Update.
		/// </summary>
		public virtual void Update() {
			// convert transform position to viewport position.
			viewportPos = Camera.main.WorldToViewportPoint( transform.position );
			isOffscreen = false;

			// check x
			if( viewportPos.x < left ) {
				viewportPos.x = right;
				isOffscreen = true;
			} else if( viewportPos.x > right ) {
				viewportPos.x = left;
				isOffscreen = true;
			}

			// check y
			if( viewportPos.y < top ) {
				viewportPos.y = bottom;
				isOffscreen = true;
			} else if( viewportPos.y > bottom ) {
				viewportPos.y = top;
				isOffscreen = true;
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
