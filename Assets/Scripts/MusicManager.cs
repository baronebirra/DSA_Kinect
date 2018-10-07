using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour {     //gestore della musica
    public AudioClip[] levelMusicChangeArray;

    private AudioSource audioSource;

    private void Awake() {
        DontDestroyOnLoad(gameObject);
    }

    private void Start() {
        audioSource = GetComponent<AudioSource>();
        SetVolume(PlayerPrefsManager.GetMasterVolume());
    }

    private void OnEnable() {
        SceneManager.sceneLoaded += OnSceneLoaded; // subscribe
    }

    private void OnDisable() {
        SceneManager.sceneLoaded -= OnSceneLoaded; //unsubscribe
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode) {
        AudioClip thisLevelMusic = levelMusicChangeArray[scene.buildIndex];
        Debug.Log("Playing clip: " + thisLevelMusic);

        if (thisLevelMusic) {
            audioSource.clip = thisLevelMusic;
            audioSource.loop = true;
            audioSource.Play();
        }
    }

    public void SetVolume(float volume) {
        audioSource.volume = volume;
    }
}
