using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class count : MonoBehaviour {

	int SUM = 0;
	public GameObject[] eleobj;
	public GameObject GameWinnerCanvas;
	public GameObject UICanvas;
    public GameObject GameManager;
	void Update () {
		if (eleobj == null)
			eleobj = GameObject.FindGameObjectsWithTag("box");

		for (int i = 0; i < eleobj.Length; i++)
		{
			if (eleobj[i].activeInHierarchy == false)
				SUM++;
			if (SUM == eleobj.Length)
			{
				OnWinnerGame();
			}
		}
	}
	void OnWinnerGame()
	{
		GameWinnerCanvas.SetActive(true);
		UICanvas.SetActive(false);
        GameManager.SetActive(false);
	}
}
