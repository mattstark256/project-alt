using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupStartGame : MonoBehaviour {

	public void StartGame()
    {
        GameController.instance.StartGame();
        GetComponent<Popup>().ClosePopup();
    }
}
