using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Airport : MonoBehaviour
{
    public bool runwayInUse = false;
    public bool inNoFlyZone = false;
    public BlockedAirportIcon blockedIconPrefab;

    public bool IsAvailable
    {
        get { return (!runwayInUse && !inNoFlyZone); }
    }

    public void PutInNoFlyZone()
    {
        inNoFlyZone = true;
        Debug.Log("1 airport has been blocked");
        BlockedAirportIcon blockedIcon = Instantiate(blockedIconPrefab);
        blockedIcon.transform.SetParent(transform, false);
    }
}
