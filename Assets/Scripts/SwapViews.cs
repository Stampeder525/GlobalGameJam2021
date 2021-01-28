using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ECM.Examples;

public class SwapViews : MonoBehaviour
{

    private CustomCharacterController thirdPersonController;
    private GameObject firstPersonController;
    public int firstPersonState;
    // Start is called before the first frame update
    void Start()
    {
        thirdPersonController = gameObject.GetComponent<CustomCharacterController>();
        firstPersonController = transform.Find("FirstPersonController").gameObject;
        firstPersonState = 0;
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
                gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                thirdPersonController.enabled = true;
                firstPersonState = 0;
                break;
            }
            case 1: {
                thirdPersonController.enabled = false;
                gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
                firstPersonController.transform.position = gameObject.transform.position;
                firstPersonController.transform.rotation = gameObject.transform.rotation;
                firstPersonController.SetActive(true);
                firstPersonState = 1;
                break;
            }
            default: {
                firstPersonController.SetActive(false);
                firstPersonController.transform.position = gameObject.transform.position;
                firstPersonController.transform.rotation = gameObject.transform.rotation;
                thirdPersonController.enabled = true;
                firstPersonState = 1;
                break;
            }
        }
    }
}
