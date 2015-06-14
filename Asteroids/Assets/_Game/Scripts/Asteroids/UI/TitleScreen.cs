using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System;

namespace Asteroids.UI {

	public class TitleScreen : MonoBehaviour {

		public event Action EventComplete;

		[SerializeField]
		private Text startText;

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
			AudioManager.Instance.PlayMusic( music );
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
			isComplete = true;
			AudioManager.Instance.PlaySFX( startSFX );

			if( EventComplete != null ) {
				EventComplete();
			}
		}

		//===================================================
		// EVENTS METHODS
		//===================================================

	}
}