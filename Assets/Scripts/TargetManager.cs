using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetManager : MonoBehaviour {//script che gestisce la successione delle varie figure nel gioco Shape

    private LevelManager levelManager;

    private void Start() {
        levelManager = FindObjectOfType<LevelManager>();
    }

    public void NextTarget() {//viene distrutto il target attuale perché completato e se ci sono altre figure ancora da completare vengono attivate 
        Debug.Log("Next target!");
        //GameObject child = transform.GetChild(0).gameObject;
        if (transform.childCount > 1)
            transform.GetChild(1).gameObject.SetActive(true);
        Destroy(transform.GetChild(0).gameObject);
        //Destroy(child);
    }

    private void Update() {//se non ci sono più figli allora tutte le figure sono state completate e si passa alle scena successiva
        if (transform.childCount == 0)
            levelManager.LoadNextLevel();
    }

}
