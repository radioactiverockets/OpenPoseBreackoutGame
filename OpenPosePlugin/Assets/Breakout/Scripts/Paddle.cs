using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {

	public float paddleSpeed = 1f;
	private Vector3 playerPos = new Vector3(0,-9.5f,0);
    public GameObject rightWrist;
    public GameObject leftWrist;
	
	// Update is called once per frame
	void Update () {

        //if (rightWrist == null)
        //{
        //    rightWrist = GameObject.FindWithTag("Wrist");
        //}
        //else
        //{
        //    float xPos = rightWrist.transform.position.x;
        //    float yPos = rightWrist.transform.position.y;
        //    playerPos = new Vector3(Mathf.Clamp(xPos, -490f, 490f), (Mathf.Clamp(yPos, -350f, 100f)), 0);
        //    transform.position = playerPos;
        //}
        float xPos = transform.position.x + (Input.GetAxis("Horizontal") * 10);
        playerPos = new Vector3(Mathf.Clamp(xPos, -520f, 520f), -9.5f, 0);
        transform.position = playerPos;

        if (leftWrist == null)
        {
            leftWrist = GameObject.FindWithTag("lWrist");
        }
        else
        {
            Debug.Log("Touched");
        }
    }

    //      float xPos = transform.position.x + (Input.GetAxis("Horizontal") * paddleSpeed);
    //playerPos = new Vector3 (Mathf.Clamp (xPos, -450f, 450f), -9.5f, 0);
    //transform.position = playerPos;
}
