using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMenu : MonoBehaviour {

    [SerializeField]
    private GameObject gameMenuObject;

    private bool menuIsOpen = false;

	// Use this for initialization
	void Start () {
        gameMenuObject.SetActive(false);

    }
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (menuIsOpen)
            {
                CloseMenu();
            }
            else
            {
                OpenMenu();
            }
        }
	}

    public void OpenMenu()
    {
        menuIsOpen = true;
        Time.timeScale = 0;
        gameMenuObject.SetActive(true);
    }

    public void CloseMenu()
    {
        menuIsOpen = false;
        Time.timeScale = 1;
        gameMenuObject.SetActive(false);
    }
}
