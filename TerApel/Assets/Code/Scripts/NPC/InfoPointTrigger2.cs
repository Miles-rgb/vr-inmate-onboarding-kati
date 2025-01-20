using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoPointTrigger2 : MonoBehaviour
{
    public GameObject Spline;
    public GameObject InfoP2;
    public Animator guardAnimator;
    public GameObject Player;



    private void OnTriggerExit (Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            InfoP2.SetActive(false);
        }

        else Spline.SetActive(false);
    }
}
