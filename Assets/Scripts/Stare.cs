using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stare : MonoBehaviour
{
    private Animator anim;
    public Transform target;
    [Range(0.0f, 1.0f)]
    public float stareWeight = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        target = GameObject.Find("Player").transform;
    }

    void OnAnimatorIK(int layerIndex)
    {
        anim.SetLookAtWeight(stareWeight);
        anim.SetLookAtPosition(target.position);
    }
}
