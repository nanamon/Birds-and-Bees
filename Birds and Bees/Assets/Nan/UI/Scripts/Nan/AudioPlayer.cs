using UnityEngine;
using System.Collections;

public class AudioPlayer : MonoBehaviour {

	public AudioClip bgMusic;
	public AudioClip[] soundFXs;

	// Sound IDs
	public int menuSwitchID = 1;
	public int menuSelectID = 2;
	public int animalSoundGiraffe = 3;
	public int animalSoundPeacock = 4;
	public int animalSoundHippo = 5;
	public int animalSoundSloth = 6;
	public int animalSoundOstrich = 7;
	public int upbeatID = 8;
	public int downbeatID = 9;
	public int fanfareID = 10;

	// Load audio clips into here
	AudioSource[] audioSources;

	// Use this for initialization
	void Start () {
		
		for(int i = 0; i < soundFXs.Length+1; i++)
			this.gameObject.AddComponent<AudioSource>();
		
		audioSources = this.GetComponents<AudioSource>();
		audioSources[0].clip = bgMusic;

		// play bgm
		if (audioSources [0].clip != null) {
			audioSources [0].loop = true;
			audioSources [0].Play();
			audioSources [0].volume = 0.2f;
		}
	}

	public void PlaySwitchMenu() {
		audioSources[menuSwitchID].PlayOneShot(soundFXs[menuSwitchID]);
	}

	public void PlaySelectMenu() {
		audioSources[menuSelectID].PlayOneShot(soundFXs[menuSelectID]);
	}

	public void PlayAnimalNoise(int animal) {
		switch (animal) {
		case 1:
			audioSources [animalSoundGiraffe].PlayOneShot (soundFXs [animalSoundGiraffe-1]);
			break;
		case 2:
			audioSources [animalSoundPeacock].PlayOneShot (soundFXs [animalSoundPeacock-1]);
			break;
		case 3:
			audioSources [animalSoundHippo].PlayOneShot (soundFXs [animalSoundHippo-1]);
			break;
		case 4:
			Debug.Log ("Play Sloth noise");
			audioSources [animalSoundSloth].PlayOneShot (soundFXs [animalSoundSloth-1]);
			break;
		case 5:
			audioSources [animalSoundOstrich].PlayOneShot (soundFXs [animalSoundOstrich-1]);
			break;
		default:
			break;
		}
	}

	public void PlayUpBeat() {
		audioSources[upbeatID].PlayOneShot(soundFXs[upbeatID-1]);
	}

	public void PlayDownBeat() {
		audioSources[downbeatID].PlayOneShot(soundFXs[downbeatID-1]);
	}

	public void PlayFanfare() {
		audioSources[fanfareID].PlayOneShot(soundFXs[fanfareID-1]);
	}

	// Update is called once per frame
	void Update () {
	
	}
}
