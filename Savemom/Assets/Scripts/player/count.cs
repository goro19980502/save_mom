using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class count : MonoBehaviour {

	int SUM = 0;
    int len = 0;
	public GameObject[] eleobj;
	public GameObject GameWinnerCanvas;
	public GameObject UICanvas;
    public GameObject GameManager;
    void Start()
    {
        if (eleobj == null)
            eleobj = GameObject.FindGameObjectsWithTag("box");
        len = eleobj.Length;
    }
    void Update () {
        Debug.Log("eleobj.len" + eleobj.Length);
		for (int i = 0; i < len; i++)
		{
			if (eleobj[i].activeInHierarchy == false)
				SUM++;
			if (SUM == len)
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
