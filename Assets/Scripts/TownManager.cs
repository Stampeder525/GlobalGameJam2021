using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TownManager : MonoBehaviour
{
    public int puzzleHomeIndex = 0;

    public GameObject defaultLawnObj;

    public GameObject clueGiverLawn1;
    public GameObject clueGiverLawn2;
    public GameObject clueGiverLawn3;
    public GameObject clueGiverLawn4;
    public GameObject clueGiverLawn5;

    private GameObject[] leftLawnTransformList;
    private GameObject[] rightLawnTransformList;

    private void Start()
    {
        //Populate town transform list
        leftLawnTransformList = GameObject.FindGameObjectsWithTag("LeftLawnTransform");
        rightLawnTransformList = GameObject.FindGameObjectsWithTag("RightLawnTransform");
        SpawnDefaultHomes();
        SpawnSpecialLawns();
    }

    private void SpawnDefaultHomes()
    {
        if (defaultLawnObj == null)
            return;

        for(int i = 0; i < leftLawnTransformList.Length; i++)
        {
            Transform lawnTransform = leftLawnTransformList[i].transform;
            Instantiate(defaultLawnObj, lawnTransform);
        }

        for (int i = 0; i < rightLawnTransformList.Length; i++)
        {
            Transform lawnTransform = rightLawnTransformList[i].transform;
            Instantiate(defaultLawnObj, lawnTransform);
        }
    }

    //Hard coded script
    private void SpawnSpecialLawns()
    {
        //Clue 1
        Transform clueLawnTransform1 = rightLawnTransformList[11].transform;
        Destroy(clueLawnTransform1.GetChild(0).gameObject);
        if(clueGiverLawn1 != null)
            Instantiate(clueGiverLawn1, clueLawnTransform1);

        //Clue 2
        Transform clueLawnTransform2 = rightLawnTransformList[9].transform;
        Destroy(clueLawnTransform2.GetChild(0).gameObject);
        if (clueGiverLawn2 != null)
            Instantiate(clueGiverLawn2, clueLawnTransform2);

        //Clue 2
        Transform clueLawnTransform5 = leftLawnTransformList[8].transform;
        Destroy(clueLawnTransform5.GetChild(0).gameObject);
        if (clueGiverLawn5 != null)
            Instantiate(clueGiverLawn5, clueLawnTransform5);
    }
}
