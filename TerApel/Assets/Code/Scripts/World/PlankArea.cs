using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlankArea : MonoBehaviour
{
    private GameObject plank;
    [SerializeField] private GameObject halfPlank;
    private bool plankThere;
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
        plankThere = true;
        Debug.Log("plank is: " + plankThere);
        return plank;
        
    }

    public void CutWood()
    {
        if (CountPlank())
        {
            Vector3 plankTransform = new Vector3(plank.transform.position.x, plank.transform.position.y, plank.transform.position.z);
            Destroy(plank);
            plankThere = false;
            Instantiate(halfPlank, new Vector3(plankTransform.x, plankTransform.y, plankTransform.z), plank.transform.rotation);
            Instantiate(halfPlank, new Vector3(plankTransform.x, plankTransform.y, plankTransform.z - 0.5f), plank.transform.rotation);
        }
        
    }

}
