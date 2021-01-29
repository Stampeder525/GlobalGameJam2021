using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerLoop : MonoBehaviour
{
    private GameObject rowPool;
    public bool loopForward = true;
    // Start is called before the first frame update
    void Start()
    {
        rowPool = transform.root.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        if((loopForward && other.gameObject.GetComponent<Rigidbody>().velocity.z < 0) ||
            (!loopForward && other.gameObject.GetComponent<Rigidbody>().velocity.z > 0)) {
            rowPool.GetComponent<LoopStreets>().Loop(loopForward);
        }
    }
}
