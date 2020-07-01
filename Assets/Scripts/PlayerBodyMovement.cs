using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBodyMovement : MonoBehaviour
{
    public static readonly Vector3 movementGap = new Vector3(0.3f, 0, 0);
    public static readonly Vector3 movementGap90 = new Vector3(0, 0, 0.3f);
    public static readonly Vector3 forwardPosition = Vector3.zero;
    public static readonly Vector3 leftPosition = new Vector3(-0.3f, 0, 0);
    public static readonly Vector3 rightPosition = new Vector3(0.3f, 0, 0);

    public float moveSpeed = 1;

    // Start is called before the first frame update
    void Start()
    {
        transform.localPosition = forwardPosition;
        transform.localRotation = Quaternion.identity;
        Game.playerState = Game.PlayerState.Idle;
    }

    // Update is called once per frame
    void Update()
    {
        if (Game.playerState == Game.PlayerState.Idle)
        {
            transform.parent.transform.Translate(new Vector3(0, 0, moveSpeed) * Time.deltaTime);


#if UNITY_STANDALONE
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                ChangeDirection(Game.PlayerDirection.Left);
            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                ChangeDirection(Game.PlayerDirection.Right);
            }
#elif UNITY_EDITOR || UNITY_ANDROID
            AndroidMovement();
#endif
        }
        else
        {
            //StartCoroutine("WaitAndGo");
            if (Game.playerState == Game.PlayerState.MoveForward)
            {
                MoveForward();
            }
            else if (Game.playerState == Game.PlayerState.MoveRight)
            {
                MoveRight();
            }
            else if (Game.playerState == Game.PlayerState.MoveLeft)
            {
                MoveLeft();
            }
        }
    }

    public void MoveLeft()
    {
        if (Game.noLeft)
        {
            if (Game.noForward)
            {
                if((transform.parent.transform.eulerAngles.y == 0 || transform.parent.transform.eulerAngles.y % 360 == 180) && (Game.station.Equals("LeftDirection2") || Game.station.Equals("RightDirection1")))
                {
                    Debug.Log(transform.parent.transform.eulerAngles.y % 360);

                    RotatePlayerAndCamera();
                }
                else if((transform.parent.transform.eulerAngles.y % 360 == 90 || transform.parent.transform.eulerAngles.y % 360 == 270) && (Game.station.Equals("LeftDirection1") || Game.station.Equals("RightDirection2")))
                {
                    RotatePlayerAndCamera();
                }
            }
        }
        else
        {
            RotatePlayerAndCamera();
        }
        Game.playerState = Game.PlayerState.Idle;
    }

    public void MoveRight()
    {
        if (Game.noRight)
        {
            if (Game.noForward)
            {
                if ((transform.parent.transform.eulerAngles.y == 0 || transform.parent.transform.eulerAngles.y % 360 == 180) && (Game.station.Equals("LeftDirection1") || Game.station.Equals("RightDirection2")))
                {
                    RotatePlayerAndCamera();
                }
                else if ((transform.parent.transform.eulerAngles.y % 360 == 90 || transform.parent.transform.eulerAngles.y % 360 == 270) && (Game.station.Equals("LeftDirection2") || Game.station.Equals("RightDirection1")))
                {
                    RotatePlayerAndCamera();
                }
            }
        } else
        {
            RotatePlayerAndCamera();
        }
        Game.playerState = Game.PlayerState.Idle;
    }

    public void MoveForward()
    {
        if (Game.noForward)
        {
            if (Game.noRight)
            {
                Game.playerState = Game.PlayerState.MoveLeft;
            }
            else if (Game.noLeft)
            {
                Game.playerState = Game.PlayerState.MoveRight;
            }
            else
            {
                int rand = Random.Range(0, 1);
                if (rand == 0)
                {
                    Game.playerState = Game.PlayerState.MoveLeft;
                }
                else
                {
                    Game.playerState = Game.PlayerState.MoveRight;
                }
            }
        } else
        {
            Game.playerState = Game.PlayerState.Idle;
        }
    }

    private void RotatePlayerAndCamera()
    {
        Vector3 v = transform.parent.transform.position;
        if (transform.parent.transform.eulerAngles.y == 0)
        {
            transform.parent.transform.position = new Vector3(v.x, v.y, v.z + 0.3f);
        } 
        else if (transform.parent.transform.eulerAngles.y % 360 == 90)
        {
            transform.parent.transform.position = new Vector3(v.x + 0.3f, v.y, v.z);
        }
        else if (transform.parent.transform.eulerAngles.y % 360 == 270)
        {
            transform.parent.transform.position = new Vector3(v.x - 0.3f, v.y, v.z);
        }
        else if (transform.parent.transform.eulerAngles.y % 360 == 180)
        {
            transform.parent.transform.position = new Vector3(v.x, v.y, v.z - 0.3f);
        }
        Debug.Log(Game.noRight);
        transform.parent.transform.Rotate(0, 90, 0);
    }

    private void ChangeDirection(Game.PlayerDirection movement)
    {
        if(Game.playerDirection == Game.PlayerDirection.Left)
        {
            if(movement == Game.PlayerDirection.Right)
            {
                ChangeDirectionInner(1);
                Game.playerDirection = Game.PlayerDirection.Middle;
            }
        }
        else if (Game.playerDirection == Game.PlayerDirection.Right)
        {
            if (movement == Game.PlayerDirection.Left)
            {
                ChangeDirectionInner(-1);
                Game.playerDirection = Game.PlayerDirection.Middle;
            }
        }
        else if (Game.playerDirection == Game.PlayerDirection.Middle)
        {
            if (movement == Game.PlayerDirection.Right)
            {
                ChangeDirectionInner(1);
                Game.playerDirection = Game.PlayerDirection.Right;
            }
            else if (movement == Game.PlayerDirection.Left)
            {
                ChangeDirectionInner(-1);
                Game.playerDirection = Game.PlayerDirection.Left;
            }
        }
    }

    private void ChangeDirectionInner(int n)
    {
        if (transform.parent.transform.eulerAngles.y == 0)
        {
            transform.parent.transform.position += n * movementGap;
        }
        else if (transform.parent.transform.eulerAngles.y % 360 == 90)
        {
            transform.parent.transform.position -= n * movementGap90;
        }
        else if (transform.parent.transform.eulerAngles.y % 360 == 180)
        {
            transform.parent.transform.position -= n * movementGap;
        }
        else if (transform.parent.transform.eulerAngles.y % 360 == 270)
        {
            transform.parent.transform.position += n * movementGap90;
        }

    }
    private void AndroidMovement()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            Vector2 touchPosition = Input.GetTouch(0).position;
            double halfScreen = Screen.width / 2.0;
            double halfScreen1 = Screen.height / 2.0;

            //Check if it is left or right?
            if (touchPosition.x < halfScreen)
            {
                ChangeDirection(Game.PlayerDirection.Left);
            }
            else if (touchPosition.x > halfScreen)
            {
                ChangeDirection(Game.PlayerDirection.Right);
            }
        }
    }
}
