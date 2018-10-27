using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Plane", menuName = "Plane", order = 1)]
public class PlaneSO : ScriptableObject
{
    public string flightCode;
    public CountryName countryName;
    [Range(0, 3)]
    public int maxWaits = 0;
    [Tooltip("Used to determine how much of a negative impact failing to land the plane has on the country of origin"), Range(0f, 100f)]
    public int significanceValue = 10;

    public int passengerCount = 100;
    [Tooltip("Flavour text to hint at the significance of the plane")]
    public string additionalDetails;
    [Tooltip("Whether this plane should be highlighted as being especially significant")]
    public bool isCrucial;
}
