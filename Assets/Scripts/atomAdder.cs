using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class atomAdder : MonoBehaviour
{
    public static GameObject[] selectedObjects;
    public List<GameObject> existingAtoms;
    public GameObject[] atomTypes;
    public GameObject imageTarget;

    public void addCarbon()
    {
        GameObject spawned = Instantiate(atomTypes[0]);
        spawned.transform.SetParent(imageTarget.transform);
        existingAtoms.Add(spawned);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
