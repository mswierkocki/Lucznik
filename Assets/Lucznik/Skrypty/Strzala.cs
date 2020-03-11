using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Strzala : MonoBehaviour {
    public float predkoscLotu = 10;
	void Start()
	{
		Destroy(this.gameObject, 5);
	}

	void Update () {
		this.transform.position += transform.right *  Time.deltaTime * predkoscLotu;
	}
}
