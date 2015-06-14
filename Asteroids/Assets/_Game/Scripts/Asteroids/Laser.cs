using UnityEngine;
using System.Collections;

namespace Asteroids {

	[RequireComponent( typeof( CollisionWithAsteroid ) )]
	[RequireComponent( typeof( DestroyWeaponOffscreen ) )]
	public class Laser : MonoBehaviour {

		private CollisionWithAsteroid collision;

		private DestroyWeaponOffscreen destroyOffscreen;
		private ObjectPool weaponPool;
		private int damage;

		//===================================================
		// UNITY METHODS
		//===================================================

		/// <summary>
		/// Awake.
		/// </summary>
		void Awake() {
			destroyOffscreen = GetComponent<DestroyWeaponOffscreen>();
			destroyOffscreen.EventDestroy += OnEventDestroy;

			collision = GetComponent<CollisionWithAsteroid>();
			collision.EventCollision += OnCollisionWithAsteroid;
		}

		//===================================================
		// PUBLIC METHODS
		//===================================================

		/// <summary>
		/// Passes in the weaponPool
		/// </summary>
		/// <param name="pool">The pool.</param>
		public void Init( ObjectPool pool, int damageValue ) {
			weaponPool = pool;
			damage = damageValue;
		}

		//===================================================
		// PRIVATE METHODS
		//===================================================


		//===================================================
		// EVENTS METHODS
		//===================================================

		/// <summary>
		/// Called when [event destroy] fired. If weaponpool, return it, else destroys it manually.
		/// </summary>
		private void OnEventDestroy() {
			if( weaponPool ) {
				weaponPool.ReleaseObject( gameObject );
			} else {
				Destroy( gameObject );
			}
		}

		/// <summary>
		/// Called when [collision with asteroid].
		/// </summary>
		private void OnCollisionWithAsteroid( Asteroid asteroid ) {
			asteroid.Collision( damage );
			OnEventDestroy();
		}
	}

}