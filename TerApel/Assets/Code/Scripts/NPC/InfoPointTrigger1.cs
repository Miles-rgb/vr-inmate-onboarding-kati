using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoPointTrigger1 : MonoBehaviour
{
    public GameObject Spline;
    public GameObject InfoP1;
    public Animator guardAnimator;

    private void OnTriggerEnter(Collider other)
    {
        // Check if the colliding object has a specific tag or component
        if (other.gameObject.CompareTag("Player"))
        {
            Spline.SetActive(true);
            guardAnimator.SetTrigger("Walk");
        }
    }

    private void OnTriggerExit (Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            InfoP1.SetActive(false);
        }
    }
}
