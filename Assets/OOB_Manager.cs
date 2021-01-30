﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OOB_Manager : MonoBehaviour
{
    //Instance
    public static OOB_Manager instance;

    private List<OOB_Object> oobObjsList;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        //Get all objects in list
        oobObjsList = new List<OOB_Object>();
    }

    public void AddOOBObject(OOB_Object oobObject)
    {
        oobObjsList.Add(oobObject);
    }

    public void ToggleOOBObjects(bool toggle)
    {
        if (oobObjsList == null)
            return;

        for(int i = 0; i < oobObjsList.Count; i++)
        {
            OOB_Object oobObject = oobObjsList[i];

            oobObject.ToggleObjectShown(toggle);
        }
    }
}
