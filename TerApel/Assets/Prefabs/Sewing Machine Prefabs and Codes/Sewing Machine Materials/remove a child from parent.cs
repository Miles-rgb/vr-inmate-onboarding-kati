using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveParent : MonoBehaviour
{
    void Start()
    {
        // Save the current world position
        Vector3 worldPosition = transform.position;

        // Remove the parent
        transform.SetParent(null);

        // Reapply the world position to keep the object in the same place
        transform.position = worldPosition;
    }
}