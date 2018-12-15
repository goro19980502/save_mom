using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pushcollider : MonoBehaviour {


	public AudioSource colliderAC;
	void Start()
	{
		colliderAC = GetComponent<AudioSource>();
		colliderAC.Play();
	}
/*	void OnCollisionEnter(Collision collision)
	{
		colliderAC.Play();
	}*/
	void OnCollisionStay(Collision collision)
	{
		colliderAC.Play();
	}
}
