using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class push : MonoBehaviour
{
	public GameObject pushbox;
	public AudioSource triggerAC;
	void Start()
	{
		triggerAC = GetComponent<AudioSource>();
	}
	void OnTriggerEnter(Collider collider)
	{
		if(pushbox.name == collider.gameObject.name)
		{
			collider.gameObject.SetActive(false);
			pushbox.SetActive(false);
			triggerAC.Play();
		}
	}
}
