using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TownManager : MonoBehaviour
{
    public int puzzleHomeIndex = 0;

    public List<GameObject> defaultLawnObjs;

    public GameObject clueGiverLawn1;
    public GameObject clueGiverLawn2;
    public GameObject clueGiverLawn3;
    public GameObject clueGiverLawn4;
    public GameObject clueGiverLawn5;

    public GameObject endingLawn;

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
        if (defaultLawnObjs.Count == 0)
            return;

        for(int i = 0; i < leftLawnTransformList.Length; i++)
        {
            Transform lawnTransform = leftLawnTransformList[i].transform;
            Instantiate(defaultLawnObjs[Random.Range(0, defaultLawnObjs.Count)], lawnTransform);
        }

        for (int i = 0; i < rightLawnTransformList.Length; i++)
        {
            Transform lawnTransform = rightLawnTransformList[i].transform;
            Instantiate(defaultLawnObjs[Random.Range(0, defaultLawnObjs.Count)], lawnTransform);
        }
    }

    //Hard coded script
    private void SpawnSpecialLawns()
    {
        //Clue 1
        Transform clueLawnTransform1 = rightLawnTransformList[2].transform;
        Destroy(clueLawnTransform1.GetChild(0).gameObject);
        if(clueGiverLawn1 != null)
            Instantiate(clueGiverLawn1, clueLawnTransform1);

        //Clue 2
        Transform clueLawnTransform2 = rightLawnTransformList[18].transform;
        Destroy(clueLawnTransform2.GetChild(0).gameObject);
        if (clueGiverLawn2 != null)
            Instantiate(clueGiverLawn2, clueLawnTransform2);

        //Clue 3
        Transform clueLawnTransform3 = leftLawnTransformList[8].transform;
        Destroy(clueLawnTransform3.GetChild(0).gameObject);
        if (clueGiverLawn3 != null)
            Instantiate(clueGiverLawn3, clueLawnTransform3);

        //Clue 4
        Transform clueLawnTransform4 = leftLawnTransformList[6].transform;
        Destroy(clueLawnTransform4.GetChild(0).gameObject);
        if (clueGiverLawn4 != null)
            Instantiate(clueGiverLawn4, clueLawnTransform4);

        //Clue 5
        Transform clueLawnTransform5 = rightLawnTransformList[13].transform;
        Destroy(clueLawnTransform5.GetChild(0).gameObject);
        if (clueGiverLawn5 != null)
            Instantiate(clueGiverLawn5, clueLawnTransform5);

        //Clue 2
        Transform endingLawnTransform = leftLawnTransformList[1].transform;
        Destroy(endingLawnTransform.GetChild(0).gameObject);
        if (endingLawnTransform != null)
            Instantiate(endingLawn, endingLawnTransform);
    }
}
