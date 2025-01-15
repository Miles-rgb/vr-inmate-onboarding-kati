using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardReaction : MonoBehaviour
{
    public Animator guardAnimator;

    private void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.CompareTag("GameController"))
        {
            guardAnimator.SetTrigger("Reaction");
        }

        else guardAnimator.SetTrigger("Idle");
    }
}
