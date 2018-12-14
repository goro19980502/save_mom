using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class animateManagers : MonoBehaviour {
	public GameObject canvasPrefab;
	public Button btn;
	// Use this for initialization
	void Start () {
		btn = btn.GetComponent<Button>();
		btn.onClick.AddListener(convertCanvas);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void convertCanvas()
	{
		Instantiate(canvasPrefab, Vector2.zero, Quaternion.identity);
	}
	public void loadnextScenes(string ScenesName)
	{
		Application.LoadLevel(ScenesName);
	}
}
