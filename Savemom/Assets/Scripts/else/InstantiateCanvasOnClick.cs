using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InstantiateCanvasOnClick : MonoBehaviour {
    public GameObject canvasPrefab;
	// Use this for initialization
	void Start ()
    {
        GetComponent<Button>().onClick.AddListener (() => {
            ClickEvent();
        });
	}

    // Update is called once per frame
    //void Update () {
    void ClickEvent()
    {
        Instantiate(canvasPrefab, Vector2.zero, Quaternion.identity);
		//Destroy(this);
    }
}

