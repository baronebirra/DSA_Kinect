using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoteVariables : MonoBehaviour {//script per la gestione delle variabili settate dal pannello amministratore

    public bool defaultBool = true;

    public float bubble_defaultPersistence = 1;
    public float bubble_defaultFrequency = 1;
    public float bubble_defaultContrast = 1f;
    public float bubble_defaultGameTime = 100f;

    public float keepAttention_defaultGameTime = 100f;
    public float keepAttention_defaultTargetSpeed = 1f;
    public float keepAttention_defaultFrequency = 1f;
    public float keepAttention_defaultContrast = 1f;
    public float keepAttention_defaultDiagonalTrajectoryPercentage = 0f;
    public float keepAttention_defaultTargetSpawnPercentage = 0.75f;
    public int keepAttention_defaultLife = 3;

    public float shape_defaultGameTime = 100f;
    public float shape_defaultWinningPercentage = 100;


    public static float bubble_persistence { get; private set; }
    public static float bubble_frequency { get; private set; }
    public static float bubble_contrast { get; private set; }
    public static float bubble_gameTime { get; private set; }
    public static bool bubble_topSx { get; private set; }
    public static bool bubble_topMiddle { get; private set; }
    public static bool bubble_topDx { get; private set; }
    public static bool bubble_bottomSx { get; private set; }
    public static bool bubble_bottomMiddle { get; private set; }
    public static bool bubble_bottomDx { get; private set; }
    public static bool bubble_leftHand { get; private set; }
    public static bool bubble_rightHand { get; private set; }
    public static bool bubble_leftFoot { get; private set; }
    public static bool bubble_rightFoot { get; private set; }

    public static float keepAttention_gameTime { get; private set; }
    public static float keepAttention_speedGoodTarget { get; private set; }
    public static float keepAttention_speedBadTarget { get; private set; }
    public static float keepAttention_frequencyGoodTarget { get; private set; }
    public static float keepAttention_frequencyBadTarget { get; private set; }
    public static float keepAttention_contrastGoodTarget { get; private set; }
    public static float keepAttention_contrastBadTarget { get; private set; }
    public static float keepAttention_diagonalTrajectoryPercentage { get; private set; }
    public static float keepAttention_targetSpawnPercentage { get; private set; }
    public static int keepAttention_life { get; private set; }
    public static bool keepAttention_leftBot { get; private set; }
    public static bool keepAttention_leftTop { get; private set; }
    public static bool keepAttention_topLeft { get; private set; }
    public static bool keepAttention_topRight { get; private set; }
    public static bool keepAttention_rightTop { get; private set; }
    public static bool keepAttention_rightBot { get; private set; }

    public static float shape_gameTime { get; private set; }
    public static float shape_winningPercentage { get; private set; }


    public static List<int> bubble_screenAreaEnabled = new List<int>();
    public static List<int> keepAttention_spawnAreaEnabled = new List<int>();

    private void Start() {
        bubble_persistence = bubble_defaultPersistence;
        bubble_contrast = bubble_defaultContrast;
        bubble_frequency = bubble_defaultFrequency;
        bubble_gameTime = bubble_defaultGameTime;
        bubble_topSx = bubble_topMiddle = bubble_topDx = bubble_bottomSx = bubble_bottomMiddle = bubble_bottomDx = bubble_leftHand = 
            bubble_rightHand = bubble_leftFoot = bubble_rightFoot = keepAttention_leftBot = keepAttention_leftTop = keepAttention_topLeft =
            keepAttention_topRight = keepAttention_rightTop = keepAttention_rightBot = true;

        keepAttention_gameTime = keepAttention_defaultGameTime;
        keepAttention_speedGoodTarget = keepAttention_speedBadTarget = keepAttention_defaultTargetSpeed;
        keepAttention_frequencyGoodTarget = keepAttention_frequencyBadTarget = keepAttention_defaultFrequency;
        keepAttention_contrastGoodTarget = keepAttention_contrastBadTarget = keepAttention_defaultContrast;
        keepAttention_life = keepAttention_defaultLife;
        keepAttention_targetSpawnPercentage = keepAttention_defaultTargetSpawnPercentage;
        keepAttention_diagonalTrajectoryPercentage = keepAttention_defaultDiagonalTrajectoryPercentage;

        shape_gameTime = shape_defaultGameTime;
        shape_winningPercentage = shape_defaultWinningPercentage;

        RemoteSettings.Updated += new RemoteSettings.UpdatedEventHandler(HandleRemoteUpdate);
    }

    private void HandleRemoteUpdate() {
        bubble_persistence = RemoteSettings.GetFloat("bubble_persistence", bubble_defaultPersistence);
        bubble_contrast = RemoteSettings.GetFloat("bubble_contrast", bubble_defaultContrast);
        bubble_gameTime = RemoteSettings.GetFloat("bubble_gameTime", bubble_defaultGameTime);
        bubble_frequency = RemoteSettings.GetFloat("bubble_frequency", bubble_defaultFrequency);
        bubble_topSx = RemoteSettings.GetBool("bubble_spawnAreaTopSxEnabled", defaultBool);
        bubble_topMiddle = RemoteSettings.GetBool("bubble_spawnAreaTopMidEnabled", defaultBool);
        bubble_topDx = RemoteSettings.GetBool("bubble_spawnAreaTopDxEnabled", defaultBool);
        bubble_bottomSx = RemoteSettings.GetBool("bubble_spawnAreaBotSxEnabled", defaultBool);
        bubble_bottomMiddle = RemoteSettings.GetBool("bubble_spawnAreaBotMidEnabled", defaultBool);
        bubble_bottomDx = RemoteSettings.GetBool("bubble_spawnAreaBotDxEnabled", defaultBool);

        bubble_leftHand = RemoteSettings.GetBool("bubble_limbsEnabledLeftHand", defaultBool);
        bubble_rightHand = RemoteSettings.GetBool("bubble_limbsEnabledRightHand", defaultBool);
        bubble_leftFoot = RemoteSettings.GetBool("bubble_limbsEnabledLeftFoot", defaultBool);
        bubble_rightFoot = RemoteSettings.GetBool("bubble_limbsEnabledRightFoot", defaultBool);

        keepAttention_leftBot = RemoteSettings.GetBool("keepAttention_spawnAreaLeftBotEnabled", defaultBool);
        keepAttention_leftTop = RemoteSettings.GetBool("keepAttention_spawnAreaLeftTopEnabled", defaultBool);
        keepAttention_topLeft = RemoteSettings.GetBool("keepAttention_spawnAreaTopLeftEnabled", defaultBool);
        keepAttention_topRight = RemoteSettings.GetBool("keepAttention_spawnAreaTopRightEnabled", defaultBool);
        keepAttention_rightTop = RemoteSettings.GetBool("keepAttention_spawnAreaRightTopEnabled", defaultBool);
        keepAttention_rightBot = RemoteSettings.GetBool("keepAttention_spawnAreaRightBotEnabled", defaultBool);
        keepAttention_gameTime = RemoteSettings.GetFloat("keepAttention_gameTime", keepAttention_defaultGameTime);
        keepAttention_speedGoodTarget = RemoteSettings.GetFloat("keepAttention_speedGoodTarget", keepAttention_defaultTargetSpeed);
        keepAttention_speedBadTarget = RemoteSettings.GetFloat("keepAttention_speedBadTarget", keepAttention_defaultTargetSpeed);
        keepAttention_frequencyGoodTarget = RemoteSettings.GetFloat("keepAttention_frequencyGoodTarget", keepAttention_defaultFrequency);
        keepAttention_frequencyBadTarget = RemoteSettings.GetFloat("keepAttention_frequencyBadTarget", keepAttention_defaultFrequency);
        keepAttention_contrastGoodTarget = RemoteSettings.GetFloat("keepAttention_contrastGoodTarget", keepAttention_defaultContrast);
        keepAttention_contrastBadTarget = RemoteSettings.GetFloat("keepAttention_contrastBadTarget", keepAttention_defaultContrast);
        keepAttention_diagonalTrajectoryPercentage = RemoteSettings.GetFloat("keepAttention_diagonalTrajectoryPercentage", keepAttention_defaultDiagonalTrajectoryPercentage);
        keepAttention_targetSpawnPercentage = RemoteSettings.GetFloat("keepAttention_targetSpawnPercentage", keepAttention_defaultTargetSpawnPercentage);
        keepAttention_life = RemoteSettings.GetInt("keepAttention_life", keepAttention_defaultLife);

        shape_gameTime = RemoteSettings.GetFloat("shape_gameTime", shape_defaultGameTime);
        shape_winningPercentage = RemoteSettings.GetFloat("shape_winningPercentage", shape_defaultWinningPercentage);

        SetSpawnListBubble();
        SetSpawnListKeepAttention();
    }

    private void SetSpawnListBubble() {
        if (bubble_topSx)
            bubble_screenAreaEnabled.Add(1);
        if (bubble_topMiddle)
            bubble_screenAreaEnabled.Add(2);
        if (bubble_topDx)
            bubble_screenAreaEnabled.Add(3);
        if (bubble_bottomSx)
            bubble_screenAreaEnabled.Add(4);
        if (bubble_bottomMiddle)
            bubble_screenAreaEnabled.Add(5);
        if (bubble_bottomDx)
            bubble_screenAreaEnabled.Add(6);
    }

    private void SetSpawnListKeepAttention() {
        if (keepAttention_leftBot)
            keepAttention_spawnAreaEnabled.Add(1);
        if (keepAttention_leftTop)
            keepAttention_spawnAreaEnabled.Add(2);
        if (keepAttention_topLeft)
            keepAttention_spawnAreaEnabled.Add(3);
        if (keepAttention_topRight)
            keepAttention_spawnAreaEnabled.Add(4);
        if (keepAttention_rightTop)
            keepAttention_spawnAreaEnabled.Add(5);
        if (keepAttention_rightBot)
            keepAttention_spawnAreaEnabled.Add(6);
    }

}
