using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEndingCrowd : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject neighborWall;
    public int maxRepeats = 4;

    public float moveDistance = 4f;
    private int repeats;
    void Start()
    {
        repeats = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Player" && repeats < maxRepeats) {
            if(repeats == 0) {
                neighborWall.SetActive(true);
            }
            Vector3 newTriggerPos = transform.position;
            newTriggerPos.x -= moveDistance;
            transform.position = newTriggerPos;

            if(repeats > 0) {
                Vector3 newNeighborWallPos = neighborWall.transform.position;
                newNeighborWallPos.x -= moveDistance;
                neighborWall.transform.position = newNeighborWallPos;
            }
            repeats++;

        }
    }
}
