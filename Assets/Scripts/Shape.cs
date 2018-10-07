using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shape : MonoBehaviour {
    public static bool[] bodyPartsColliding = new bool[13];

    public static void SetCollidingPart(int i) {
        bodyPartsColliding[i] = true;
    }

    public static void UnsetCollidingPart(int i) {
        bodyPartsColliding[i] = false;
    }

    public static bool CheckShape() {
        for (int i = 0; i < bodyPartsColliding.Length; i++)
            if (bodyPartsColliding[i] == false)
                return false;
        return true;
    }

    public static float GetPercentageCompletition() {
        int count = 0;
        for (int i = 0; i < bodyPartsColliding.Length; i++)
            if (bodyPartsColliding[i] == true)
                count++;
        return count*100/(float)bodyPartsColliding.Length;
    }

    public static void Reset() {
        for (int i = 0; i < bodyPartsColliding.Length; i++)
            bodyPartsColliding[i] = false;
    }
}
