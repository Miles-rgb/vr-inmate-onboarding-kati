using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoPointTrigger1 : MonoBehaviour
{
    public GameObject Spline;
    public GameObject InfoP1;
    public Animator guardAnimator;
    public GameObject Player;

    private void OnTriggerExit (Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            InfoP1.SetActive(false);
        }
    }

   
}
