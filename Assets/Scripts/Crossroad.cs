using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crossroad : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (Game.playerState == Game.PlayerState.Idle)
        {

            if (other.tag.Contains("Direction") && Game.playerDirection == Game.PlayerDirection.Left)
            {
                Game.playerState = Game.PlayerState.MoveLeft;
                Game.station = other.tag;
            }
            if (other.tag.Contains("Direction") && Game.playerDirection == Game.PlayerDirection.Right)
            {
                Game.playerState = Game.PlayerState.MoveRight;
                Game.station = other.tag;
            }
            if (other.tag.Equals("Middle") && Game.playerDirection == Game.PlayerDirection.Middle)
            {
                Game.playerState = Game.PlayerState.MoveForward;
                Game.station = other.tag;
            }
        }
    }
}
