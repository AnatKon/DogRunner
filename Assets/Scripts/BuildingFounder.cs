using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingFounder : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (Game.playerState == Game.PlayerState.Idle)
        {
            if (other.tag.Equals("Road"))
            {
                if (tag.Equals("Forward"))
                {
                    Game.noForward = false;
                }
                if (tag.Equals("Left"))
                {
                    Game.noLeft = false;
                }
                if (tag.Equals("Right"))
                {
                    Game.noRight = false;
                }
            }
            if (other.tag.Equals("Building"))
            {
                if (tag.Equals("Forward"))
                {
                    Game.noForward = true;
                }
                if (tag.Equals("Right"))
                {
                    Game.noRight = true;
                }
                if (tag.Equals("Left"))
                {
                    Game.noLeft = true;
                }
            }
        }
    }
}
