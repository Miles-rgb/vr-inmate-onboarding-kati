using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoPointTrigger3 : MonoBehaviour
{
    public GameObject Spline;
    public GameObject InfoP3;
    public Animator guardAnimator;

    private void OnTriggerStay(Collider other)
    {
        // Check if the colliding object has a specific tag or component
        if (other.gameObject.CompareTag("Player"))
        {
            Spline.SetActive(true);
            guardAnimator.SetTrigger("Walk");
        }

        else guardAnimator.SetTrigger("Stop");

        if (other.gameObject.CompareTag("NPC"))
        {
            Spline.SetActive(false);
            guardAnimator.SetTrigger("Stop");
        }
    }
}
