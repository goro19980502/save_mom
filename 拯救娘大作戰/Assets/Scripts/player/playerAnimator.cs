using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAnimator : Touch
{
	public GameObject[] eleobj;
	public Animator anim;
	public float speedX, speedY,JumpSpeed,xForce;
	private Rigidbody PlayerRigidbody;
	bool jumping = false;
	bool isGround = false;
	int ver = 3;
	void Start()
	{
		anim = GetComponentInChildren<Animator>();
		PlayerRigidbody = GetComponent<Rigidbody>();
		if (eleobj == null)
			eleobj = GameObject.FindGameObjectsWithTag("wallbox");
	}

	// Update is called once per frame
	void Update()
	{
		UpdateTouch();
//		OnMove();
	}
	void FixedUpdate()
	{
		if(x == true)
		{
			OnMove();
		}
	}
	void OnMove()
	{
		
		if (Gesture == gDefine.Direction.Left && x == true)
		{
			ver = 2;
			anim.SetTrigger("running");
			print("!!!Left");
			anim.transform.rotation = Quaternion.Euler(0, 270, 0);
			PlayerRigidbody.AddForce(new Vector3(-10000, 0, 0));
		}
		else if (Gesture == gDefine.Direction.Right && x == true)
		{
			ver = 3;
			anim.SetTrigger("running");
			anim.transform.rotation = Quaternion.Euler(0, 90, 0);
			PlayerRigidbody.AddForce(new Vector3(10000, 0, 0));
		}

		else if (Gesture == gDefine.Direction.Up && x == true)
		{
			if(jup == 0 && ver == 2)
			{
				print("!!!LeftUP");
				anim.SetTrigger("Jumping");
				PlayerRigidbody.AddForce(-4000, 25000, 0);
				jup = 1;
			}
			else if(jup == 0 && ver == 3)
			{
				print("!!!RightUP");
				anim.SetTrigger("Jumping");
				PlayerRigidbody.AddForce(4000, 25000, 0);
				jup = 1;
			}
			
		}
/*		else if (Gesture == gDefine.Direction.Left_Up && x == true)
		{
			print("!!!Left_UP");
			anim.SetTrigger("Jumping");
			PlayerRigidbody.AddForce(-4000, 25000, 0);
		}
		else if (Gesture == gDefine.Direction.Right_Up && x == true)
		{
			print("!!!Right_UP");
			anim.SetTrigger("Jumping");
			PlayerRigidbody.AddForce(4000, 25000, 0);
		}*/
		else
		{
			anim.SetTrigger("wait");
		}
		anim.SetTrigger("wait");
		print(anim.transform.position);
	}
	int jup = 0;

	void OnCollisionEnter(Collision collision)
	{
		jup = 0;
		if (collision.gameObject.tag == "wallbox" || collision.gameObject.tag == "box")
			anim.SetTrigger("push");
	}


}
