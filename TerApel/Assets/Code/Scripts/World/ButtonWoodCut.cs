using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonWoodCut : MonoBehaviour
{
    private PlankArea plankArea;

    // Start is called before the first frame update
    void Start()
    {
        plankArea = FindObjectOfType<PlankArea>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && plankArea != null)
        {
            plankArea.CutWood();
        }
    }
}
