using UnityEngine;
using System.Collections;
using System;

namespace Asteroids {

	public class CollisionWithAsteroid : MonoBehaviour {

		public event Action<Asteroid> EventCollision;

		//===================================================
		// UNITY METHODS
		//===================================================

		/// <summary>
		/// Awake.
		/// </summary>
		void Awake() {

		}


		/// <summary>
		/// Called when colliders interact.
		/// </summary>
		/// <param name="collider">The collider.</param>
		void OnTriggerEnter2D( Collider2D collider ) {
			// convert tag to lowercase for less errors.
			string tag = collider.tag.ToLower();

			// check collision against lasers and ship. Dispatch event if collision.
			if( tag == Tags.Asteroid ) {
				Asteroid asteroid = collider.gameObject.GetComponentInParent<Asteroid>();

				// disptach event.
				if( EventCollision != null ) {
					EventCollision( asteroid );
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