using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomNPCSpawn : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Random.seed = System.DateTime.Now.Millisecond;
        bool spawn = (Random.value > 0.6f);
        if(spawn) {
            GameObject child0 = transform.GetChild(0).gameObject;
            GameObject child1 = transform.GetChild(1).gameObject;
            child0.SetActive(false);
            child1.SetActive(false);
        }
        else {
            bool model = (Random.value > 0.5f);
            if(model){
                transform.GetChild(0).gameObject.SetActive(false);
            } else {
                transform.GetChild(1).gameObject.SetActive(false);
            }
            //choose model
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
