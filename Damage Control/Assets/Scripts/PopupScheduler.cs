using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupScheduler : MonoBehaviour
{

    PopupManager popupManager;

    [SerializeField]
    private PopupSO turn1Popup, turn2Popup, turn3Popup, turn4Popup, turn5Popup;
    [SerializeField]
    private PopupSO introPopup;

    private void Awake()
    {
        popupManager = GetComponent<PopupManager>();
    }

    private void Start()
    {
        PopupManager.instance.ShowPopup(introPopup);
    }

    public void ShowPopupsForTurn(int turn)
    {
        if (turn == 1) { PopupManager.instance.ShowPopup(turn1Popup); }
        if (turn == 2) { PopupManager.instance.ShowPopup(turn2Popup); }
        if (turn == 3) { PopupManager.instance.ShowPopup(turn3Popup); }
        if (turn == 4) { PopupManager.instance.ShowPopup(turn4Popup); }
        if (turn == 5) { PopupManager.instance.ShowPopup(turn5Popup); }
    }
}
