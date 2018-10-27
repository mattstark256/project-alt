using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane : MonoBehaviour
{
    private float waitCircleRadius = 80;

    [HideInInspector]
    public PlaneSO planeSO;
    [HideInInspector]
    public WaitSlot waitSlot;
    [HideInInspector]
    public Country country;

    const float arriveDistance = 1000;

    public int RemainingWaits
    {
        get;
        set;
    }

    public bool isSelected;


    private void Start()
    {
        RemainingWaits = planeSO.maxWaits;
    }


    public void Arrive(float duration)
    {
        StartCoroutine(ArriveCoroutine(duration));
    }


    private IEnumerator ArriveCoroutine(float duration)
    {
        float f = 0;
        while (f < 1)
        {
            f += Time.deltaTime / duration;
            f = Mathf.Clamp01(f);

            transform.localPosition = (Vector3.right * (f - 1)) * arriveDistance;

            yield return null;
        }
    }

    public void Land(float duration, Airport airport)
    {
        StartCoroutine(LandCoroutine(duration, airport));
    }

    private IEnumerator LandCoroutine(float duration, Airport airport)
    {
        duration *= 0.7f;

        transform.parent = null;
        Vector3 startPosition = transform.position;
        Vector3 endPosition = airport.transform.position;
        Vector3 startScale = transform.localScale;
        transform.rotation = Quaternion.Euler(0, 0, Vector2.SignedAngle(Vector2.right, endPosition-startPosition));

        float f = 0;
        while (f < 1)
        {
            f += Time.deltaTime / duration;
            f = Mathf.Clamp01(f);
            float waveF = Mathf.Cos(f * Mathf.PI / 2);

            transform.localPosition = Vector3.Lerp(startPosition, endPosition, f);
            transform.localScale = Vector3.Lerp(Vector3.zero, startScale, waveF);

            yield return null;
        }

        Destroy(gameObject);
    }


    public void Leave(float duration)
    {
        //Debug.Log("plane is leaving " + name);
        StartCoroutine(LeaveCoroutine(duration));
    }

    private IEnumerator LeaveCoroutine(float duration)
    {
        transform.localRotation = Quaternion.Euler(0, 0, 180);

        float f = 0;
        while (f < 1)
        {
            f += Time.deltaTime / duration;
            f = Mathf.Clamp01(f);

            transform.localPosition = (Vector3.left * f) * arriveDistance;

            yield return null;
        }

        Destroy(gameObject);
    }


    public void Wait(float duration)
    {
        StartCoroutine(WaitCoroutine(duration));
    }

    // Fly in a little circle
    private IEnumerator WaitCoroutine(float duration)
    {
        Quaternion initialRotation = transform.localRotation;
        Vector3 initialPosition = transform.localPosition;
        Vector3 circleCenter = initialPosition + initialRotation * Vector3.up * waitCircleRadius;

        float f = 0;
        while (f < 1)
        {
            f += Time.deltaTime / duration;
            f = Mathf.Clamp01(f);

            transform.localRotation = initialRotation * Quaternion.Euler(0, 0, f*360);
            transform.localPosition = circleCenter + initialRotation * Quaternion.Euler(0, 0, f * 360) * Vector3.down * waitCircleRadius;

            yield return null;
        }

        transform.localRotation = initialRotation;
        transform.localPosition = initialPosition;
    }
}
