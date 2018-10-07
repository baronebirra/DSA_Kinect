using System.Collections;
using System.Collections.Generic;
//using UnityEditor;
using UnityEngine;

public class PreventQuit : MonoBehaviour {//script per evitare di chiudere il gioco premendo esc
    void OnApplicationQuit() {
        //if(!EditorUtility.DisplayDialog("titolo", "Sicuro di voler chiudere l'applicazione?", "Si, esci!", "Annulla"))
            Application.CancelQuit();
    }
}
