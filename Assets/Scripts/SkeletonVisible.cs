using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonVisible : MonoBehaviour {

	// Use this for initialization
	void Start () {
        gameObject.SetActive(PlayerPrefsManager.GetSkeleton());
	}
	
}
