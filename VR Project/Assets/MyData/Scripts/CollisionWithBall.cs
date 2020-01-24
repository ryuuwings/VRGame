using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionWithBall : MonoBehaviour
{
   public void OnCollisionEnter(UnityEngine.Collision other)
    {
        if (other.gameObject.CompareTag("Destroyable"))
        {
            Destroy(other.gameObject);
        }
    }
}
