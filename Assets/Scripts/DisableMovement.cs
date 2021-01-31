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
        player.GetComponent<Rigidbody>().velocity = Vector3.zero;
        player.GetComponent<SwapViews>().enabled = false;
        player.GetComponent<ProximitySelector>().enabled = false;

        if(player.GetComponent<ItemHolder>() != null)
        {
            player.GetComponent<ItemHolder>().DropItem();
            player.GetComponent<ItemHolder>().enabled = false;
        }

        player.GetComponent<Rigidbody>().velocity = Vector3.zero;
    }

    public void StartMovement() {
        player.GetComponent<CustomCharacterController>().enabled = true;
        player.GetComponent<SwapViews>().enabled = true;
        player.GetComponent<ProximitySelector>().enabled = true;

        if (player.GetComponent<ItemHolder>() != null)
            player.GetComponent<ItemHolder>().enabled = true;
    }
}
