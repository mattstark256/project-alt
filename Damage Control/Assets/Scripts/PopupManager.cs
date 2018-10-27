using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupManager : MonoBehaviour
{
    public static PopupManager instance;

    [SerializeField]
    private Transform popupParent;

    private bool popupIsOpen = false;
    private List<PopupSO> queuedPopups = new List<PopupSO>(); // Used so that only one popup is visible on the screen at any one time.

    private void Awake()
    {
        if (instance == null) { instance = this; }
    }


    public void ShowPopup(PopupSO popupSO)
    {
        if (popupIsOpen)
        {
            queuedPopups.Add(popupSO);
        }
        else
        {
            CreatePopup(popupSO);
        }
    }


    // This must be called every time a popup is closed!!
    public void PopupHasBeenClosed()
    {
        popupIsOpen = false;
        if (queuedPopups.Count > 0)
        {
            CreatePopup(queuedPopups[0]);
            queuedPopups.RemoveAt(0);
        }
    }


    private void CreatePopup(PopupSO popupSO)
    {
        Popup newPopup = Instantiate(popupSO.popupPrefab);
        newPopup.transform.SetParent(popupParent, false);
        newPopup.transform.SetAsFirstSibling();
        newPopup.UpdateAppearance(popupSO);
        popupIsOpen = true;
    }
}
