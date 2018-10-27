using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlaneInfo : MonoBehaviour
{

    public Text infoText;
    public Text flavorText;
    public Image flavorTextBackground;

    public float flashInterval = 0.3f;

    private bool isCrucial;
    private Color defaultColor;


    private void Awake()
    {
        defaultColor = flavorTextBackground.color;
    }


    private void Update()
    {
        if (isCrucial)
        {
            if (Time.time % flashInterval < flashInterval / 2)
            { flavorTextBackground.color = defaultColor; }
            else
            { flavorTextBackground.color = Color.red; }
        }
    }


    public void ShowInfo(Plane plane)
    {
        string info = "";
        info += "Flight: " + plane.planeSO.flightCode;
        info += "\n";
        info += "Passengers: " + plane.planeSO.passengerCount;
        info += "\n";

        if (plane.RemainingWaits == 0)
        { info += "Fuel: Needs to land"; }
        else if (plane.RemainingWaits == 1)
        { info += "Fuel: Can wait 1 turn"; }
        else
        { info += "Fuel: Can wait " + plane.RemainingWaits + " turns"; }

        infoText.text = info;

        if (plane.planeSO.additionalDetails == "")
        {
            Destroy(flavorTextBackground.gameObject);
        }
        else
        {
            flavorText.text = plane.planeSO.additionalDetails;
            isCrucial = plane.planeSO.isCrucial;
        }
    }


    public void Dissappear()
    {
        Destroy(gameObject);
    }
}
