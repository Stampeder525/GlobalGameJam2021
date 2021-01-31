using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterGrave : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Player") {
            Debug.Log("ENDING!");
            StartCoroutine(EndGame());
        }
    }

    IEnumerator EndGame() {
        yield return new WaitForSeconds(0.2f);
        Application.Quit();
    }
}
