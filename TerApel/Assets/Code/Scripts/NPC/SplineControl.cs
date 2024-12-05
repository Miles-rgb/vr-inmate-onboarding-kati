using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Splines;

public class SplineControl : MonoBehaviour
{
    public GameObject Spline1;
    public GameObject Spline2;
    public GameObject Sphere;

    public static void HandleTrigger(GameObject triggeredObject)
    {
        Debug.Log("triggered tag Player");
        SecondTrigger();
    }

    public void SecondTrigger()
    {
        Sphere.GetComponent<SplineAnimate>() = false;
    }
}
