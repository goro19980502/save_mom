using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class te : MonoBehaviour {
	public float startTime;
	public Text text;
	public float Mp;
	public float MpMax;
	int lastsecs=0;
	int timeInt = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		showTime();
		if(lastsecs - timeInt == 1)
		{
			lastsecs = timeInt;
			this.transform.localPosition -= new Vector3(-120+120*(Mp/MpMax), 0.0f, 0.0f);
		}
	}
	string s;
	void showTime()
	{
		float nowTime = Time.time - startTime; //遊戲已執行時間
		timeInt = 120 - (int)nowTime;
		s = timeInt.ToString();
		text.text = "Time：" + s;
		Debug.Log("執行時間：" + s);
	}

	void rest()
	{
		startTime = Time.time;//更新遊戲時間
	}
}
