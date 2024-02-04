using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public bool Player1;
    int numJumps;
    int maxNumJumps;
    int forceOver2;
    double jumpTime;
    int maxSpeed;
    int maxWaterSpeed;
    public GameManager gameManager;
    float currLemonadeTime;
    float totalLemonadeTime;
    
    // Start is called before the first frame update
    void Start()
    {
        totalLemonadeTime = 5;
        forceOver2 = 5;
        maxSpeed = 10;
        maxWaterSpeed = maxSpeed / 4;
        maxNumJumps = 1;
    }

    private void FixedUpdate()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        
        if (Player1)
        {
            if (Input.GetKey(KeyCode.A))
                rb.AddForce((Vector3.left+Vector3.forward)*forceOver2);
            if (Input.GetKey(KeyCode.D))
                rb.AddForce((Vector3.right-Vector3.forward)*forceOver2);
            if (Input.GetKey(KeyCode.W))
                rb.AddForce((Vector3.forward+Vector3.right)*forceOver2);
            if (Input.GetKey(KeyCode.S))
                rb.AddForce((-Vector3.forward-Vector3.right)*forceOver2);
        }
        else
        {
            if (Input.GetKey(KeyCode.LeftArrow))
                rb.AddForce((Vector3.left + Vector3.forward)*forceOver2);
            if (Input.GetKey(KeyCode.RightArrow))
                rb.AddForce((Vector3.right - Vector3.forward)*forceOver2);
            if (Input.GetKey(KeyCode.UpArrow))
                rb.AddForce((Vector3.forward + Vector3.right)*forceOver2);
            if (Input.GetKey(KeyCode.DownArrow))
                rb.AddForce((-Vector3.forward - Vector3.right)*forceOver2);
        }

        if (Input.GetKeyDown(KeyCode.Space) && numJumps<maxNumJumps)
        {
            rb.AddForce(Vector3.up * 375);
            numJumps++;
            jumpTime = Time.timeAsDouble;
            //Debug.Log("Jumping");
        }
        if (rb.velocity.magnitude > maxSpeed)
            rb.velocity = rb.velocity.normalized * maxSpeed;
    }

    public void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag != "Player"
            && Time.timeAsDouble != jumpTime
            && (collision.gameObject.GetComponent<BoxCollider>()!=null && collision.transform.position.y + collision.gameObject.GetComponent<BoxCollider>().bounds.size.y /2f <= transform.position.y - transform.localScale.y / 3f
            || collision.gameObject.GetComponent<MeshCollider>() && collision.transform.position.y + collision.gameObject.GetComponent<MeshCollider>().bounds.size.y / 3f <= transform.position.y - transform.localScale.y / 3f))
        {
            numJumps = 0;
            //Debug.Log("Not jumping");
        }
        if (collision.gameObject.tag == "FriendAscendWater")
        {
            GetComponent<Rigidbody>().velocity = GetComponent<Rigidbody>().velocity.normalized * maxWaterSpeed;
        }
        if(collision.gameObject.tag == "FriendAscendLemonade")
        {
            currLemonadeTime += Time.deltaTime;
            if (currLemonadeTime > totalLemonadeTime)
            {
                currLemonadeTime = totalLemonadeTime;
                maxNumJumps = 2;
                //Debug.Log("Double jump");
            }
            if (Player1)
                gameManager.GetComponent<GameManager>().fillGooseRing(currLemonadeTime / totalLemonadeTime);
            else
                gameManager.GetComponent<GameManager>().fillDuckRing(currLemonadeTime / totalLemonadeTime);
        }
    }

    public void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "FriendAscendLemonade")
        {
            currLemonadeTime = 0;
            if (Player1)
                gameManager.GetComponent<GameManager>().fillGooseRing(currLemonadeTime / totalLemonadeTime);
            else
                gameManager.GetComponent<GameManager>().fillDuckRing(currLemonadeTime / totalLemonadeTime);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
