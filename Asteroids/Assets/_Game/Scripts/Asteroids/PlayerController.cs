using UnityEngine;
using System.Collections;

namespace Asteroids {
	public class PlayerController : MonoBehaviour {

		[SerializeField]
		private float maxVelocity = 5.0f;

		[SerializeField]
		private float rotationSpeed = 250.0f;

		[SerializeField]
		private float friction = 0.95f;

		[SerializeField]
		private float acceleration = 5.0f;

		private Vector3 velocity;
		private Vector3 clampedVelocity;

		//===================================================
		// UNITY METHODS
		//===================================================

		/// <summary>
		/// Awake.
		/// </summary>
		void Awake() {
			Reset();
		}

		/// <summary>
		/// Start.
		/// </summary>
		void Start() {

		}

		/// <summary>
		/// Update.
		/// </summary>
		void Update() {
			float inputX = Input.GetAxis( "Horizontal" );
			float inputY = Mathf.Clamp( Input.GetAxis( "Vertical" ), 0, 1 );

			// update rotation.
			transform.Rotate( new Vector3( 0, 0, -inputX ), rotationSpeed * Time.deltaTime );

			// update velocity.
			velocity += ( inputY * ( transform.up * acceleration ) ) * Time.deltaTime;

			// apply friction if np input.
			if( inputY == 0.0f ) {
				velocity *= friction;
			}

			clampedVelocity = Vector3.ClampMagnitude( velocity, maxVelocity );
			transform.Translate( clampedVelocity * Time.deltaTime, Space.World );
		}

		//===================================================
		// PUBLIC METHODS
		//===================================================

		/// <summary>
		/// Resets this instance.
		/// </summary>
		public void Reset() {
			velocity = new Vector3( 0, 0, 0 );
			clampedVelocity = new Vector3( 0, 0, 0 );
		}

		//===================================================
		// PRIVATE METHODS
		//===================================================


		//===================================================
		// EVENTS METHODS
		//===================================================


	}
}