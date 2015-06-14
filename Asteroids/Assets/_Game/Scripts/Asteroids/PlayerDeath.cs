using UnityEngine;
using System.Collections;
using System;

namespace Asteroids {

	public class PlayerDeath : MonoBehaviour {

		public event Action EventDieComplete;

		[SerializeField]
		private GameObject explosionPrefab;

		[SerializeField]
		private float duration = 1.0f;

		[SerializeField]
		private AudioClip deathSound;

		private GameObject explosionGO;

		//===================================================
		// UNITY METHODS
		//===================================================

		/// <summary>
		/// Awake.
		/// </summary>
		void Awake() {

		}

		//===================================================
		// PUBLIC METHODS
		//===================================================

		/// <summary>
		/// Die. Show explosion and dispatch complete when done.
		/// </summary>
		public void Die() {
			explosionGO = Instantiate( explosionPrefab, transform.position, Quaternion.identity ) as GameObject;
			AudioManager.Instance.PlaySFX( deathSound );
			Invoke( "DieComplete", duration );
		}

		//===================================================
		// PRIVATE METHODS
		//===================================================

		/// <summary>
		/// Dispatches event when dieath anim is complete.
		/// </summary>
		private void DieComplete() {
			Destroy( explosionGO );

			if( EventDieComplete != null ) {
				EventDieComplete();
			}
		}

		//===================================================
		// EVENTS METHODS
		//===================================================


	}
}