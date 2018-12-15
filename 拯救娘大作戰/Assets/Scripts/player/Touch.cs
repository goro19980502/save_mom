using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class gDefine
{

    public enum Direction
    {
		none,
		Left,
		Left_Up,
        Right,
		Right_Up,
        Up,
        Down,
        ZoomIn,
        ZoomDown,
        
    }
}

public class Touch : MonoBehaviour {

    //紀錄手指觸碰位置
    private Vector2 m_screenPos = new Vector2();
	public bool x = false;
    public static gDefine.Direction Gesture;

    public void UpdateTouch()
    {

#if UNITY_EDITOR || UNITY_STANDALONE
        MouseInput();   // 滑鼠偵測
#elif UNITY_ANDROID
		MobileInput();  // 觸碰偵測
#endif
    }

    void MouseInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
			x = true;
            m_screenPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        }
		else
		{
			x = false;
		}
        if (Input.GetMouseButtonUp(0))
        {
            Vector2 pos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

            gDefine.Direction mDirection = HandDirection(m_screenPos, pos);
            Gesture = mDirection;
            print(Gesture);
        }
		
		
	}

    void MobileInput()
    {
        if (Input.touchCount <= 0)
		{
			x = false;
			return ;
		}
            

        //1個手指觸碰螢幕
        if (Input.touchCount == 1)
        {
			x = true;
            Vector2 finger = new Vector2();
            //開始觸碰
            if (Input.touches[0].phase == TouchPhase.Began)
            {
                //紀錄觸碰位置
                m_screenPos = Input.touches[0].position;
            }
            else if (Input.touches[0].phase == TouchPhase.Moved)
            {
                Debug.Log("Moved");
            }


            //手指離開螢幕
            if (Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
            {
                finger = Input.touches[0].position;

                gDefine.Direction mDirection = HandDirection(m_screenPos, finger);
                Gesture = mDirection;
            }

        }
        else if (Input.touchCount > 1)
        {
            //記錄兩個手指位置
            Vector2[] fingerStart = new Vector2[2];

            Vector2[] fingerEnd = new Vector2[2];

            //是否是小於2點觸碰
            for (int i = 0; i < 2; i++)
            {
                UnityEngine.Touch touch = UnityEngine.Input.touches[i];

                if (touch.phase == TouchPhase.Began)
                {
                    //紀錄觸碰位置
                    fingerStart[i] = touch.position;
                }

                if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled || touch.phase == TouchPhase.Moved) {
                    fingerEnd[i] = touch.position;
                }

            }//end for

            gDefine.Direction mDirection0 = HandDirection(fingerStart[0], fingerEnd[0]);
            gDefine.Direction mDirection1 = HandDirection(fingerStart[1], fingerEnd[1]);

            if (Vector2.Distance(fingerStart[0], fingerStart[1]) > Vector2.Distance(fingerEnd[0], fingerEnd[1]))
            {
                    Gesture = gDefine.Direction.ZoomIn;
            }
            else if (mDirection0 == gDefine.Direction.Down && mDirection1 == gDefine.Direction.Down)
            {
                Gesture = gDefine.Direction.ZoomDown;
            }
            else {
                Gesture = mDirection0;
            }

        }//end else if 
    }//end void

    gDefine.Direction HandDirection(Vector2 StartPos, Vector2 EndPos)
    {
        gDefine.Direction mDirection = gDefine.Direction.none;
        float xDiff = EndPos.x - StartPos.x;
        float yDiff = EndPos.y - StartPos.y;
        float slope = Mathf.Abs(yDiff / xDiff);
		if (Mathf.Abs(StartPos.x - EndPos.x) > Mathf.Abs(StartPos.y - EndPos.y))
        {
			
            if (StartPos.x > EndPos.x)
            {
				print("Left");
				//手指向左滑動
				mDirection = gDefine.Direction.Left;
            }
            else
            {
				print("Right");
				//手指向右滑動
				mDirection = gDefine.Direction.Right;
            }
        }
		else if(Mathf.Abs(StartPos.x - EndPos.x) == Mathf.Abs(StartPos.y - EndPos.y))
		{
			x = false;
			mDirection = gDefine.Direction.none;
		}
        else if (slope <= 2 && slope >= 0.5)
        {
            if (StartPos.x > EndPos.x)
            {
                mDirection = gDefine.Direction.Left_Up;
            }
            else if(EndPos.x > StartPos.x)
            {
                mDirection = gDefine.Direction.Right_Up;
            }
        }
        else
        {
            if (m_screenPos.y > EndPos.y)
            {
                //手指向下滑動
                mDirection = gDefine.Direction.Down;
            }
            else
            {
                //手指向上滑動
                mDirection = gDefine.Direction.Up;
            }
        }
        return mDirection;

    }
}
