using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Result : MonoBehaviour {
    public int gameN;
    public bool isBubbleCatch;
    public bool isGoodTarget;
    private Text myText;

    // Use this for initialization
    void Start () {
        myText = GetComponent<Text>();
        switch (gameN) {
            case 1:
                float succesfullPercentage = (float)ScoreKeeper.score / (float)(ScoreKeeper.score + ScoreKeeper.missedBubble);
                myText.color = new Color(2 - 2 * succesfullPercentage, 2 * succesfullPercentage, 0);
                if (isBubbleCatch)
                    myText.text = ScoreKeeper.score.ToString();
                else
                    myText.text = ScoreKeeper.missedBubble.ToString();
                break;
            case 2:
                if (isGoodTarget)
                    myText.text = ScoreKeeperKA.score.ToString();
                else
                    myText.text = ScoreKeeperKA.missedGoodTarget.ToString();
                break;
            case 3:
                myText.text = ShapeProgress.shapeCompleted.ToString();
                break;
        }
    }
	
}
