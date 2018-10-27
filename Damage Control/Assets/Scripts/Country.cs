using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Country : MonoBehaviour
{
    public CountryName countryName;
    [Range(0, 100)]
    public float friendliness = 100;
    public Plane planePrefab;
    public CountryUI countryUI;
    public PopupSO hostilePopup;
    public PopupSO firstHostilePopup;
    public Airport[] blockableAirports;
    public GameObject noFlyZone;

    public Sprite happyFace;
    public Sprite neutralFace;
    public Sprite worriedFace;
    public Sprite angryFace;
    public Sprite hostileImage;

    public bool IsHostile { get { return friendliness == 0; } }

    private WaitSlot[] waitSlots;


    private void Awake()
    {
        waitSlots = GetComponentsInChildren<WaitSlot>();
    }


    private void Start()
    {
        countryUI.SetFriendliness(friendliness);
        countryUI.SetPortrait(GetRelationshipSprite());
        countryUI.SetName(name);
        noFlyZone.SetActive(false);
    }


    public WaitSlot GetAvailableWaitSlot()
    {
        foreach(WaitSlot waitSlot in waitSlots)
        {
            if (!waitSlot.isOccupied)
            {
                return waitSlot;
            }
        }
        return null;
    }


    public void DecreaseFrendliness(float amount)
    {
        if (IsHostile) return;
        friendliness -= amount;
        friendliness = Mathf.Clamp(friendliness, 0, 100);
        countryUI.SetFriendliness(friendliness);
        countryUI.SetPortrait(GetRelationshipSprite());
        //Debug.Log(name + "'s relationship with your country has been decreased by " + amount + " to " + friendliness);
        if (friendliness == 0)
        {
            //Debug.Log("They are now hostile!");
            CreateNoFlyZone();
            PopupManager.instance.ShowPopup(hostilePopup);
            if (GameController.instance.GetHostileCountryCount() == 1) { PopupManager.instance.ShowPopup(firstHostilePopup); }
            countryUI.StartFlipping();
        }
    }

    private void CreateNoFlyZone()
    {
        Debug.Log("no fly zone created");
        noFlyZone.SetActive(true);

        foreach (Airport airport in blockableAirports)
        {
            airport.PutInNoFlyZone();
        }

    }

    private Sprite GetRelationshipSprite()
    {
        if (friendliness > 75) return happyFace;
        else if (friendliness > 50) return neutralFace;
        else if (friendliness > 25) return worriedFace;
        else if (friendliness > 0) return angryFace;
        else return hostileImage;
    }
}
