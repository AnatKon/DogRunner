using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Road"))
        {
            if (tag.Equals("Forward"))
            {
                Game.noForward = false;
            } else if (tag.Equals("Right"))
            {
                Game.noRight = false;
            } else if (tag.Equals("Left"))
            {
                Game.noLeft = false;
            }
        } else
        {
            if (tag.Equals("Forward"))
            {
                Game.noForward = true;
            }
            else if (tag.Equals("Right"))
            {
                Game.noRight = true;
            }
            else if (tag.Equals("Left"))
            {
                Game.noLeft = true;
            }
        }
    }
}
