using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    public enum PlayerState
    {
        Idle, MoveLeft, MoveRight, MoveForward, Win, Lose
    }

    public enum PlayerDirection
    {
        Middle, Right, Left
    }

    public static Game instance;
    public static PlayerState playerState = PlayerState.Idle;
    public static PlayerDirection playerDirection = PlayerDirection.Middle;
    public static bool noForward;
    public static bool noRight;
    public static bool noLeft;
    public static string station = "";
    public static int bonesNumber = 0;

    public Slider hungerometer;
    public Button startOver;

    private static bool collectABone = false;

    // Note that Awake happens on Play but before Start
    void Awake()
    {
        if (instance != null)
        {

            Debug.LogError("Singleton violation");
            return;
        }
        instance = this;
    }

    private void Start()
    {
        StartCoroutine("HungerometerDecrease");
    }

    private void Update()
    {
        if (collectABone)
        {
            collectABone = false;
            HungerometerIncrease();
        } 
    }

    public static void CollectBone()
    {
        bonesNumber++;
        collectABone = true;
    }

    public void Die()
    {
        Debug.Log("You Lose!");
        Game.playerState = Game.PlayerState.Lose;
        startOver.gameObject.SetActive(true);
    }

    private IEnumerator HungerometerDecrease()
    {
        while (hungerometer.value > 0 && playerState != PlayerState.Lose && playerState != PlayerState.Win) {
            yield return new WaitForSeconds(1.5f);
            hungerometer.value--;
        }
        Die();
    }

    private void HungerometerIncrease()
    {
        hungerometer.value++;
    }
}
