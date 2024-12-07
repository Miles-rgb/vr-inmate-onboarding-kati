using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoPointTrigger : MonoBehaviour
{
    public GameObject SplineG1;

    private void OnTriggerStay(Collider other)
    {
        // Check if the colliding object has a specific tag or component
        if (other.gameObject.CompareTag("Player"))
        {
            SplineG1.SetActive(false);
        }
    }
}
