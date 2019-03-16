using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroy : MonoBehaviour {

    public float aliveTime; // Durée de vie du gameObject

	// Use this for initialization
	void Start () {
        Destroy(gameObject, aliveTime);

	}
}
