using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Popup", menuName = "Popup Window", order = 1)]
public class PopupSO : ScriptableObject
{
    [TextArea(5, 20)]
    public string popupText;
    public Popup popupPrefab;
    public string popupSound;
    public string popupTitle;
    public string popupSpeakerName;
    public Sprite popupSprite;
    public Color titleColor = Color.white;
}
