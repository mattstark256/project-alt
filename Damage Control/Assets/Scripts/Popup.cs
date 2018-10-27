using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Popup : MonoBehaviour {

    public Text messageText;
    public Text titleText;
    public Text speakerText;
    public Image portrait;

    public void UpdateAppearance(PopupSO popupSO)
    {
        messageText.text = popupSO.popupText;

        SoundEffectManager.instance.PlayEffect(popupSO.popupSound);

        titleText.text = popupSO.popupTitle;
        titleText.color = popupSO.titleColor;

        speakerText.text = popupSO.popupSpeakerName;

        if (popupSO.popupSprite != null)
        {
            portrait.enabled = true;
            portrait.sprite = popupSO.popupSprite;
        }
        else
        {
            portrait.enabled = false;
        }


    }

    public void ClosePopup()
    {
        PopupManager.instance.PopupHasBeenClosed();
        Destroy(gameObject);
    }
}
