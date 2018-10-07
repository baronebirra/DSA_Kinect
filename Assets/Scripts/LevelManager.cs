using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {//script per la gestione dei livelli
    public float autoLoadNextLevelAfter;

    private void Start() {
        if(autoLoadNextLevelAfter > 0)
            Invoke("LoadNextLevel", autoLoadNextLevelAfter);
    }
    public void LoadLevel(string name) {
		Debug.Log ("Level load requested for: " + name);
		SceneManager.LoadScene (name);
	}

    public void LoadNextLevel() {
        Debug.Log("Level load requested for: " + (SceneManager.GetActiveScene().buildIndex + 1));
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadPreviousLevel() {
        Debug.Log("Level load requested for: " + (SceneManager.GetActiveScene().buildIndex - 1));
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void QuitRequest() {
		Debug.Log ("Quit request");
        Application.Quit();
    }
}
