using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour {//script per il calcolo del punteggio in bubble
	public static int score;
    public static int missedBubble;
    public static int totHandLx, totHandRx, totFootLx, totFootRx;
    private Text text;

    void Start(){
        text = GetComponent<Text>();
        Reset();
    }

	public void Score(int points){
		score += points;
        text.text = score.ToString();
	}

    public static void Miss() {
        missedBubble++;
    }

	public static void Reset(){
		score = 0;
        missedBubble = 0;
        totHandLx = totHandRx = totFootLx = totFootRx = 0;
    }
}
