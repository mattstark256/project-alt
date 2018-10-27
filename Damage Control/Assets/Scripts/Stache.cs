using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stache : MonoBehaviour {

    RectTransform rectTransform;

    // Use this for initialization
    private void Start () {
        rectTransform = GetComponent<RectTransform>();
        StartCoroutine(WiggleMoustache());
    }
	
	//// Update is called once per frame
	//void Update () {
 //       rectTransform.localRotation = Quaternion.Euler(0, 0, Mathf.Sin(Time.time*20) * 5);

 //   }

    private IEnumerator WiggleMoustache()
    {
        float wiggle = 0;

        while (wiggle < 15)
        {
            wiggle += Time.deltaTime * 6;

            rectTransform.localRotation = Quaternion.Euler(0, 0, Mathf.Sin(wiggle * Mathf.PI * 2) * 4);

            yield return null;
        }
    }
}
