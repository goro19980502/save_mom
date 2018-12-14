using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]//必須要有AudioSource，任何加上此腳本的物件將自動加入AudioSource
public class OpeningMovie : MonoBehaviour
{

	public MovieTexture movTexture;//影片
	private AudioSource AS_mov;//影片音軌

	void Start()
	{
		GetComponent<RawImage>().texture = movTexture;
		AS_mov = GetComponent<AudioSource>();
		AS_mov.clip = movTexture.audioClip;//這個MovieTexture的音軌
		movTexture.Play();
		AS_mov.Play();
	}


	void Update()
	{
		if (!movTexture.isPlaying)
		{
			UnityEngine.SceneManagement.SceneManager.LoadScene("03_Map");//載入場景
		}
	}
}