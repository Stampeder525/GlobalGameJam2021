using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follower : MonoBehaviour
{
    public bool isActive = false;
    private bool disappearing = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.GetComponent<Renderer>().isVisible && !disappearing) {
            StartCoroutine(Disappear());
        }
    }

    private void OnBecameVisible() {
        StartCoroutine(Disappear());
    }

    IEnumerator Disappear() {
        disappearing = true;
        yield return new WaitForSeconds(0.5f);
        isActive = false;
        
        transform.parent.position = transform.root.position;
        disappearing = false;

    }


}
