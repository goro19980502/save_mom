using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuControl : MonoBehaviour {

	public GameObject canvasIntroduce;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void OnStartGame(string SceneName)
	{
		Application.LoadLevel(SceneName);
	}
	public void OnExitGame()
	{
		Application.Quit();
	}
	public void OnIntroduceGame()
	{
		Instantiate(canvasIntroduce, Vector2.zero, Quaternion.identity);
	}
	public void OnDestroyIntroduce()
	{

		Destroy(canvasIntroduce);
	}
}
