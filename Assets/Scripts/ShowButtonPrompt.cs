using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ShowButtonPrompt : MonoBehaviour
{

    public GameObject ePrompt;
    public GameObject spacePrompt;

    public bool isEPrompt = true;
    // Start is called before the first frame update
    void Start()
    {
        ePrompt = GameObject.FindGameObjectWithTag("EPrompt");
        Debug.Log(ePrompt);
        spacePrompt = GameObject.FindGameObjectWithTag("SpacePrompt");
        
        SetPromptInactive();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Player") {
            SetPromptActive();
        }
    }

    private void OnTriggerExit(Collider other) {
        if(other.gameObject.tag == "Player") {
            SetPromptInactive();
        }
    }

    public void SetPromptActive() {
        Debug.Log("SETTING ACTIVE");
        if(isEPrompt) {
            ePrompt.GetComponent<Image>().enabled = true;
            ePrompt.transform.GetChild(0).gameObject.SetActive(true);
        } else {
            spacePrompt.GetComponent<Image>().enabled = true;
            spacePrompt.transform.GetChild(0).gameObject.SetActive(true);
        }
    }

    public void SetPromptInactive() {
        Debug.Log("SETTING INACTIVE");
        if(isEPrompt) {
            ePrompt.GetComponent<Image>().enabled = false;
            ePrompt.transform.GetChild(0).gameObject.SetActive(false);
        } else {
            spacePrompt.GetComponent<Image>().enabled = false;
            spacePrompt.transform.GetChild(0).gameObject.SetActive(false);
        }
    }

    
}
