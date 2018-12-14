using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadScenes : MonoBehaviour {
	
	public int a;
	public void OnLoadScenes(string SceneName)
	{
		Application.LoadLevel(SceneName);
	}
	public void OnLoad()
	{
		Application.LoadLevel(a);
	}
}
