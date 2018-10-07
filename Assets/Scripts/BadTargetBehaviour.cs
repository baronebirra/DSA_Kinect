using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadTargetBehaviour : MonoBehaviour {  //script per gestire i target cattivi nel gioco KeepAttentio
    public int lifeDown;

    private ScoreKeeperKA scoreKeeperKA;

    // Use this for initialization
    void Start () {
        scoreKeeperKA = GameObject.Find("Life").GetComponent<ScoreKeeperKA>();
    }
	
    private void OnTriggerEnter(Collider col) { //quando il target entra in collisione con un altro oggetto
        if (col.gameObject.tag == "Floor") //se colpisce il pavimento allora distuggo l'oggetto
            Destroy(gameObject);
        else {                              //altrimenti perdo delle vite
            scoreKeeperKA.LoseLife(lifeDown);
            Destroy(gameObject);
        }
    }
}
