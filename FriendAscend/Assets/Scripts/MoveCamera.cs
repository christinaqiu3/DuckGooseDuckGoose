using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    Vector3 velocity;
    public bool isTutorial;
    // Start is called before the first frame update
    void Start()
    {
        velocity = new Vector3(1,1,1)*0.5f;
    }

    private void FixedUpdate()
    {
        gameObject.transform.position += velocity * Time.deltaTime * (isTutorial? 0.5f : 1f);
    }

    public void switchTutorialState() {
        isTutorial = !isTutorial;
    }

}
