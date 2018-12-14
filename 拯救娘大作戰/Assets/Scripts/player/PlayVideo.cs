using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayVideo : MonoBehaviour {

	// Use this for initialization
	void Start()
	{
		Handheld.PlayFullScreenMovie("operater.mp4", Color.black, FullScreenMovieControlMode.CancelOnInput);
	}

	// Update is called once per frame
	void Update () {
		
	}
	void closevideo()
	{
//		canvas.SetActive(false);
	}
}
