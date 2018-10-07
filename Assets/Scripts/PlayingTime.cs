using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayingTime : MonoBehaviour {//script per la gestione del tempo nei giochi
    public int gameN;
    private float expireTime;
    private Text text;
    private LevelManager levelManager;

    // Use this for initialization
    void Start() {
        text = GetComponent<Text>();
        switch (gameN) {
            case 1:
                expireTime = RemoteVariables.bubble_gameTime;
                break;
            case 2:
                expireTime = RemoteVariables.keepAttention_gameTime;
                break;
            case 3:
                expireTime = RemoteVariables.shape_gameTime;
                expireTime = 50;
                break;
        }
        levelManager = FindObjectOfType<LevelManager>();
    }

    // Update is called once per frame
    void Update () {//se il tempo è scaduto carica la schermata successiva
        float time = expireTime - Time.timeSinceLevelLoad;
        text.text = time.ToString("0.00");
        if (time <= 0) {
            text.text = "Tempo Scaduto";
            levelManager.LoadNextLevel();
        }
    }
}
