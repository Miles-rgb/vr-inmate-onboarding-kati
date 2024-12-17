using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowards : MonoBehaviour
{
    public GameObject NPC;
    public GameObject Spline;
    public float speed;

    void Update()
    {
        NPC.transform.position = Vector3.MoveTowards(NPC.transform.position, Spline.transform.position, speed);
        NPC.transform.rotation = Spline.transform.rotation;
    }
}
