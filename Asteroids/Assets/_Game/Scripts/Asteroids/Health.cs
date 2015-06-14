using UnityEngine;
using System.Collections;
using System;

namespace Asteroids {

	public class Health : MonoBehaviour {

		public event Action<int> EventHeathChange;

		[SerializeField]
		private int health = 1;
		public int Value {
			get { return health; }
			private set { health = value; }
		}

		//===================================================
		// UNITY METHODS
		//===================================================

		/// <summary>
		/// Awake.
		/// </summary>
		void Awake() {

		}

		//===================================================
		// PUBLIC METHODS
		//===================================================

		/// <summary>
		/// Increases the health.
		/// </summary>
		/// <param name="value">The value.</param>
		public void IncreaseHealth( int value ) {
			Value += value;
			DispatchChangedEvent();
		}

		/// <summary>
		/// Reduces the health.
		/// </summary>
		/// <param name="value">The value.</param>
		public void ReduceHealth( int value ) {
			Value -= value;
			DispatchChangedEvent();
		}

		//===================================================
		// PRIVATE METHODS
		//===================================================

		/// <summary>
		/// Dispatches the changed event.
		/// </summary>
		private void DispatchChangedEvent() {
			if( EventHeathChange != null ) {
				EventHeathChange( Value );
			}
		}

		//===================================================
		// EVENTS METHODS
		//===================================================


	}
}