using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonesCollector : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            Game.CollectBone();
            Destroy(this.gameObject);
        }
    }
}
