using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Goal : MonoBehaviour
{
    public Button startOver;

    private void Start()
    {
        startOver.gameObject.SetActive(false);
        Game.playerState = Game.PlayerState.Idle;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag.Equals("Player"))
        {
            Game.playerState = Game.PlayerState.Win;
            startOver.gameObject.SetActive(true);
        }
    }
}
