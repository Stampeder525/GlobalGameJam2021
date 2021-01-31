using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ESpritePress : MonoBehaviour
{

    public Sprite[] sprites;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SwapSprites());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SwapSprites() {
        while(true){
            gameObject.GetComponent<Image>().sprite = sprites[0];
            yield return new WaitForSeconds(0.5f);
            gameObject.GetComponent<Image>().sprite = sprites[1];
            yield return new WaitForSeconds(0.5f);
        }
    }
}
