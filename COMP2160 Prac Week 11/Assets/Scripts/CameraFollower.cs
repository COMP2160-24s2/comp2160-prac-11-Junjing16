using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    public Transform marble;   
    void Update()
    {
        if (marble != null)
        {
            transform.position = marble.position;
        }
    }

    
    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;  
        Gizmos.DrawWireSphere(transform.position, 0.5f);  
    }
}
