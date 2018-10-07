using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;

public class Limb : MonoBehaviour {
    public int limbID;

	// Use this for initialization
	void Start () {
        switch (limbID) {//se l'arto in questione non è abilitato per colpire le bolle allora non viene visualizzata nemmeno l'immagine(impronte mani e piedi)
            case 1:
                if (!RemoteVariables.bubble_leftHand)
                    gameObject.SetActive(false);
                break;
            case 2:
                if (!RemoteVariables.bubble_rightHand)
                    gameObject.SetActive(false);
                break;
            case 3:
                if (!RemoteVariables.bubble_leftFoot)
                    gameObject.SetActive(false);
                break;
            case 4:
                if (!RemoteVariables.bubble_rightFoot)
                    gameObject.SetActive(false);
                break;
            default:
                break;
        }
    }
}
