using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlankArea : MonoBehaviour
{
    private GameObject plank;
    [SerializeField] private GameObject halfPlank;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Plank"))
        {
            CountPlank();
            plank = other.gameObject;
            Debug.Log("plank detected");
        }
    }

    public bool CountPlank()
    {
        bool plank = true;
        Debug.Log("plank is: " + plank);
        return plank;
        
    }

    public void CutWood()
    {
        if (CountPlank())
        {
            Transform plankTransform = plank.transform;
            Destroy(plank);
            Instantiate(halfPlank, plankTransform.position, plankTransform.rotation);
        }
        
    }

}
