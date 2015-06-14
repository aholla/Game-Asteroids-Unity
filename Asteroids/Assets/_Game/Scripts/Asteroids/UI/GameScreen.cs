using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace Asteroids.UI {

	public class GameScreen : MonoBehaviour {

		[SerializeField]
		private Text scoreText;

		[SerializeField]
		private GameObject[] livesGO;

		[SerializeField]
		private RectTransform levelStartText;

		[SerializeField]
		private float textDuration = 3.0f;

		[SerializeField]
		private AudioClip music;

		private Text leveltext;

		//===================================================
		// UNITY METHODS
		//===================================================

		void Awake() {
			leveltext = levelStartText.gameObject.GetComponent<Text>();
		}

		/// <summary>
		/// OnEnable.
		/// </summary>
		void OnEnable() {
			for( int i = 0; i < livesGO.Length; i++ ) {
				livesGO[ i ].SetActive( true );
			}
			levelStartText.gameObject.SetActive( false );

			GameManager.Instance.StartGame();
			AudioManager.Instance.PlayMusic( music );
		}

		//===================================================
		// PUBLIC METHODS
		//===================================================

		/// <summary>
		/// Updates the points.
		/// </summary>
		/// <param name="points">The points.</param>
		public void UpdatePoints( int points ) {
			scoreText.text = points.ToString();
		}

		/// <summary>
		/// Updates the lives.
		/// </summary>
		/// <param name="lives">The lives.</param>
		public void UpdateLives( int lives ) {
			for( int i = 0; i < livesGO.Length; i++ ) {
				if( i >= lives ) {
					livesGO[ i ].SetActive( false );
				}
			}
		}

		/// <summary>
		/// Shows the level start text.
		/// </summary>
		public void ShowLevelStart() {
			levelStartText.gameObject.SetActive( true );

			leveltext.text = "WAVE " + GameManager.Instance.Level;

			LeanTween.textAlpha( levelStartText, 1.0f, 1.0f )
				.setEase( LeanTweenType.easeOutSine )
				.setOnComplete( () => {

					LeanTween.textAlpha( levelStartText, 0.0f, 0.5f )
						.setEase( LeanTweenType.easeOutSine )
						.setDelay( textDuration )
						.setOnComplete( () => {
							levelStartText.gameObject.gameObject.SetActive( false );
						} );

				} );
		}

		//===================================================
		// PRIVATE METHODS
		//===================================================

		//===================================================
		// EVENTS METHODS
		//===================================================




	}
}