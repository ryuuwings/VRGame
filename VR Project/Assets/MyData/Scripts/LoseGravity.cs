using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseGravity : MonoBehaviour
{
    public GameObject Cube;
    public int count = 0;
    Rigidbody cubeRigidBody;

    void Start()
    {
        cubeRigidBody = Cube.GetComponent<Rigidbody>();
    }
    void Update()
    {
        if (count == 6)
        {
            cubeRigidBody.useGravity = true;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            count++;
        }
    }
}
