using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardReaction : MonoBehaviour
{
    public Animator guardAnimator;
    public GameObject CRight;
    public GameObject CLeft;

    private void Update()
    {
        if (Vector3.Distance(transform.position, CRight.transform.position) < 0.2f)
        {
            guardAnimator.SetTrigger("Reaction");
        }

        else if (Vector3.Distance(transform.position, CLeft.transform.position) < 0.2f)
        {
            guardAnimator.SetTrigger("Reaction");
        }

        else guardAnimator.SetTrigger("Idle");
    }
}
