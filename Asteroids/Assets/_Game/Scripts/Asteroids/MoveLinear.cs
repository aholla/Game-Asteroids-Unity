using UnityEngine;
using System.Collections;

namespace Asteroids {

	public class MoveLinear : MonoBehaviour {

		[SerializeField]
		private float speed = 1.0f;

		//===================================================
		// UNITY METHODS
		//===================================================

		/// <summary>
		/// Awake.
		/// </summary>
		void Awake() {
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
			transform.Translate( transform.up * speed * Time.deltaTime, Space.World );
		}

		//===================================================
		// PUBLIC METHODS
		//===================================================

		//===================================================
		// PRIVATE METHODS
		//===================================================


		//===================================================
		// EVENTS METHODS
		//===================================================


	}
}