using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ECM.Examples;

public class SwapViews : MonoBehaviour
{
    public int firstPersonState;

    private GameObject firstPersonController;
    private CustomCharacterController thirdPersonController;
    private IEnumerator fadeFogRoutine;

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
        StopCoroutine(fadeFogRoutine);
        switch(view) {
            case 0:
                ShowThirdPersonView();
                break;
            case 1:
                ShowFirstPersonView();
                break;
            default: 
                ShowThirdPersonView();
            break;
            
        }
    }

    public void ShowThirdPersonView()
    {
        firstPersonController.SetActive(false);
        gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
        firstPersonController.transform.position = gameObject.transform.position;
        firstPersonController.transform.rotation = gameObject.transform.rotation;
        thirdPersonController.enabled = true;
        firstPersonState = 0;
        fadeFogRoutine = FadeFog(0.03f);
        StartCoroutine(fadeFogRoutine);

        //Toggle Out of Body objects
        if (OOB_Manager.instance != null)
            OOB_Manager.instance.ToggleOOBObjects(false);
    }

    public void ShowFirstPersonView()
    {
        thirdPersonController.enabled = false;
        gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        firstPersonController.SetActive(true);
        firstPersonState = 1;
        fadeFogRoutine = FadeFog(0.05f);
        StartCoroutine(fadeFogRoutine);

        //Toggle Out of Body objects
        if (OOB_Manager.instance != null)
            OOB_Manager.instance.ToggleOOBObjects(true);
    }

    IEnumerator FadeFog(float targetDensity)
    {
        while (Mathf.Abs(RenderSettings.fogDensity - targetDensity) > 0.001)
        {
            RenderSettings.fogDensity = Mathf.SmoothStep(RenderSettings.fogDensity, targetDensity, 8f * Time.deltaTime);
            yield return null;
        }
    }
}
