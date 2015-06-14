using UnityEngine;
using System.Collections;
using System;

namespace Asteroids {

	[RequireComponent( typeof( PlayerController ) )]
	[RequireComponent( typeof( WrapScreen ) )]
	[RequireComponent( typeof( FireWeapon ) )]
	[RequireComponent( typeof( CollisionWithAsteroid ) )]
	[RequireComponent( typeof( PlayerDeath ) )]
	[RequireComponent( typeof( PlayerShield ) )]
	public class Player : MonoBehaviour {

		public event Action EventDied;

		private PlayerController controller;
		private CollisionWithAsteroid collisionWithAsteroid;
		private PlayerDeath playerDeath;
		private PlayerShield shield;

		//===================================================
		// UNITY METHODS
		//===================================================

		/// <summary>
		/// Awake.
		/// </summary>
		void Awake() {
			controller = GetComponent<PlayerController>();

			collisionWithAsteroid = GetComponent<CollisionWithAsteroid>();
			collisionWithAsteroid.EventCollision += OnCollisionWithAsteroid;

			playerDeath = GetComponent<PlayerDeath>();
			playerDeath.EventDieComplete += OnDeathComplete;

			shield = GetComponent<PlayerShield>();
		}

		//===================================================
		// PUBLIC METHODS
		//===================================================

		/// <summary>
		/// Shows the player
		/// </summary>
		public void Spawn() {
			gameObject.transform.position = Vector3.zero;
			gameObject.SetActive( true );
			shield.Show();
		}

		//===================================================
		// PRIVATE METHODS
		//===================================================


		//===================================================
		// EVENTS METHODS
		//===================================================

		/// <summary>
		/// Called when [collision with asteroid].
		/// </summary>
		private void OnCollisionWithAsteroid( Asteroid asteroid ) {
			// destroy the asteroid
			asteroid.Collision( int.MaxValue );

			// if the shields are not on DIE!
			if( !shield.IsInvincible ) {
				controller.Reset();
				playerDeath.Die();
				gameObject.SetActive( false );
			}
		}

		/// <summary>
		/// Called when [death complete]. If the player still has lives then respawn.
		/// </summary>
		private void OnDeathComplete() {
			if( EventDied != null ) {
				EventDied();
			}
		}

	}
}