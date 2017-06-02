using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        GetComponent<AudioSource>().Play();

        // Make the arrow's RigidBody "kinematic", to freeze its movement when it collides with something
        GetComponent<Rigidbody>().isKinematic = true;

        // Child its transform component to the GameObject it collided with, so if that object moves, the arrow moves with it
        transform.parent = collision.transform;
    }
}