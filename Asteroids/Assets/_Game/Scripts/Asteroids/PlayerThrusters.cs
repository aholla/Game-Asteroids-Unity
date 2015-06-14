using UnityEngine;
using System.Collections;

namespace Asteroids {

	public class PlayerThrusters : MonoBehaviour {

		[SerializeField]
		private Animator thrusterMain;

		[SerializeField]
		private Animator thrusterLeft;

		[SerializeField]
		private Animator thrusterRight;

		//===================================================
		// UNITY METHODS
		//===================================================

		/// <summary>
		/// Awake.
		/// </summary>
		void Awake() {
		}

		/// <summary>
		/// Update.
		/// </summary>
		void Update() {
			float inputX = Input.GetAxis( "Horizontal" );
			float inputY = Mathf.Clamp( Input.GetAxis( "Vertical" ), 0, 1 );

			if( inputX < 0 ) {
				thrusterLeft.SetBool( "Thrust", false );
				thrusterRight.SetBool( "Thrust", true );
			} else if( inputX > 0 ) {
				thrusterLeft.SetBool( "Thrust", true );
				thrusterRight.SetBool( "Thrust", false );
			} else {
				thrusterLeft.SetBool( "Thrust", false );
				thrusterRight.SetBool( "Thrust", false );
			}

			if( inputY > 0 ) {
				thrusterMain.SetBool( "Thrust", true );
			} else {
				thrusterMain.SetBool( "Thrust", false );
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