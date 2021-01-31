using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;

public class Pinata : MonoBehaviour
{
    public GameObject viscera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other) {
        Debug.Log(other.gameObject.tag);
        if(other.gameObject.tag == "Item") {
            Debug.Log("Pinata broken!");
            DialogueLua.SetVariable("PinataBroken", true);
            viscera.SetActive(true);
            gameObject.SetActive(false);
        }

    }
}
