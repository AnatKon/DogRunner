using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform target;
    public float springiness;
    public static Vector3 offsetPosition = new Vector3(0,2,-1);
    private Space offsetPositionSpace = Space.Self;
    private bool lookAt = true;

    void Start()
    {
        //offset = transform.position - target.position;
    }
    void Update()
    {
        Refresh();
        //transform.position = Vector3.Lerp(transform.position, target.position + offset, springiness * Time.deltaTime);
    }

    public void Refresh()
    {
        if (target == null)
        {
            Debug.LogWarning("Missing target ref !", this);

            return;
        }

        // compute position
        if (offsetPositionSpace == Space.Self)
        {
            transform.position = target.TransformPoint(offsetPosition);
        }
        else
        {
            transform.position = target.position + offsetPosition;
        }

        // compute rotation
        if (lookAt)
        {
            transform.LookAt(target);
        }
        else
        {
            transform.rotation = target.rotation;
        }
    }
}
