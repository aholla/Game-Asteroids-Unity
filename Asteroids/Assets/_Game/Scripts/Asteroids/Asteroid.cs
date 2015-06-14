using UnityEngine;
using System.Collections;
using System;

namespace Asteroids {

	[RequireComponent( typeof( Health ) )]
	[RequireComponent( typeof( MoveLinear ) )]
	[RequireComponent( typeof( WrapScreen ) )]
	public class Asteroid : MonoBehaviour {

		public event Action<Asteroid, int, Vector3, GameObject[]> EventDie;

		[SerializeField]
		private int pointsValue;

		[SerializeField]
		private GameObject[] asteroids;

		[SerializeField]
		private GameObject[] childAsteroids;

		[SerializeField]
		private AudioClip collisionSound;

		[SerializeField]
		private GameObject explosionParticlesPrefab;

		private Health health;
		private FlashColor flashColor;

		//===================================================
		// UNITY METHODS
		//===================================================

		/// <summary>
		/// Awake.
		/// </summary>
		public virtual void Awake() {
			ChooseAsteroid();
			health = GetComponent<Health>();
			flashColor = GetComponentInChildren<FlashColor>();
		}

		//===================================================
		// PUBLIC METHODS
		//===================================================

		/// <summary>
		/// Sets the initial rotation in which it will move in.
		/// </summary>
		/// <param name="direction">The direction.</param>
		[ContextMenu( "Test StartMoving" )]
		public void StartMoving( float direction = 0.0f ) {
			if( direction == 0.0f ) {
				// if no direction choose a random direction to move in.
				direction = Mathf.Floor( UnityEngine.Random.Range( 0.0f, 360.0f ) );
			}
			Vector3 rotation = new Vector3( 0.0f, 0.0f, direction );
			transform.rotation = Quaternion.Euler( rotation );
		}

		/// <summary>
		/// Collision externally called from objects that collid with the asteroid.
		/// </summary>
		/// <param name="damage">The damage.</param>
		[ContextMenu( "Test Collision" )]
		public void Collision( int damage = 1 ) {
			health.ReduceHealth( damage );

			AudioManager.Instance.PlaySFX( collisionSound );

			// check health
			if( health.Value > 0 ) {
				flashColor.Flash();
			} else {
				// particles
				GameObject particles = Instantiate( explosionParticlesPrefab, transform.position, Quaternion.identity ) as GameObject;
				Destroy( particles, 1.0f );

				if( EventDie != null ) {
					EventDie( this, pointsValue, transform.position, childAsteroids );
				}
				Destroy( gameObject );
			}
		}

		//===================================================
		// PRIVATE METHODS
		//===================================================

		/// <summary>
		/// Chooses the asteroid to be desiplayed. Disables all and enables the selected.
		/// </summary>
		private void ChooseAsteroid() {
			for( int i = 0; i < asteroids.Length; i++ ) {
				GameObject asteroid = asteroids[ i ];
				asteroid.SetActive( false );
			}

			GameObject chosenAsteroid = asteroids[ UnityEngine.Random.Range( 0, asteroids.Length ) ];
			chosenAsteroid.SetActive( true );
		}

		//===================================================
		// EVENTS METHODS
		//===================================================

	}
}
