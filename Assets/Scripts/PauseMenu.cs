using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void QuitGame() {
        #if (UNITY_WEBGL)
            Application.OpenURL("about:blank");
        #else
            Application.Quit();
        #endif
    }

    public void ContinueGame() {
        gameObject.SetActive(false);
    }
}
