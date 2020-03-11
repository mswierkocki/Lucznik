using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour {
	Animator anim;
	bool canWalk = false;
	bool isDead = false;

	void Start () {
		anim = GetComponent<Animator>();
		StartWalking();
	}
	
	void Update () {
		if (canWalk)
		{
			this.transform.position += -transform.right * Time.deltaTime * 1f; 
		}
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag != "Enemy")
		{
			Destroy(col.gameObject);
			Die();
		}
	}

	void StartWalking()
	{
		StartCoroutine(Walk());
	}

	void Die()
	{
		anim.Play("dying");
		isDead = true;
		Destroy(gameObject,2);
		GetComponent<BoxCollider2D>().enabled = false;
	}

	void Hit()
	{
		anim.Play("hit");
		StopAllCoroutines();
		canWalk = false;
		Invoke("StartWalking", 0.6f);
	}

	IEnumerator Walk()
	{
		while (this.transform.position.x > -10 && !isDead)
		{
			canWalk = true;
			yield return new WaitForSeconds(0.6f);
			canWalk = false;
			yield return new WaitForSeconds(0.6f);
		}
	}
}
