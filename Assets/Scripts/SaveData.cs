using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
//using UnityEditor;

public class SaveData : MonoBehaviour {
    public int gameN;
    private string fileName;

    // Use this for initialization
    void Start () {
        System.DateTime date = System.DateTime.Now;
        string filePath;
        //This is the writer, it writes to the filepath
        StreamWriter writer;

        switch (gameN) {
            case 1://bubble
                fileName = date.ToString("yyyy-MM-dd_HH-mm-ss") + "_Bubble_" + LoginManager.username + ".csv";
                filePath = getPath();

                //writer = File.CreateText(filePath);// new StreamWriter(Application.persistentDataPath + "/" + fileName);
                writer = new StreamWriter(filePath, false, System.Text.Encoding.UTF8);

                writer.WriteLine("Scheda uscita dati, Administrator: ");
                writer.WriteLine("Nome operatore: ");
                writer.WriteLine("Nome giocatore: " + LoginManager.username + "," + "Data: " + date.ToString("dd/MM/yyyy") + "," + "Orario: " + date.ToString("HH:mm:ss"));
                writer.WriteLine("Gioco: Bubble");
                writer.WriteLine("Tempo di gioco,Bolle presentate in totale,Frequenza di comparsa della bolla,Contrasto,Persistenza bolla," +
                    "Bolle presentate in alto a sinistra,Bolle presentate in alto al centro,Bolle presentate in alto a destra," +
                    "Bolle presentate in basso a sinistra,Bolle presentate in basso al centro,Bolle presentate in basso a destra," +
                    "Bolle colpite con la mano dx,Bolle colpite con la mano sx,Bolle colpite con il piede dx,Bolle colpite con il piede sx");
                writer.WriteLine(RemoteVariables.bubble_gameTime.ToString() + "," + BubbleSpawner.timeElapsedBubbles.Count.ToString() + "," +
                    RemoteVariables.bubble_frequency.ToString() + "," + RemoteVariables.bubble_contrast.ToString() + "," + RemoteVariables.bubble_persistence.ToString() + "," +
                    BubbleSpawner.totBubbleTSx.ToString() + "," + BubbleSpawner.totBubbleTop.ToString() + "," + BubbleSpawner.totBubbleTDx.ToString() + "," +
                    BubbleSpawner.totBubbleBSx.ToString() + "," + BubbleSpawner.totBubbleBot.ToString() + "," + BubbleSpawner.totBubbleBDx.ToString() + "," +
                    ScoreKeeper.totHandRx.ToString() + "," + ScoreKeeper.totHandLx.ToString() + "," + ScoreKeeper.totFootRx.ToString() + "," + ScoreKeeper.totFootLx.ToString());
                writer.WriteLine("Numero bolla, Tempo che intercorre tra la comparsa e lo scoppio della bolla");
                for (int i = 0; i < BubbleSpawner.timeElapsedBubbles.Count; ++i) {
                    writer.WriteLine((i+1).ToString() + "," + BubbleSpawner.timeElapsedBubbles[i].ToString());
                }

                writer.Flush();
                //This closes the file
                writer.Close();

                break;
            case 2://KA
                fileName = date.ToString("yyyy-MM-dd_HH-mm-ss") + "_KeepAttention_" + LoginManager.username + ".csv";
                filePath = getPath();
                writer = new StreamWriter(filePath, false, System.Text.Encoding.UTF8);

                writer.WriteLine("Scheda uscita dati, Administrator: ");
                writer.WriteLine("Nome operatore: ");
                writer.WriteLine("Nome giocatore: " + LoginManager.username + "," + "Data: " + date.ToString("dd/MM/yyyy") + "," + "Orario: " + date.ToString("HH:mm:ss"));
                writer.WriteLine("Gioco: Keep Attention");
                writer.WriteLine("Tempo di gioco,Frequenza target +,Frequenza target -,Velocità target +,Velocità target -,% Traiettoria obliqua," +
                    "Contrasto target +,Contrasto target -,Vite a disposizione,Punteggio raggiunto,Target che arrivano da sinistra(parte bassa)," +
                    "Target che arrivano da sinistra(parte alta),Target che cadono dall'alto(parte sinistra)," +
                    "Target che cadono dall'alto(parte destra),Target che arrivano da destra(parte alta),Target che arrivano da destra(parte bassa)");
                writer.WriteLine(RemoteVariables.keepAttention_gameTime.ToString() + "," + RemoteVariables.keepAttention_frequencyGoodTarget.ToString() + "," +
                    RemoteVariables.keepAttention_frequencyBadTarget.ToString() + "," + RemoteVariables.keepAttention_speedGoodTarget.ToString() + "," +
                    RemoteVariables.keepAttention_speedBadTarget.ToString() + "," + RemoteVariables.keepAttention_diagonalTrajectoryPercentage.ToString()
                    + "," + RemoteVariables.keepAttention_contrastGoodTarget.ToString() + "," + RemoteVariables.keepAttention_contrastBadTarget.ToString()
                    + "," + RemoteVariables.keepAttention_life.ToString() + "," + ScoreKeeperKA.score.ToString() + "," + 
                    Spawner.totTargetLB.ToString() + "," + Spawner.totTargetLT.ToString() + "," + Spawner.totTargetTL.ToString() + "," + 
                    Spawner.totTargetTR.ToString() + "," + Spawner.totTargetRT.ToString() + "," + Spawner.totTargetRB.ToString());

                writer.Flush();
                //This closes the file
                writer.Close();

                break;
            case 3://shape
                fileName = date.ToString("yyyy-MM-dd_HH-mm-ss") + "_Shape_" + LoginManager.username + ".csv";
                filePath = getPath();
                writer = new StreamWriter(filePath, false, System.Text.Encoding.UTF8);

                writer.WriteLine("Scheda uscita dati, Administrator: ");
                writer.WriteLine("Nome operatore: ");
                writer.WriteLine("Nome giocatore: " + LoginManager.username + "," + "Data: " + date.ToString("dd/MM/yyyy") + "," + "Orario: " + date.ToString("HH:mm:ss"));
                writer.WriteLine("Gioco: Shape");
                writer.WriteLine("Tempo di gioco,Livello di difficoltà,Numero figure proposte,Figure realizzate");
                writer.WriteLine(RemoteVariables.shape_gameTime.ToString() + "," + "," + "," + ShapeProgress.shapeCompleted.ToString());
                writer.WriteLine("Numero figura,% Completamento");

                writer.Flush();
                //This closes the file
                writer.Close();

                break;
        }
    }

    private string getPath() {
        #if UNITY_EDITOR
            Directory.CreateDirectory(Application.dataPath + "/CSV/");
            return Path.Combine(Application.dataPath, "CSV/" + fileName);
        #elif UNITY_ANDROID
            return Application.persistentDataPath+fileName;
        #elif UNITY_IPHONE
            return Application.persistentDataPath+"/"+fileName;
        #else
            Directory.CreateDirectory(Application.dataPath + "/CSV/");
            return Path.Combine(Application.dataPath, "CSV/" + fileName);
        #endif
    }


}
