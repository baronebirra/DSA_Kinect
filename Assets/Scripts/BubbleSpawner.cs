using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleSpawner : MonoBehaviour {  //script che si occupa della creazione delle bolle
    public GameObject bubblePrefab;
    public AudioClip bubbleAppear;
    //public static List<float> timeElapsedBubbles = new List<float>();
    public static ArrayList timeElapsedBubbles = new ArrayList();
    public static int totBubbleTSx, totBubbleTop, totBubbleTDx, totBubbleBSx, totBubbleBot, totBubbleBDx;

    private static System.Random rnd = new System.Random();
    private List<int> screenArea;
    private Vector3 bound;
    private float contrast, volume;
    private float xMin, xMax, yMin, yMax;
    private float frequency;

    // Use this for initialization
    void Start() {
        bound = GetComponentInParent<Collider2D>().bounds.size;

        contrast = RemoteVariables.bubble_contrast;
        frequency = RemoteVariables.bubble_frequency;
        screenArea = RemoteVariables.bubble_screenAreaEnabled;
        volume = PlayerPrefsManager.GetEffectVolume();

        xMin = transform.position.x - bound.x / 2;
        xMax = transform.position.x + bound.x / 2;
        yMin = transform.position.y - bound.y / 2;
        yMax = transform.position.y + bound.y / 2;

        totBubbleTSx = totBubbleTop = totBubbleTDx = totBubbleBSx = totBubbleBot = totBubbleBDx = 0;
        SpawnBubbles();
    }

    void SpawnBubbles() {
        GetBoundaries();
        Vector3 newPos = new Vector3(Random.Range(xMin, xMax), Random.Range(yMin, yMax), transform.position.z); //scelgo una posizione random tra le coordinate appena scelte
        GameObject bubble = Instantiate(bubblePrefab, newPos, Quaternion.identity) as GameObject; //creo la bolla alla posizione appena creata
        AudioSource.PlayClipAtPoint(bubbleAppear, transform.position, volume);
        Color currentColor = new Color(contrast, 1-contrast, 210f/255f*(1-contrast)); //setto il colore
        bubble.GetComponent<MeshRenderer>().material.SetColor("_Color", currentColor);
        bubble.transform.parent = transform;
        Invoke("SpawnBubbles", frequency); //chiamo ricorsivamente la funzione per far apparire le altre bolle
    }

    void GetBoundaries() {  //funzione che setta le giuste coordinate tra le quali far apparire le bolle
        //if (screenArea.Count == 6)
          //  return;
        int area = screenArea[rnd.Next(screenArea.Count)];//sceglie in maniera casuale una delle aree abilitate

        switch (area) {
            case 1://topsx
                xMin = transform.position.x - bound.x / 2;
                xMax = transform.position.x - bound.x / 6;
                yMin = transform.position.y;
                yMax = transform.position.y + bound.y / 2;
                totBubbleTSx++;
                break;
            case 2://top
                xMin = transform.position.x - bound.x / 6;
                xMax = transform.position.x + bound.x / 6;
                yMin = transform.position.y;
                yMax = transform.position.y + bound.y / 2;
                totBubbleTop++;
                break;
            case 3://topdx
                xMin = transform.position.x + bound.x / 6;
                xMax = transform.position.x + bound.x / 2;
                yMin = transform.position.y;
                yMax = transform.position.y + bound.y / 2;
                totBubbleTDx++;
                break;
            case 4://bottomsx
                xMin = transform.position.x - bound.x / 2;
                xMax = transform.position.x - bound.x / 6;
                yMin = transform.position.y - bound.y / 2;
                yMax = transform.position.y;
                totBubbleBSx++;
                break;
            case 5://bottom
                xMin = transform.position.x - bound.x / 6;
                xMax = transform.position.x + bound.x / 6;
                yMin = transform.position.y - bound.y / 2;
                yMax = transform.position.y;
                totBubbleBot++;
                break;
            case 6://bottomdx
                xMin = transform.position.x + bound.x / 6;
                xMax = transform.position.x + bound.x / 2;
                yMin = transform.position.y - bound.y / 2;
                yMax = transform.position.y;
                totBubbleBDx++;
                break;
        }
    }

}
