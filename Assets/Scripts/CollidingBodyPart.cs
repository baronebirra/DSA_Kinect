﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollidingBodyPart : MonoBehaviour {//script che gestisce la collisione tra l'avatar e il target
    public int bodyPartNumber;

    private AudioClip shapeCompletedAudio;
    private float volume;
    private TargetManager targetManager;
    private ShapeProgress shapeProgress, shapeProgressC;
    private float winningPercentage;

    private void Start() {
        targetManager = FindObjectOfType<TargetManager>();
        shapeProgress = GameObject.Find("Percentage").GetComponent<ShapeProgress>();
        shapeProgressC = GameObject.Find("ShapeCompleted").GetComponent<ShapeProgress>();
        volume = PlayerPrefsManager.GetEffectVolume();
        shapeCompletedAudio = Resources.Load<AudioClip>("242501__gabrielaraujo__powerup-success");

        winningPercentage = RemoteVariables.shape_winningPercentage;
    }

    private void OnTriggerEnter2D(Collider2D collision) {//la parte del corpo è nella giusta posizione(aggiorna quindi l'array) e aggiorna la percentuale di completamento
        Shape.SetCollidingPart(bodyPartNumber);
        int percentage = (int)Shape.GetPercentageCompletition();
        shapeProgress.SetPercentage(percentage);
        if (percentage >= winningPercentage)
            ShapeCompleted();
    }

    private void OnTriggerExit2D(Collider2D collision) {//la parte del corpo non è più nella giusta posizione(aggiorna quindi l'array) e aggiorna la percentuale di completamento
        Shape.UnsetCollidingPart(bodyPartNumber);
        int percentage = (int)Shape.GetPercentageCompletition();
        shapeProgress.SetPercentage(percentage);
    }


    void ShapeCompleted() {
        AudioSource.PlayClipAtPoint(shapeCompletedAudio, transform.position, volume);
        Shape.Reset();                   //se finito tutte le figure allora win altrimenti disabilita avatar e attiva il prossimo
        targetManager.NextTarget();
        shapeProgressC.ShapeCompleted();
        shapeProgress.SetPercentage(0);
        Debug.Log("Figura completata");
    }

}
