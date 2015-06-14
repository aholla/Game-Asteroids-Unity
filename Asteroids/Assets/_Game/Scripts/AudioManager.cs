using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour {
	private static AudioManager instance = null;
	public static AudioManager Instance {
		get { return instance; }
	}

	[SerializeField]
	private AudioSource sfxSource;

	[SerializeField]
	private AudioSource musicSource;

	//===================================================
	// UNITY METHODS
	//===================================================

	void Awake() {
		# region - Singleton
		if( instance == null ) {
			instance = this;
		} else if( instance != this ) {
			Destroy( gameObject );
		}
		DontDestroyOnLoad( gameObject );
		# endregion
	}


	//===================================================
	// PUBLIC METHODS
	//===================================================


	/// <summary>
	/// Plays the SFX.
	/// </summary>
	/// <param name="clip">The clip.</param>
	/// <param name="volume">The volume.</param>
	public void PlaySFX( AudioClip clip, float volume = 1.0f ) {
		if( !sfxSource.isPlaying ) {
			sfxSource.clip = clip;
			sfxSource.volume = volume;
			sfxSource.Play();
		} else {
			PlayDynamicSound( clip, volume );
		}
	}

	/// <summary>
	/// Plays the music.
	/// </summary>
	/// <param name="clip">The clip.</param>
	/// <param name="volume">The volume.</param>
	public void PlayMusic( AudioClip clip, float volume = 1.0f ) {
		if( musicSource.isPlaying && musicSource.clip == clip ) {
			return;
		}

		musicSource.clip = clip;
		musicSource.loop = true;
		musicSource.volume = volume;
		musicSource.Play();
	}

	//===================================================
	// PRIVATE METHODS
	//===================================================

	/// <summary>
	/// Plays the dynamic sound.
	/// </summary>
	/// <param name="clip">The clip.</param>
	/// <param name="volume">The volume.</param>
	private void PlayDynamicSound( AudioClip clip, float volume = 1.0f ) {
		//Create an empty game object
		GameObject sfxGO = new GameObject( "Dynamic_" + clip.name );
		sfxGO.transform.SetParent( transform );

		//Create the source
		AudioSource source = sfxGO.AddComponent<AudioSource>();
		source.clip = clip;
		source.volume = volume;
		source.Play();

		Destroy( sfxGO, clip.length );
	}

	//===================================================
	// EVENTS METHODS
	//===================================================



}
