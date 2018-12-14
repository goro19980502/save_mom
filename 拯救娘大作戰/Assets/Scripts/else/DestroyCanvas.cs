using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DestroyCanvas : MonoBehaviour {
    public GameObject canvas;
    void Start()
    {
        {
            GetComponent<Button>().onClick.AddListener(() => {
                PauseEvent();
            });
        }
    }
    void PauseEvent()
    {
        {
			canvas.SetActive(false);
            //Destroy(canvas);
        }


    }
}
