using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rayCastSelector : MonoBehaviour
{
    public Camera cam;
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log("rayfire");
            RaycastHit rayhit;
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            bool hit = Physics.Raycast(ray, out rayhit, 1000);
            if (hit)
            {
                Debug.Log("hit");
                GameObject target = rayhit.collider.gameObject;
                target.gameObject.SendMessage("convertToCarbon");
            }
            else
            {
                Debug.Log("miss");
            }
        }
    }
}
