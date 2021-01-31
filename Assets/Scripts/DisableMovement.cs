using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ECM.Examples;
using PixelCrushers.DialogueSystem;


public class DisableMovement : MonoBehaviour
{
    private GameObject player;

    void Start() {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void StopMovement() {
        player.GetComponent<CustomCharacterController>().enabled = false;
        player.GetComponent<SwapViews>().enabled = false;
        player.GetComponent<ProximitySelector>().enabled = false;
    }

    public void StartMovement() {
        player.GetComponent<CustomCharacterController>().enabled = true;
        player.GetComponent<SwapViews>().enabled = true;
        player.GetComponent<ProximitySelector>().enabled = true;
    }
}
