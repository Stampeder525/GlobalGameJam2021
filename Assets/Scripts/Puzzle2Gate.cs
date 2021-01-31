using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;


public class Puzzle2Gate : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bool firstPersonMode = DialogueLua.GetVariable("PlayerOutOfBody").AsBool;
        if(firstPersonMode) {
            gameObject.GetComponent<BoxCollider>().enabled = false;
        }
        else {
            gameObject.GetComponent<BoxCollider>().enabled = true;
        }
    }
}
