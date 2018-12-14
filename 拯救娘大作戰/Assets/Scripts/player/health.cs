using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class health : MonoBehaviour {
	//血量設定

	public const int maxHealth = 120;

	public int currentHealth = maxHealth;

	//血量條

	public RectTransform HealthBar, Hurt;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//按下H鈕扣血
		if(currentHealth > 0)
		{
			currentHealth = currentHealth - 1 ;


		//將綠色血條同步到當前血量長度

			HealthBar.sizeDelta = new Vector2(currentHealth, HealthBar.sizeDelta.y);

			//呈現傷害量
			Hurt.sizeDelta += new Vector2(-1, 0);
		}

			


			

		

	}

}
