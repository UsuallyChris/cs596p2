using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attractor : MonoBehaviour {

    static public bool LazyFlight;
    static public bool CircleATree;
    static public bool FollowTheLeader;
    static public Vector3 attractor;
    private Vector3 next;
    private Vector3 temp;
    private Vector3[] positionArray = new Vector3[4];
    private float speed = 20.0f;
    private float rotate = 5.0f;
    private float howClose = 10.0f;

    void Awake()
    {
        LazyFlight = true;
        CircleATree = false;
        FollowTheLeader = false;

        positionArray[0] = new Vector3(100, 50, 100);
        positionArray[1] = new Vector3(100, 50, 0);
        positionArray[2] = new Vector3(0, 50, 0);
        positionArray[3] = new Vector3(0, 50, 100);

        attractor = transform.position;
        nextPos();
    }

    void FixedUpdate()
    {
        attractor = transform.position;

        if(FollowTheLeader)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(next - transform.position), rotate * Time.deltaTime);
            if(Vector3.Distance(next, transform.position) <= howClose)
            {
                generateNext();
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(LazyFlight)
        {
            nextPos();
        }

        if(CircleATree)
        {
            nextWP();
        }
    }

    private void generateNext()
    {
        float x = Random.value * 100f + 50f;
        float y = (Random.value * 40f) + 30f;
        float z = Random.value * 100f + 50f;
        temp.x = x;
        temp.y = y;
        temp.z = z;
        next = attractor + temp;
    }

    private void nextPos()
    {
        float x = Random.value * 200f + 50f;
        float y = (Random.value * 40f) + 30f;
        float z = Random.value * 200f + 50f;
        transform.position = new Vector3(x, y, z);
    }

    private void nextWP()
    {
        if (attractor == positionArray[0])
        {
            transform.position = positionArray[1];
        } else if (attractor == positionArray[1])
        {
            transform.position = positionArray[2];
        } else if (attractor == positionArray[2])
        {
            transform.position = positionArray[3];
        } else if(attractor == positionArray[3])
        {
            transform.position = positionArray[0];
        } else
        {
            transform.position = positionArray[0];
        }
    }
}
