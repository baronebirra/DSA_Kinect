using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour { //script che gestisce le opzioni all'interno del gioco
    public LevelManager levelManager;
    public Slider volumeSlider;
    public Slider volumeEffectSlider;

    private MusicManager musicManager;

	// Use this for initialization
	void Start () {
        musicManager = GameObject.FindObjectOfType<MusicManager>();
        volumeSlider.value = PlayerPrefsManager.GetMasterVolume();
        volumeEffectSlider.value = PlayerPrefsManager.GetEffectVolume();
    }
	
	// Update is called once per frame
	void Update () {
        musicManager.SetVolume(volumeSlider.value);  //quando cambiamo il volume si aggiorna in tempo reale
    }

    public void SaveAndExit() {//funzione che viene chiamata all'uscita dalla scena, aggiorna i valori selezionati dall'utente e carica la scena giusta
        PlayerPrefsManager.SetMasterVolume(volumeSlider.value);
        PlayerPrefsManager.SetEffectVolume(volumeEffectSlider.value);

        levelManager.LoadLevel("01a_StartMenu");
    }

    public void SetDefault() {//si resettano i valori delle opzioni a quelle di default
        volumeSlider.value = 0.8f;
        volumeEffectSlider.value = 0.8f;
    }
}
