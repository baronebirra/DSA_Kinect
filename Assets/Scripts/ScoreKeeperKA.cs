using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeperKA : MonoBehaviour {//script per il calcolo del punteggio in keepattentio
    public static int score;
    public static int missedGoodTarget;
    public static int life;
    private Text text;
    private LevelManager levelManager;

    void Start(){
        levelManager = FindObjectOfType<LevelManager>();
        text = GetComponent<Text>();

        score = 0;
        missedGoodTarget = 0;
        life = RemoteVariables.keepAttention_life;

        if (gameObject.name == "Life")
            text.text = life.ToString();
    }

	public void Score(int points){
		score += points;
        text.text = score.ToString();
	}

    public static void Miss() {
        missedGoodTarget++;
    }

    public void GainLife(int lifeUP) {
        life += lifeUP;
        text.text = life.ToString();
    }

    public void LoseLife(int lifeDown) {
        life -= lifeDown;
        text.text = life.ToString();
        if(life <= 0)
            levelManager.LoadNextLevel();
    }

}
