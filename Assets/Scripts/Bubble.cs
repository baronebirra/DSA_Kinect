using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour {  //script che gestisce le singole bolle
    public int points = 1;
    public AudioClip popBubble;
    public AudioClip bubbleDisappear;

    private float timeCreation;
    private float expireTime;
    private ScoreKeeper scoreKeeper;
    private float volume;

    private void Start() {  //inizializzo le variabili
        timeCreation = Time.timeSinceLevelLoad;
        scoreKeeper = GameObject.Find("Score").GetComponent<ScoreKeeper>();
        //expireTime = PlayerPrefsManager.GetPersistence();
        expireTime = RemoteVariables.bubble_persistence;
        volume = PlayerPrefsManager.GetEffectVolume();
    }

    private void Update() {
        if (Time.timeSinceLevelLoad - timeCreation >= expireTime) {   //se il tempo è scaduto allora emetti suono per la bolla che scompare e aggiorno il punteggio
            AudioSource.PlayClipAtPoint(bubbleDisappear, transform.position, volume);
            ScoreKeeper.Miss();
            Destroy(gameObject);
            BubbleSpawner.timeElapsedBubbles.Add(expireTime);//  [ID] = expireTime;
            //Debug.Log("ID della bolla non colpita: " + ID);
        }
    }

    private void OnTriggerEnter(Collider col) {   //se entra in collisione allora distruggo bolla e aggiorno punteggio
        switch (col.gameObject.tag) {
            case "HandLx":
                ScoreKeeper.totHandLx++;
                break;
            case "HandRx":
                ScoreKeeper.totHandRx++;
                break;
            case "FootLx":
                ScoreKeeper.totFootLx++;
                break;
            case "FootRx":
                ScoreKeeper.totFootRx++;
                break;
        }
        AudioSource.PlayClipAtPoint(popBubble, transform.position, volume);
        Destroy(gameObject);
        scoreKeeper.Score(points);
        BubbleSpawner.timeElapsedBubbles.Add(Time.timeSinceLevelLoad - timeCreation);
    }
}
