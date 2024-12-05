using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowards : MonoBehaviour
{
    public GameObject Sphere;
    public GameObject Cube;
    public GameObject Cube2;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Sphere.transform.position = Vector3.MoveTowards(Sphere.transform.position, Cube.transform.position, speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Waypoint")
        {
            //Destroy(Cube);
            Destroy (Cube.gameObject.GetComponent<Collider>());
            Sphere.transform.position = Vector3.MoveTowards(Sphere.transform.position, Cube2.transform.position, speed);
            Debug.Log("works");
        }
    }
}
