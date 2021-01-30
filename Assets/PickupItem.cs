using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;

public class PickupItem : MonoBehaviour
{
    public string dialogueVariable;

    public void OnPickup()
    {
        DialogueLua.SetVariable(dialogueVariable, true);
    }
}
