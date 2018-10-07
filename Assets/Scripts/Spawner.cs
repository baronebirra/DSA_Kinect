using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {//script che gestisce la comparsa dei target in KeepAttention
    public GameObject[] enemyPrefab;
    public GameObject[] friendPrefab;
    public static int totTargetLB, totTargetLT, totTargetTL, totTargetTR, totTargetRT, totTargetRB;
    //public AudioClip bubbleAppear;

    private static System.Random rnd = new System.Random();
    private List<int> spawnAreas;
    private float contrastGT, contrastBT, volume;
    private float screenDimensionX, screenDimensionY;
    private float frequencyGoodTarget, frequencyBadTarget;
    private float speedGoodTarget, speedBadTarget;
    private float diagonalTrajectoryPercentage;
    private Vector3 botLeft, topRight, boundGT, boundBT;

    // Use this for initialization
    void Start() {
        contrastGT = RemoteVariables.keepAttention_contrastGoodTarget;
        contrastBT = RemoteVariables.keepAttention_contrastBadTarget;
        spawnAreas = RemoteVariables.keepAttention_spawnAreaEnabled;
        frequencyGoodTarget = RemoteVariables.keepAttention_frequencyGoodTarget;
        frequencyBadTarget = RemoteVariables.keepAttention_frequencyBadTarget;
        speedGoodTarget = RemoteVariables.keepAttention_speedGoodTarget;
        speedBadTarget = RemoteVariables.keepAttention_speedBadTarget;
        diagonalTrajectoryPercentage = RemoteVariables.keepAttention_diagonalTrajectoryPercentage;
        //volume = PlayerPrefsManager.GetEffectVolume();

        totTargetLB = totTargetLT = totTargetTL = totTargetTR = totTargetRT = totTargetRB = 0;
        float distance = transform.position.z - Camera.main.transform.position.z;
        botLeft = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
        topRight = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, distance));

        screenDimensionX = topRight.x - botLeft.x;
        screenDimensionY = topRight.y - botLeft.y;

        boundGT = friendPrefab[1].GetComponentInChildren<Renderer>().bounds.size;
        boundBT = enemyPrefab[0].GetComponentInChildren<Renderer>().bounds.size;

        Spawn();
    }

    void Spawn() {
        SpawnBadTarget();
        SpawnGoodTarget();
    }

    void SpawnBadTarget() {
        int iPref = GetIndexPrefab();
        int area = spawnAreas[rnd.Next(spawnAreas.Count)];//scegli in modo casuale una delle aree abilitate
        float[] vel = GetVelocity(area, speedBadTarget);
        Vector3 newPos = GetPosition(area, boundBT.y/2);
        GameObject enemy = Instantiate(enemyPrefab[iPref], newPos, Quaternion.identity) as GameObject;//instanzio l'oggetto
        enemy.GetComponent<Rigidbody>().velocity = new Vector2(vel[0], vel[1]);
        enemy.transform.parent = transform;
        Color currentColor = new Color(contrastBT, 1 - contrastBT, 210f / 255f * (1 - contrastBT));
        enemy.GetComponentInChildren<MeshRenderer>().material.SetColor("_Color", currentColor);

        Invoke("SpawnBadTarget", frequencyBadTarget);//chiamo ricorsivamente la funzione per generare altri oggetti in base alla loro frequenza di comparsa
    }

    void SpawnGoodTarget() {
        int iPref = GetIndexPrefab();
        int area = spawnAreas[rnd.Next(spawnAreas.Count)];
        float[] vel = GetVelocity(area, speedGoodTarget);
        Vector3 newPos = GetPosition(area, boundGT.y/2);
        GameObject goodTarget = Instantiate(friendPrefab[iPref], newPos, Quaternion.identity) as GameObject;
        goodTarget.GetComponent<Rigidbody>().velocity = new Vector2(vel[0], vel[1]);
        goodTarget.transform.parent = transform;
        Color currentColor = new Color(contrastGT, 1 - contrastGT, 210f / 255f * (1 - contrastGT));
        goodTarget.GetComponentInChildren<MeshRenderer>().material.SetColor("_Color", currentColor);

        Invoke("SpawnGoodTarget", frequencyGoodTarget);
    }

    int GetIndexPrefab() {//restituisce in modo casuale l'indice del prefab che poi verrà generato
        if (Random.Range(0.0f, 1.0f) < 0.75f)//per ora la percentuale è di 0.75 sul primo elemento da capire come dividere le probabilità e quanti target creare
            return 0;
        else
            return 1;
    }

    Vector3 GetPosition(int area, float yMin) {//restituisce la posizione dove verrà generato l'oggetto
        Vector3 pos = new Vector3();

        switch (area) {
            case 1://left-bot
                pos = new Vector3(botLeft.x, Random.Range(yMin, botLeft.y + screenDimensionY / 2), transform.position.z);
                totTargetLB++;
                break;
            case 2://left-top
                pos = new Vector3(botLeft.x, Random.Range(topRight.y - screenDimensionY / 2, topRight.y), transform.position.z);
                totTargetLT++;
                break;
            case 3://top-left
                pos = new Vector3(Random.Range(botLeft.x, botLeft.x + screenDimensionX / 2), topRight.y, transform.position.z);
                totTargetTL++;
                break;
            case 4://top-right
                pos = new Vector3(Random.Range(topRight.x - screenDimensionX / 2, topRight.x), topRight.y, transform.position.z);
                totTargetTR++;
                break;
            case 5://right-top
                pos = new Vector3(topRight.x, Random.Range(topRight.y - screenDimensionY / 2, topRight.y), transform.position.z);
                totTargetRT++;
                break;
            case 6://right-bot
                pos = new Vector3(topRight.x, Random.Range(yMin, botLeft.y + screenDimensionY / 2), transform.position.z);
                totTargetRB++;
                break;
        }
        return pos;
    }

    float[] GetVelocity(int area, float speed) {//restituisce le velocità nei 2 assi in base al parametro scelto dall'amministratore
        float[] vel = new float[2];
        bool diagonalTrajectory = false;
        if (Random.Range(0.0f, 1.0f) <= diagonalTrajectoryPercentage)//con probabilità del diagonalTrajectoryPercentage viene impostata una traiettoria diagonale oppure orizzontale
            diagonalTrajectory = true;

        switch (area) {//in base all'area da cui parte l'oggetto si impostano le giuste velocità(ogni area ha la sua traiettoria)
            case 1://left-bot
                vel[0] = speed;
                vel[1] = diagonalTrajectory ? speed / 5 : 0;
                break;
            case 2://left-top
                vel[0] = speed;
                vel[1] = diagonalTrajectory ? -speed / 5 : 0;
                break;
            case 3://top-left
                vel[0] = diagonalTrajectory ? speed : 0;
                vel[1] = -speed;
                break;
            case 4://top-right
                vel[0] = diagonalTrajectory ? -speed : 0;
                vel[1] = -speed;
                break;
            case 5://right-top
                vel[0] = -speed;
                vel[1] = diagonalTrajectory ? -speed / 5 : 0;
                break;
            case 6://right-bot
                vel[0] = -speed;
                vel[1] = diagonalTrajectory ? speed / 5 : 0;
                break;
        }
        return vel;
    }

}

