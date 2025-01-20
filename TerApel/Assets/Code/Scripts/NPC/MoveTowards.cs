using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowards : MonoBehaviour
{
    public GameObject NPC;
    public GameObject Spline;
    public float speed;
    private Animator animator;
    public Animator guardAnimator;
    public GameObject Player;
    private bool isWalking = false; // Tracks if the NPC is currently walking

    void Update()
    {
        NPC.transform.position = Vector3.MoveTowards(NPC.transform.position, Spline.transform.position, speed);
        NPC.transform.rotation = Spline.transform.rotation;

        if (Vector3.Distance(transform.position, Player.transform.position) < 5f)
        {
            if (!isWalking) // Only trigger walk animation if not already walking
            {
                guardAnimator.SetBool("IsWalking", true);
                isWalking = true;
            }
            Spline.SetActive(true);
        }

        else
        {
            if (isWalking) // Only trigger idle animation if walking
            {
                guardAnimator.SetBool("IsWalking", false);
                isWalking = false;
            }
            Spline.SetActive(false);
        }
    }
}
