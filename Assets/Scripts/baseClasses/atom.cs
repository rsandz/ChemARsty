using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class atom : MonoBehaviour
{
    // Prefabs
    public GameObject bondPrefab;
    public GameObject hydrogenPrefab;
    public GameObject carbonPrefab;

    public int numBonds;
    public Vector3 startBondVec;  // Must be unit vector
    public List<GameObject> childBonds;
    public List<GameObject> childAtoms;
    public bool isOriginal;
    public int id;


    void Start()
    {
        // Init
        childBonds = new List<GameObject>(numBonds);
        childAtoms = new List<GameObject>(numBonds);
        startBondVec.Normalize();

        if (isOriginal) // First Carbon
        {
            instantiateAllHydrogens();
        }
    }

    /**
     * Gets possible areas to place bonds at
     */
    public List<Vector3> getBondVecs()
    {
        List<Vector3> bondAreas = new List<Vector3>();
        if (isOriginal) bondAreas.Add(Vector3.Normalize(startBondVec)); // Add starting bond loc if original.
        Quaternion rotationFix = Quaternion.Euler(90, 0, 0);
        Debug.Log("Curr Rot: " + transform.parent.transform.parent.transofrm.eulerAngles);
        Debug.Log("Curr Rot: " + transform.eulerAngles;
        switch (numBonds)
        {
            case 2:
                bondAreas.Add(rotationFix * Vector3.Normalize(-1 * startBondVec));
                break;

            case 3:
                bondAreas.Add(rotationFix * Vector3.Normalize(Quaternion.Euler(0, 120, 0) * startBondVec));
                bondAreas.Add(rotationFix * Vector3.Normalize(Quaternion.Euler(0, -120, 0) * startBondVec));
                break;

            case 4:
                bondAreas.Add(rotationFix * Vector3.Normalize(Quaternion.Euler(0, 90, 0) * startBondVec));
                bondAreas.Add(rotationFix * Vector3.Normalize(Quaternion.Euler(0, 180, 0) * startBondVec));
                bondAreas.Add(rotationFix * Vector3.Normalize(Quaternion.Euler(0, 270, 0) * startBondVec));
                break;

            default:
                break;
        }

        return bondAreas;
    }

    public List<Vector3> getChildLocs()
    {
        List<Vector3> childLoc = new List<Vector3>();
        List<Vector3> bondVec = getBondVecs();

        // Distance Calculation
        float bondHalfLength = bondPrefab.transform.lossyScale.y;
        float distance = (bondHalfLength * 2) + transform.lossyScale.x / 2;
        
        int numChildLoc = isOriginal ? numBonds : numBonds - 1;

        for (int i = 0; i < numChildLoc; i++)
        {
            childLoc.Insert(i, (bondVec[i] * distance) + transform.position);
            Debug.Log("Location: " + ((bondVec[i] * distance) + transform.position) + ". Vec: " + bondVec[i]);
        }

        return childLoc;
    }

    public void convertToCarbon()
    {
        Transform parentTransform = transform.parent.transform;
        GameObject newCarbon = Instantiate(carbonPrefab, transform.position, 
                                           transform.localRotation, parentTransform);
        
        Debug.Log(startBondVec);
        newCarbon.GetComponent<atom>().startBondVec = -1 * Vector3.Normalize(startBondVec);
        newCarbon.GetComponent<atom>().instantiateAllHydrogens();
    }

    public void convertToHydrogen()
    {

    }

    public void instantiateHydrogen(int locIndex)
    {
        List<Vector3> childLoc = getChildLocs();
        // Get Parent Atom
        Transform parentTransform = transform.parent.transform;

        childAtoms.Insert(locIndex,
            Instantiate(hydrogenPrefab, childLoc[locIndex], transform.localRotation, parentTransform));
        
        atom childAtom = childAtoms[locIndex].GetComponent<atom>();
        childAtom.startBondVec = getBondVecs()[locIndex];
    }

    public void instantiateAllHydrogens()
    {
        int numHydrogens = isOriginal ? numBonds : numBonds - 1;
        for (int i = 0; i < numHydrogens; i++)
        {
            instantiateBond(i);
            instantiateHydrogen(i);
        }
    }

    /**
     * Creates a bond at bondLoc[i]
     */
    public void instantiateBond(int bondIndex)
    {
        Transform parentTransform = transform.parent.transform;
        float radius = transform.lossyScale.y / 2;
        float halfLengthBond = bondPrefab.transform.lossyScale.y;
        Vector3 bondVec = Vector3.Normalize(getBondVecs()[bondIndex]);

        Vector3 bondPos = transform.position + bondVec * (radius + halfLengthBond);

        Quaternion rot = Quaternion.LookRotation(Vector3.up, bondVec);  // Flipping seems to work

        childBonds.Insert(
            bondIndex,
            Instantiate(bondPrefab, bondPos, rot, parentTransform)
            );
        
    }
}
