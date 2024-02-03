using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    float speed;
    Vector3 velocity;
    public bool isTutorial;
    int currentIndex;
    public GameObject level;
    Vector3 offset;
    Vector3 target;
    GameObject[] players;
    float cameraResizeSpeed;
    // Start is called before the first frame update
    void Start()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
        speed = 2f;
        cameraResizeSpeed = 1.5f;
        currentIndex = 1;
        while (level.transform.GetChild(currentIndex).tag != "FriendAscendPlatform")
            currentIndex++;
        offset = transform.position - level.transform.GetChild(0).transform.position;
        target = level.transform.GetChild(currentIndex).position + offset;
        velocity = (target-transform.position).normalized*speed;
    }

    private void FixedUpdate()
    {
        gameObject.transform.position += velocity * Time.fixedDeltaTime * (isTutorial? 0.5f : 1f);
        if ((target - transform.position).magnitude < 0.5)
        {
            if (currentIndex == level.transform.childCount-1)
            {
                velocity = Vector3.zero;
                target = Vector3.zero;
            }
            else
            {
                currentIndex++;
                while (level.transform.GetChild(currentIndex).tag != "FriendAscendPlatform")
                    currentIndex++;
                target = level.transform.GetChild(currentIndex).position + offset;
                velocity = (target - transform.position).normalized * speed;
            }
        }
    }

    public void Update()
    {
        //resizeCamera();
    }

    public void resizeCamera() {
        Vector2 pos1 = GetComponent<Camera>().WorldToViewportPoint(players[0].transform.position);
        Vector2 pos2 = GetComponent<Camera>().WorldToViewportPoint(players[1].transform.position);

        if ((0.1 >= pos1[0] || 0.1 >= pos1[1]) || (0.1 >= pos2[0] || 0.1 >= pos2[1]) || (0.9 <= pos1[0] || 0.9 <= pos1[1]) || (0.9 <= pos2[0] || 0.9 <= pos2[1]))
            GetComponent<Camera>().orthographicSize += cameraResizeSpeed * Time.deltaTime;
        else if ((0.4 <= pos1[0] && pos1[0] <= 0.6) && (0.4 <= pos1[1] && pos1[1] <= 0.6) && (0.4 <= pos2[0] && pos2[0] <= 0.6) && (0.4 <= pos2[1] && pos2[1] <= 0.6) && GetComponent<Camera>().orthographicSize > 4)
            GetComponent<Camera>().orthographicSize -= cameraResizeSpeed * Time.deltaTime;
        
    }

    public void switchTutorialState() {
        isTutorial = !isTutorial;
    }

}
