using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirportManager : MonoBehaviour
{
    [SerializeField]
    private Airport[] airports;


    public void ClearAirportRunways()
    {
        foreach (Airport airport in airports)
        {
            airport.runwayInUse = false;
        }
    }


    public int GetAvailableAirportCount()
    {
        int i = 0;
        foreach (Airport airport in airports)
        {
            if (airport.IsAvailable) { i++; }
        }
        return i;
    }


    public Airport GetNearestAirport(Vector3 position)
    {
        Airport nearestAirport = null;
        float shortestDistance = 0;
        foreach (Airport airport in airports)
        {
            if (airport.IsAvailable)
            {
                float distance = Vector3.Distance(airport.transform.position, position);
                if (nearestAirport == null ||
                    distance < shortestDistance)
                {
                    nearestAirport = airport;
                    shortestDistance = distance;
                }
            }
        }
        return nearestAirport;
    }
}
