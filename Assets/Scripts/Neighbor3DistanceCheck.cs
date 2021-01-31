using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;

public class Neighbor3DistanceCheck : MonoBehaviour
{

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Player") {
            DialogueLua.SetVariable("Neighbor3CloseBy", true);
            Debug.Log("CLOSE BY: " + DialogueLua.GetVariable("Neighbor3CloseBy").AsBool);
            Debug.Log("NEIGHBOR2: " + DialogueLua.GetVariable("Neighbor2Complete").AsBool);
            Debug.Log("OOB: " + DialogueLua.GetVariable("PlayerOutOfBody").AsBool);
        }

    }

    private void OnTriggerExit(Collider other) {
        if(other.gameObject.tag == "Player") {
            Debug.Log("Left Zone!");
            DialogueLua.SetVariable("Neighbor3CloseBy", false);
            Debug.Log("CLOSE BY: " + DialogueLua.GetVariable("Neighbor3CloseBy").AsBool);
            Debug.Log("NEIGHBOR2: " + DialogueLua.GetVariable("Neighbor2Complete").AsBool);
            Debug.Log("OOB: " + DialogueLua.GetVariable("PlayerOutOfBody").AsBool);
        }

    }
}
