using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System;

namespace Asteroids.UI {

	public class ScoreScreen : MonoBehaviour {

		public event Action EventComplete;

		[SerializeField]
		private Text scoreText;

		[SerializeField]
		private Text waveText;

		[SerializeField]
		private AudioClip music;

		[SerializeField]
		private AudioClip startSFX;

		private bool isComplete;

		//===================================================
		// UNITY METHODS
		//===================================================

		/// <summary>
		/// Awake.
		/// </summary>
		void Awake() {

		}

		/// <summary>
		/// OnEnable.
		/// </summary>
		void OnEnable() {
			isComplete = false;
			scoreText.text = GameManager.Instance.Points.ToString();
			waveText.text = GameManager.Instance.Level.ToString();

			AudioManager.Instance.PlayMusic( music );
			GameManager.Instance.ResetGame();
		}

		/// <summary>
		/// Update.
		/// </summary>
		void Update() {
			if( !isComplete ) {
				if( Input.GetKeyDown( KeyCode.Space ) ) {
					StartPressed();
				}
			}
		}

		//===================================================
		// PUBLIC METHODS
		//===================================================


		//===================================================
		// PRIVATE METHODS
		//===================================================

		/// <summary>
		/// Dispatches complete when SPACE is Pressed.
		/// </summary>
		private void StartPressed() {
			AudioManager.Instance.PlaySFX( startSFX );
			isComplete = true;
			if( EventComplete != null ) {
				EventComplete();
			}
		}

		//===================================================
		// EVENTS METHODS
		//===================================================

	}
}