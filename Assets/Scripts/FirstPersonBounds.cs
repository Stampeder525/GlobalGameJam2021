using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonBounds : MonoBehaviour
{
    public GameObject player;
    public GameObject firstPersonPlayer;
    public float radius = 15f;
    private Renderer rend;
    // Start is called before the first frame update
    void Start()
    {
        rend = gameObject.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.transform.position.x + radius, player.transform.position.y - 2f, player.transform.position.z);
        rend.material.SetVector("_PlayerPos", firstPersonPlayer.transform.position);
    }
}
