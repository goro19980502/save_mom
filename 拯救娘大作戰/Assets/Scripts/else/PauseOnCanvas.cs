using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseOnCanvas : MonoBehaviour {
	public GameObject canvasPrefab;
	void OnEnable()
	{
		//時間暫停
		Time.timeScale = 0f;
		Instantiate(canvasPrefab, Vector2.zero, Quaternion.identity);
	}

	void OnDisable()
	{
		//時間以正常速度運行
		Time.timeScale = 1f;
	}


}
