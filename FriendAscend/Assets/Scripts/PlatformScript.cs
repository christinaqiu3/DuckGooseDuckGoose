using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformScript : MonoBehaviour
{
    public GameObject platform;
    public GameObject miniPlatform;
    public int platformNo;
    int horizontalOffset = 7;
    int verticalOffset = 4;
    public static int maxNumPlatforms = 10;
    public Mesh[] platformMeshes;
    public GameObject lemonade;
    float lemonadeProb = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<MeshFilter>().mesh = platformMeshes[(int)(Random.value*platformMeshes.Length)];

        if (platformNo == maxNumPlatforms)
            return;
        platformNo = GameObject.FindGameObjectsWithTag("FriendAscendPlatform").Length;
        GameObject nextPlatform = Instantiate(platform);

        if (Random.value <= lemonadeProb)
        {
            nextPlatform.transform.position = gameObject.transform.position + gameObject.GetComponent<BoxCollider>().bounds.size / 2;
            GameObject lemonadeStand = Instantiate(lemonade);
            lemonade.transform.position = transform.position + new Vector3(3, 3.5f, -3);
            lemonade.transform.rotation = Quaternion.Euler(0, 270, 0);
        }
        else
            nextPlatform.transform.position = gameObject.transform.position + gameObject.GetComponent<BoxCollider>().bounds.size / 2
            +(platformNo==1? Vector3.zero: new Vector3((Random.value-0.3f)*horizontalOffset,(Random.value-0.5f)*verticalOffset, (Random.value - 0.3f)*horizontalOffset));

        if(nextPlatform.transform.position[1]-transform.position[1]>3)
        {
            GameObject plat = Instantiate(miniPlatform);
            plat.transform.position = nextPlatform.transform.position - nextPlatform.GetComponent<BoxCollider>().bounds.size / 2
                + Vector3.up * nextPlatform.GetComponent<BoxCollider>().bounds.size.y * 2/3.0f + new Vector3((Random.value - 0.7f) * horizontalOffset/2.0f, (Random.value - 1f) * verticalOffset/3.0f, (Random.value - 0.7f) * horizontalOffset/2.0f);
            plat.GetComponent<MeshFilter>().mesh = platformMeshes[(int)(Random.value * platformMeshes.Length)];
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
