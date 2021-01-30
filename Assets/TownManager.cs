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

    private void SpawnSpecialLawns()
    {
        Transform lawnTransform = rightLawnTransformList[10].transform;

        //Delete home there
        Destroy(lawnTransform.GetChild(0).gameObject);

        //Add prefab
        if(clueGiverLawn1 != null)
            Instantiate(clueGiverLawn1, lawnTransform);

    }
}
