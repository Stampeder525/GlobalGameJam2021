using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;


public class RevealEnding : MonoBehaviour
{
    // Start is called before the first frame update
    public bool show = true;
    private int neighborsComplete;

    public GameObject target = null;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        neighborsComplete = DialogueLua.GetVariable("NeighborsComplete").AsInt;
        if(neighborsComplete >= 5) {
            if(target == null){
                gameObject.SetActive(show);
            }
            else {
                target.SetActive(show);
            }
        } 
    }
}
