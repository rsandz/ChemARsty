using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class atomFusion : MonoBehaviour
{
    public int bondCapacity;
    public int bonds;

    // Start is called before the first frame update
    void Start()
    {
        SphereCollider sphereCol = gameObject.GetComponent<SphereCollider>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<atomFusion>() && bonds < bondCapacity)
        {
            print("hello");
        }
    }
}
