using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowards : MonoBehaviour
{
    public GameObject NPC;
    public GameObject SplineG1;
    public GameObject SplineG2;
    public float speed;

    private void OnTriggerEnter(Collider other)
    {
        NPC.transform.position = Vector3.MoveTowards(NPC.transform.position, SplineG1.transform.position, speed);
        NPC.transform.rotation = SplineG1.transform.rotation;
        // Check if the colliding object has a specific tag or component
        if (other.gameObject.CompareTag("Player"))
        {
            SplineG1.SetActive(true);
        }
    }

    private void Spline2Active()
    {
        {
            SplineG2.SetActive(true);
            NPC.transform.position = Vector3.MoveTowards(NPC.transform.position, SplineG2.transform.position, speed);
            NPC.transform.rotation = SplineG2.transform.rotation;
        }
    }
}
