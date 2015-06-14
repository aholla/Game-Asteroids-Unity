using UnityEngine;
using System.Collections;
using Asteroids.UI;

namespace Asteroids {

	public class GameManager : MonoBehaviour {
		private static GameManager instance;
		public static GameManager Instance {
			get { return instance; }
		}

		[SerializeField]
		private UIManager uiManager;

		[SerializeField]
		private LevelManager levelManager;

		[SerializeField]
		private GameObject gameHolder;

		[SerializeField]
		private int startingLives = 3;

		public int Lives {
			get;
			private set;
		}

		public int Points {
			get;
			private set;
		}

		public int Level {
			get { return levelManager.Level; }
		}

		//===================================================
		// UNITY METHODS
		//===================================================

		/// <summary>
		/// Awake.
		/// </summary>
		void Awake() {
			# region - Singleton
			if( instance == null ) {
				instance = this;
			} else if( instance != this ) {
				Destroy( gameObject );
			}
			DontDestroyOnLoad( gameObject );
			# endregion

			gameHolder.SetActive( false );

			levelManager.EventPoints += OnLevelPoints;
			levelManager.EventPlayerDied += OnLevelLives;
			levelManager.EventStarted += OnLevelStarted;
		}

		/// <summary>
		/// Start.
		/// </summary>
		void Start() {
			uiManager.ShowTitleScreen( true );
		}

		//===================================================
		// PUBLIC METHODS
		//===================================================

		/// <summary>
		/// Starts the game.
		/// </summary>
		public void StartGame() {
			gameHolder.SetActive( true );

			ResetGame();
			levelManager.StartLevel();
			levelManager.SpawnPlayer();
		}

		/// <summary>
		/// Resets the game.
		/// </summary>
		public void ResetGame() {
			Points = 0;
			Lives = startingLives;
			levelManager.Reset();

			uiManager.UpdateLives( Lives );
			uiManager.UpdatePoints( Points );
		}

		//===================================================
		// PRIVATE METHODS
		//===================================================


		//===================================================
		// EVENTS METHODS
		//===================================================

		/// <summary>
		/// Called when [level points].
		/// </summary>
		/// <param name="points">The points.</param>
		private void OnLevelPoints( int points ) {
			Points += points;
			uiManager.UpdatePoints( Points );
		}

		/// <summary>
		/// Called when [level lives].
		/// </summary>
		private void OnLevelLives() {
			Lives -= 1;
			if( Lives >= 0 ) {
				uiManager.UpdateLives( Lives );
				levelManager.SpawnPlayer();
			} else {
				uiManager.ShowScoreScreen();
			}
		}

		/// <summary>
		/// Called when [level started].
		/// </summary>
		private void OnLevelStarted() {
			uiManager.ShowLevelStart();
		}
	}
}