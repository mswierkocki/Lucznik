using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gracz : MonoBehaviour {
	public GameObject strzala;

	private float holdLength = 0;
	Animator anim;
	bool isWalking = false;
	bool isShooting = false;

	private float goraPlanszy = 4.3f;
	private float dolPlanszy = -2.5f;
    public float predkoscChodzenia = 5;
	void Start()
	{
		anim = GetComponent<Animator>();
	}
	// Update is called once per frame
	void Update()
	{
		if (Input.GetKey(KeyCode.W) && !isShooting && transform.position.y< goraPlanszy)
		{
            PrzesunDo(Vector3.up);
        }
		else if (Input.GetKey(KeyCode.S) && !isShooting && transform.position.y > dolPlanszy)
		{
            PrzesunDo(-Vector3.up);
		}
		else if (isWalking && !isShooting)
		{
            isWalking = false;
            anim.Play("idle");
		}


		if (Input.GetMouseButtonDown(0) && !isShooting)
		{
			anim.SetTrigger("charge");
			isShooting = true;
		}
		else if (Input.GetMouseButton(0) && isShooting)
		{
			holdLength += Time.deltaTime;
		}
		else if (Input.GetMouseButtonUp(0) && isShooting)
		{
			StartCoroutine(ShootCoroutine(holdLength));
		}
	}

    void PrzesunDo(Vector3 kierunek)
    {
        this.transform.position += kierunek * Time.deltaTime * predkoscChodzenia; 
        anim.Play("walk");
        if (!isWalking)
            isWalking = true;
    }


    IEnumerator ShootCoroutine(float power)
	{
		anim.SetTrigger("shoot");
		for (int i = 0; i < power; i++)
		{
			holdLength = 0;
			Instantiate(strzala, transform.position, transform.rotation);
			yield return new WaitForSeconds(0.1f);
		}
		isShooting = false;
	}


}
