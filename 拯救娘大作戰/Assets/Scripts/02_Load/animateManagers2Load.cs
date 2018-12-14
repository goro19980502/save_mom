using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class animateManagers2Load : MonoBehaviour {
	public Button btn;
	// Use this for initialization
	void Start()
	{
		btn = btn.GetComponent<Button>();
		btn.onClick.AddListener(OnLoadScenes);
	}
	public void OnLoadScenes()
	{
		Application.LoadLevel(2);
	}
}
