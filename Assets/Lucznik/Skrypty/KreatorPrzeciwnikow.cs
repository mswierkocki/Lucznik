using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KreatorPrzeciwnikow : MonoBehaviour {
	public GameObject zombie;
	// Use this for initialization
	void Start () {
		StartCoroutine(CreateEnemyLoop());	
	}

	IEnumerator CreateEnemyLoop()
	{
		do
		{
			CreateEnemy();
			yield return new WaitForSeconds(Random.Range(0.5f, 3));
		} while (true);
	}

	void CreateEnemy()
	{
		Instantiate(zombie, new Vector3(5.25f,Random.Range(2.4f,-2.5f),0), transform.rotation);
	}
}
