using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformScript : MonoBehaviour
{
    public bool isFirstPlatform;
    public GameObject platform;
    public GameObject miniPlatform;
    public int platformNo;
    int horizontalOffset = 7;
    int verticalOffset = 4;
    public static int maxNumPlatforms = 10;
    // Start is called before the first frame update
    void Start()
    {
        if (platformNo == maxNumPlatforms)
            return;
        platformNo = GameObject.FindGameObjectsWithTag("FriendAscendPlatform").Length;
        GameObject nextPlatform = Instantiate(platform);

        nextPlatform.transform.position = gameObject.transform.position + gameObject.transform.localScale / 2
            + new Vector3((Random.value-0.3f)*horizontalOffset,(Random.value-0.5f)*verticalOffset, (Random.value - 0.3f)*horizontalOffset);

        if(nextPlatform.transform.position[1]-transform.position[1]>3)
        {
            GameObject plat = Instantiate(miniPlatform);
            plat.transform.position = nextPlatform.transform.position - nextPlatform.transform.localScale / 2
                + Vector3.up * nextPlatform.transform.localScale.y * 2/3.0f + new Vector3((Random.value - 0.7f) * horizontalOffset/2.0f, (Random.value - 1f) * verticalOffset/4.0f, (Random.value - 0.7f) * horizontalOffset/2.0f);

            plat.transform.parent = gameObject.transform.parent;
        }

        nextPlatform.transform.parent = gameObject.transform.parent;
        nextPlatform.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
