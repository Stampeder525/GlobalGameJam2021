using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopStreets : MonoBehaviour
{
    public List<GameObject> rows;
    private List<GameObject> loopTriggers = new List<GameObject>();
    // private GameObject forwardTrigger;
    // private GameObject backwardTrigger;
    // Start is called before the first frame update
    void Start()
    {
        loopTriggers.Add(transform.Find("Street Forward Trigger").gameObject);
        loopTriggers.Add(transform.Find("Street Backward Trigger").gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Loop(bool isForward = true) {
        if(isForward) Debug.Log("Looping Forward!");
        else Debug.Log("Looping Backward!");
        int index = isForward ? rows.Count - 1 : 0;
        GameObject row = rows[index];
        rows.Remove(row);
        Vector3 rowPos = row.transform.position;
        float newZ = isForward ? Mathf.Round(rowPos.z - 360f) : Mathf.Round(rowPos.z + 360f);
        Vector3 newPos = new Vector3(Mathf.Round(rowPos.x), 0, newZ);
        row.transform.position = newPos;
        if(isForward) {
            rows.Insert(0, row);
        } else {
            rows.Add(row);
        }
        // rows.Insert((isForward ? 0 : rows.Count - 1), row);
        RelocateTriggers(isForward);
    }

    private void RelocateTriggers(bool isForward = true) {

        for(int i = 0; i < loopTriggers.Count; i++) {
            loopTriggers[i].GetComponent<Collider>().enabled = false;
            float newZ = isForward ? Mathf.Round(loopTriggers[i].transform.position.z - 120f) : Mathf.Round(loopTriggers[i].transform.position.z + 120f);
            Vector3 newPos = new Vector3(Mathf.Round(loopTriggers[i].transform.position.x), 0, newZ);
            loopTriggers[i].transform.position = newPos;
            trigger.GetComponent<Collider>().enabled = true;
            StartCoroutine(ReenableTrigger(loopTriggers[i]));
        }
        
    }

    // IEnumerator ReenableTrigger(GameObject trigger) {
    //     yield return new WaitForSeconds(5f);

    // }
}
