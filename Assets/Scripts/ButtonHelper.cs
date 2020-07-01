using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonHelper : MonoBehaviour
{
    public void OnStartOver()
    {
        SceneManager.LoadScene(0);
    }
}
