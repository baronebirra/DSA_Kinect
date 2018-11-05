using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerPrefsManager : MonoBehaviour {//preferenze utente

    const string MASTER_VOLUME_KEY = "master_volume";
    const string EFFECT_VOLUME_KEY = "effect_volume";
    const string SKELETON_KEY = "skeleton";

    public static void SetMasterVolume(float volume) {
        if (volume >= 0f && volume <= 1f)
            PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, volume);
        else
            Debug.LogError("Master volume out of range");
    }

    public static float GetMasterVolume() {
        return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY, 0.8f);
    }

    public static void SetEffectVolume(float volume) {
        if (volume >= 0f && volume <= 1f)
            PlayerPrefs.SetFloat(EFFECT_VOLUME_KEY, volume);
        else
            Debug.LogError("Effect volume out of range");
    }

    public static float GetEffectVolume() {
        return PlayerPrefs.GetFloat(EFFECT_VOLUME_KEY, 0.8f);
    }

    public static void SetSkeleton(bool visible) {
        PlayerPrefs.SetInt(SKELETON_KEY, visible ? 1 : 0);
    }

    public static bool GetSkeleton()    {
        return PlayerPrefs.GetInt(SKELETON_KEY, 1) == 1 ? true : false;
    }


}
