using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;


public class FollowerPool : MonoBehaviour
{
    public float spawnDistanceMax = 8f;
    public float spawnDistanceMin = 4f;
    public float spawnIntervalMax = 10f;
    public float spawnIntervalMin = 6f;
    public int numAvailableFollowers = 0;
    private List<GameObject> followers = new List<GameObject>();
    public GameObject player;
    private Coroutine spawnInterval;
    // Start is called before the first frame update
    void Start()
    {
        foreach ( Transform child in transform ) {
            followers.Add(child.gameObject);
        }
        spawnInterval = StartCoroutine(SpawnInterval());
    }

    // Update is called once per frame
    void Update()
    {
        numAvailableFollowers = DialogueLua.GetVariable("NumAvailableFollowers").AsInt;
    }

    public void IncrementAvailableFollowers(int followNum) {
        if(numAvailableFollowers + followNum < followers.Count && numAvailableFollowers + followNum > 0) {
            numAvailableFollowers += followNum;
        }
    }

    private void SpawnFollower(int index) {
        Random.seed = System.DateTime.Now.Millisecond;

        GameObject follower = followers[index];

        Vector3 newPos = player.transform.position - player.transform.forward * Random.Range(spawnDistanceMin, spawnDistanceMax);
        newPos.x += Random.Range(-15f, 15f);

        follower.transform.position = newPos;
        Vector3 lookDir = player.transform.position - follower.transform.position;
        follower.transform.rotation = Quaternion.LookRotation(lookDir);

    }

    IEnumerator SpawnInterval() {
        while(true) {
            yield return new WaitForSeconds(Random.Range(spawnIntervalMin, spawnIntervalMax));
            Debug.Log("SPAWNING BEHIND!");
            for(int i = 0; i < numAvailableFollowers; i++) {
                yield return new WaitForSeconds(0.11f);
                SpawnFollower(i);
            }
        }
    }


}
