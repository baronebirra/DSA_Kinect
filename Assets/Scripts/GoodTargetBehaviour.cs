using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodTargetBehaviour : MonoBehaviour { //script per gestire i target buoni nel gioco KeepAttentio
    public int points;
    public int lifeUP;
    private ScoreKeeperKA scoreKeeperKA, scoreKeeperKALife;

    // Use this for initialization
    void Start() {
        scoreKeeperKA = GameObject.Find("Score").GetComponent<ScoreKeeperKA>();
        scoreKeeperKALife = GameObject.Find("Life").GetComponent<ScoreKeeperKA>();
    }

    private void OnTriggerEnter(Collider col) { //quando il target entra in collisione con un altro oggetto
        if (col.gameObject.tag == "Floor") {  //se colpisce il pavimento allora aggiorno il conteggio degli oggetti mancati
            ScoreKeeperKA.Miss();
            Destroy(gameObject);
        }
        else {                              //altrimenti aggiorno il punteggio e/o le vite
            scoreKeeperKA.Score(points);
            scoreKeeperKALife.GainLife(lifeUP);
            Destroy(gameObject);
        }
    }
}
