using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGrab : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject ball;
    public GameObject hands;
    public GameObject player;
    public float HandPower;

    bool ballGrabed = false;
    // Vector3 initialBallPosition;
    Collider ballCollider;
    Rigidbody ballRigidbody;
    Camera cam;

    void Start()
    {
        // initialBallPosition = ball.transform.position;
        ballCollider = ball.GetComponent<SphereCollider>();
        ballRigidbody = ball.GetComponent<Rigidbody>();
        cam = GetComponentInChildren<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
       
        
    }
    public void grab()
    {
        ball.transform.SetParent(hands.transform);
        ballRigidbody.useGravity = false;
        ball.transform.localPosition = hands.transform.localPosition + (new Vector3(0f, -.999f, 0f));
        player.transform.gameObject.GetComponent<VRGaze>().GVROff();
    }
    public void throwBall()
    {
        ballCollider.isTrigger = false;
        ballRigidbody.useGravity = true;
        ball.transform.SetParent(null);
        ballRigidbody.AddForce(hands.transform.forward * HandPower);
    }
}
