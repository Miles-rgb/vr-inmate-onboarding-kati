using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoPointTrigger3 : MonoBehaviour
{
    public GameObject Spline;
    public GameObject InfoP3;

    private void OnTriggerStay(Collider other)
    {
        // Check if the colliding object has a specific tag or component
        if (other.gameObject.CompareTag("Player"))
        {
            Spline.SetActive(true);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("NPC"))
        {
            Spline.SetActive(false);
        }        
    }

    private void OnTriggerExit (Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            InfoP3.SetActive(false);
        }
    }
}
