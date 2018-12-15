using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class main : MonoBehaviour {
	public GameObject UICanvas;
	//教學UI
	public Button btnOpen;
	public GameObject TutorialCanvas;
	//暫停UI
	//public Button stop;
	public GameObject PauseCanvas;
	//public Button Continues;
	//public Button Reply;
	//public Button BackMainMenu;
	//時間
	public Image HealthBar;
	bool TimeStartRest = false;
	public float startTime;
	public Text text;
	string s;
	// 角色
	public GameObject player;
	public GameObject GameOverCanvas;
	//終點
	public Collider other;

	void Start () {

		player.gameObject.SetActive(false);
		TutorialCanvas.SetActive(true);
		HealthBar = GetComponent<Image>();    //獲取Image元件

	}
	// Update is called once per frame
	void Update () {
		//showTime();
		if (TutorialCanvas.activeInHierarchy == false)
		{
			player.gameObject.SetActive(true);
			showTime();
			if(TimeStartRest == false)
			{
				rest();
				TimeStartRest = true;
			}	
		}
	}
	
	
	public void Click()
	{
		TutorialCanvas.SetActive(false);
	}
	
	
	
	
	
	// 時間
	void showTime()
	{
		float nowTime = Time.time - startTime; //遊戲已執行時間
		int timeInt = 120 - (int)nowTime;
		s = timeInt.ToString();
		text.text = "Time：" + s;
		Debug.Log("執行時間：" + s);
		UpdateHpBar(timeInt);
        if (timeInt == 0)
            GameOverCanvas.SetActive(true);
//			Instantiate(GameOverCanvas, Vector2.zero, Quaternion.identity);
	}
	void UpdateHpBar(int timeInt)
	{

//		HealthBar.fillAmount -= 0.1f;
	}
	void rest()
	{
		startTime = Time.time;//更新遊戲時間
	}
	public void OnEnableStop()
	{
		//時間暫停
		Time.timeScale = 0f;
		PauseCanvas.SetActive(true);
	}
	public void OnDisableStart()
	{
		//時間以正常速度運行
		PauseCanvas.SetActive(false);
		Time.timeScale = 1f;
	}

	//Pause Canvas
	public void ReplyGame()
	{
		rest();
		player.SetActive(false);
		TutorialCanvas.SetActive(true);
		Application.LoadLevel(Application.loadedLevel);
	}
	public void ContinueGame()
	{
		OnDisableStart();
		PauseCanvas.SetActive(false);
	}
	public void BackMenu()
	{
		Application.LoadLevel("03_Map");
	}

	// 終點
	void OnTriggerEnter()
	{
		Instantiate(GameOverCanvas, Vector2.zero, Quaternion.identity);
		UICanvas.SetActive(false);
	}

}
