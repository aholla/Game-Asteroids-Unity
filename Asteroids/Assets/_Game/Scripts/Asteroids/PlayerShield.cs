using UnityEngine;
using System.Collections;
using System;

namespace Asteroids {

	public class PlayerShield : MonoBehaviour {

		[SerializeField]
		private GameObject shield;

		[SerializeField]
		private float duration = 1.0f;

		[SerializeField]
		private bool isInvincible;
		public bool IsInvincible {
			get { return isInvincible; }
			private set { isInvincible = value; }
		}

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
		/// Shows she shield.
		/// </summary>
		public void Show() {
			shield.SetActive( true );
			SetInvincible( true );

			CancelInvoke( "DisableGameObject" );
			Invoke( "DisableShield", duration );
		}

		//===================================================
		// PRIVATE METHODS
		//===================================================

		/// <summary>
		/// Sets invincible and the animation state.
		/// </summary>
		/// <param name="value">if set to <c>true</c> [value].</param>
		private void SetInvincible( bool value ) {
			isInvincible = value;
		}

		/// <summary>
		/// Disables the shield.
		/// </summary>
		private void DisableShield() {
			SetInvincible( false );
			Invoke( "DisableGameObject", 1.0f );
		}

		/// <summary>
		/// Disables the game object.
		/// </summary>
		private void DisableGameObject() {
			shield.SetActive( false );
		}


		//===================================================
		// EVENTS METHODS
		//===================================================


	}
}