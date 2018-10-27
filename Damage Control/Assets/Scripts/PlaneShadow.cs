using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneShadow : MonoBehaviour {

    public Vector3 positionOffset;
    public Transform parent;

    private void LateUpdate()
    {
        transform.position = parent.transform.position + positionOffset * parent.transform.localScale.x;
        transform.rotation = parent.transform.rotation;
    }
}
