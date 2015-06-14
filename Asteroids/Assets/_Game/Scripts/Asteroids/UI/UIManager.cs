using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace Asteroids.UI {

	public class UIManager : MonoBehaviour {

		[SerializeField]
		private TitleScreen titleScreen;

		[SerializeField]
		private GameScreen gameScreen;

		[SerializeField]
		private ScoreScreen scoreScreen;

		[SerializeField]
		private RectTransform transitionOverlay;

		[SerializeField]
		private float  transitionDuration = 0.5f;

		[SerializeField]
		private float  initialFadeDuration = 2.0f;

		private GameObject current;

		//===================================================
		// UNITY METHODS
		//===================================================

		/// <summary>
		/// Awake.
		/// </summary>
		void Awake() {
			titleScreen.EventComplete += OnTitleScreenComplete;
			scoreScreen.EventComplete += OnScoreScreenComplete;
		}

		//===================================================
		// PUBLIC METHODS
		//===================================================

		/// <summary>
		/// Shows the title screen.
		/// </summary>
		public void ShowTitleScreen( bool firstTime = false ) {
			if( firstTime ) {
				current = titleScreen.gameObject;
				titleScreen.gameObject.SetActive( true );
				FadeOutOverlay();
			} else {
				TransitionScreen( titleScreen.gameObject );
			}
		}

		/// <summary>
		/// Shows the game screen.
		/// </summary>
		public void ShowGameScreen() {
			TransitionScreen( gameScreen.gameObject );
		}

		/// <summary>
		/// Shows the score screen.
		/// </summary>
		public void ShowScoreScreen() {
			TransitionScreen( scoreScreen.gameObject );
		}

		/// <summary>
		/// Updates the points.
		/// </summary>
		/// <param name="points">The points.</param>
		public void UpdatePoints( int points ) {
			gameScreen.UpdatePoints( points );
		}

		/// <summary>
		/// Updates the lives.
		/// </summary>
		/// <param name="lives">The lives.</param>
		public void UpdateLives( int lives ) {
			gameScreen.UpdateLives( lives );
		}

		/// <summary>
		/// Shows the level start text.
		/// </summary>
		public void ShowLevelStart() {
			gameScreen.ShowLevelStart();
		}

		//===================================================
		// PRIVATE METHODS
		//===================================================

		/// <summary>
		/// Fades the out overlay.
		/// </summary>
		private void FadeOutOverlay() {
			transitionOverlay.gameObject.SetActive( true );
			LeanTween.alpha( transitionOverlay, 0.0f, initialFadeDuration )
				.setEase( LeanTweenType.easeOutSine )
				.setOnComplete( () => {
					transitionOverlay.gameObject.SetActive( false );
				} );
		}

		/// <summary>
		/// Transitions the screen.
		/// </summary>
		/// <param name="screen">The screen.</param>
		private void TransitionScreen( GameObject screen ) {
			transitionOverlay.gameObject.SetActive( true );

			LeanTween.alpha( transitionOverlay, 1.0f, transitionDuration )
				.setEase( LeanTweenType.easeOutSine )
				.setOnComplete( () => {
					screen.SetActive( true );

					if( current != null ) {
						current.SetActive( false );
					}
					current = screen;

					LeanTween.alpha( transitionOverlay, 0.0f, transitionDuration )
						.setEase( LeanTweenType.easeOutSine )
						.setOnComplete( () => {
							transitionOverlay.gameObject.SetActive( false );
						} );

				} );
		}

		//===================================================
		// EVENTS METHODS
		//===================================================

		/// <summary>
		/// Called when [title screen complete].
		/// </summary>
		private void OnTitleScreenComplete() {
			ShowGameScreen();
		}

		/// <summary>
		/// Called when [game screen complete].
		/// </summary>
		private void OnGameScreenComplete() {
			ShowScoreScreen();
		}

		/// <summary>
		/// Called when [score screen complete].
		/// </summary>
		private void OnScoreScreenComplete() {
			ShowTitleScreen();
		}
	}
}