using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
// © 2017 TheFlyingKeyboard and released under MIT License
// theflyingkeyboard.net
//Shows string and then hides it with time step
public class FlashingText : MonoBehaviour
{
    private Text text;
    private bool delay = true;
    public float flashSpeed = 4f;
    private void Start()
    {
        text = GetComponent<Text>();
        StartCoroutine(StartDelay());
    }
    private void FixedUpdate()
    {
        if (!delay)
        {
            text.color = new Color(text.color.r, text.color.g, text.color.b, Mathf.Sin(Time.time * flashSpeed));
        }
    }

    IEnumerator StartDelay()
    {
        yield return new WaitForSeconds(0.5f);
        delay = false;
    }
}
