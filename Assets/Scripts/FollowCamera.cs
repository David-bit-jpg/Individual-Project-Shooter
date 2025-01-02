using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform target; 

    void LateUpdate()
    {
        if (target)
        {
            Vector3 newPosition = target.position;
            newPosition.z = transform.position.z; 
            transform.position = newPosition;
        }
    }
}
