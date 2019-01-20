using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChemicalFormula : MonoBehaviour
{
    Text text;
    public int[] elementCount;

    // Start is called before the first frame update
    void Start()
    {
        text = gameObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        findFormula();
        text.text = "C" + elementCount[0].ToString() + "H" + elementCount[1].ToString();
        
    }

    void findFormula()
    {
        List<GameObject> myExist = GameObject.Find("AtomAdder").GetComponent<atomAdder>().existingAtoms; 
        elementCount[0] = 0;
        elementCount[1] = 0;
        for (var i = 0; i < myExist.Count; i++)
        {
            GameObject atom = myExist[i];
            if (atom.tag == "Carbon")
            {
                elementCount[0]++;
            }
            else
            {
                elementCount[1]++;
            }
        }
    }
}
