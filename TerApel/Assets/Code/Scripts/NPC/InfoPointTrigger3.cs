using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoPointTrigger3 : MonoBehaviour
{
    public GameObject Spline;
    public GameObject InfoP3;
    public Animator guardAnimator;
    public GameObject Player;
   public GameObject arrow;

    private void OnTriggerExit (Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            arrow.SetActive(false);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("NPC"))
        {
            Spline.SetActive(false);
            guardAnimator.SetTrigger("Stop");
        }
    }
}
