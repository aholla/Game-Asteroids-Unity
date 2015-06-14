using UnityEngine;
using System.Collections;
using System;

namespace Asteroids {

	public class LevelManager : MonoBehaviour {

		public event Action<int> EventPoints;
		public event Action EventPlayerDied;
		public event Action EventStarted;

		[SerializeField]
		private int level;
		public int Level {
			get { return level; }
			private set { level = value; }
		}

		[SerializeField]
		private AsteroidSpawner asteroidSpawner;

		[SerializeField]
		private Player player;

		[SerializeField]
		private float startLevelDelay = 3.0f;

		//===================================================
		// UNITY METHODS
		//===================================================

		/// <summary>
		/// Awake.
		/// </summary>
		void Awake() {
			asteroidSpawner.EventAsteroidDestroyed += OnAsteroidDestroyed;
			player.EventDied += OnPlayerDied;
		}

		//===================================================
		// PUBLIC METHODS
		//===================================================

		/// <summary>
		/// Resets this instance.
		/// </summary>
		public void Reset() {
			level = 1;
			asteroidSpawner.Reset();
		}

		/// <summary>
		/// Starts the level.
		/// </summary>
		public void StartLevel() {
			asteroidSpawner.Spawn( level );
			if( EventStarted != null ) {
				EventStarted();
			}
		}

		/// <summary>
		/// Spawns the player.
		/// </summary>
		public void SpawnPlayer() {
			player.Spawn();
		}

		//===================================================
		// PRIVATE METHODS
		//===================================================


		//===================================================
		// EVENTS METHODS
		//===================================================

		/// <summary>
		/// Called when [asteroid destroyed].
		/// </summary>
		/// <param name="points">The points.</param>
		private void OnAsteroidDestroyed( int points ) {
			// add to score.
			if( EventPoints != null ) {
				EventPoints( points );
			}

			// check if there are any asteroids remaining
			if( asteroidSpawner.AsteroidsRemaining == 0 ) {
				level += 1;
				Invoke( "StartLevel", startLevelDelay );
			}
		}

		/// <summary>
		/// Called when [player died].
		/// </summary>
		private void OnPlayerDied() {
			if( EventPlayerDied != null ) {
				EventPlayerDied();
			}
		}


	}
}