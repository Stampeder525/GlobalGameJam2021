using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ECM.Examples;

public class DisableMovement : MonoBehaviour
{
    public void StopMovement() {
        gameObject.GetComponent<CustomCharacterController>().enabled = false;
        gameObject.GetComponent<SwapViews>().enabled = false;
    }

    public void StartMovement() {
        gameObject.GetComponent<CustomCharacterController>().enabled = true;
        gameObject.GetComponent<SwapViews>().enabled = true;
    }
}
