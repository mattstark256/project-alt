using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitSlot : MonoBehaviour
{
    [HideInInspector]
    public bool isOccupied;

    void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawLine(transform.position, transform.position + transform.rotation * Vector3.left * 1000);
    }
}
