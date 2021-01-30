﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OOB_Object : MonoBehaviour
{
    private Animator anim;

    protected virtual void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void ToggleObjectShown(bool toggle)
    {
        gameObject.SetActive(toggle);
        if (anim != null)
        {
            anim.SetBool("Show", toggle);
        }
    }
}
