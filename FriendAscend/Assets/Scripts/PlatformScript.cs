using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformScript : MonoBehaviour
{
    public bool isFirstPlatform;
    public GameObject platform;
    public int platformNo;
    int offset = 10;
    // Start is called before the first frame update
    void Start()
    {
        if (platformNo == 10)
            return;
        platformNo = GameObject.FindGameObjectsWithTag("FriendAscendPlatform").Length;
        GameObject nextPlatform = Instantiate(platform);
        nextPlatform.transform.position = gameObject.transform.position + gameObject.transform.localScale / 2 + new Vector3((Random.value-0.5f)*offset,0.5f, (Random.value - 0.5f)*offset);
        nextPlatform.transform.parent = gameObject.transform.parent;
        nextPlatform.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
