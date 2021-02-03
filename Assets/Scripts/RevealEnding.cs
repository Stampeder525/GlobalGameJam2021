using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;


public class RevealEnding : MonoBehaviour
{
    // Start is called before the first frame update
    public bool show = true;
    private int neighborsComplete;

    public List<GameObject> targets = new List<GameObject>();
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        neighborsComplete = DialogueLua.GetVariable("NeighborsComplete").AsInt;
        if(neighborsComplete >= 5) {
            if(targets.Count == 0){
                gameObject.SetActive(show);
            }
            else {
                for(int i = 0; i < targets.Count; i++) {
                    if(targets[i] != null) {
                        targets[i].SetActive(show);
                    }
                }
            }
        } 
    }
}
