using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ECM.Examples;

public class SwapViews : MonoBehaviour
{
    public int firstPersonState;

    private GameObject firstPersonController;
    private ECM.Components.MouseLook mouseLook;
    private CustomCharacterController thirdPersonController;

    // Start is called before the first frame update
    void Start()
    {
        thirdPersonController = gameObject.GetComponent<CustomCharacterController>();
        firstPersonController = transform.Find("FirstPersonController").gameObject;
        SwapView(firstPersonState);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("space")) {
            SwapView();
        }
    }

    public void SwapView(int view=-1) {
        if(view == -1) {
            view = (firstPersonState == 1) ? 0 : 1;
        }
        Debug.Log("VIEW:" + view);
        switch(view) {
            case 0: {
                firstPersonController.SetActive(false);
                firstPersonController.transform.position = gameObject.transform.position;
                firstPersonController.transform.rotation = gameObject.transform.rotation;
                gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
                thirdPersonController.enabled = true;
                firstPersonState = 0;
                RenderSettings.fogDensity = 0.03f;
                break;
            }
            case 1: {
                thirdPersonController.enabled = false;
                gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                firstPersonController.SetActive(true);
                firstPersonState = 1;
                RenderSettings.fogDensity = 0.05f;
                break;
            }
            default: {
                firstPersonController.SetActive(false);
                firstPersonController.transform.position = gameObject.transform.position;
                firstPersonController.transform.rotation = gameObject.transform.rotation;
                thirdPersonController.enabled = true;
                firstPersonState = 1;
                RenderSettings.fogDensity = 0.03f;
                break;
            }
        }
    }
}
