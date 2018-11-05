using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShapeProgress : MonoBehaviour {//script che aggiorna la percentuale di completamento e le figure completate
    public static int percentage;
    public static int shapeCompleted;

    private Text text;

    // Use this for initialization
    void Start () {
        percentage = 0;
        shapeCompleted = 0;
        text = GetComponent<Text>();

        if (gameObject.name == "Percentage")
            text.text = "0 %";
        else
            text.text = "0";
    }

    public void SetPercentage(int x) {
        percentage = x;
        text.text = percentage.ToString() + " %";
    }

    public void ShapeCompleted() {
        shapeCompleted++;
        text.text = shapeCompleted.ToString();
    }

}
