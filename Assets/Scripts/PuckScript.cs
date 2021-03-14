    using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuckScript : MonoBehaviour
{
    public int scoreWorth;
    public Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        Invoke ("GoBall", 2);
    }
    
    void GoBall() {
        float rand = UnityEngine.Random.Range(1, 2);
        if (rand < 1) {
            rb.AddForce (new Vector3 (200, 0, 0));
        } else {
            rb.AddForce (new Vector3 (-600, 0, 0));
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("goal1"))
            Collect2();
        else if (col.CompareTag("goal2"))
            Collect1();
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            transform.Rotate(0, 180, 0);
            Vector3 tempVel = rb.velocity;
            tempVel.x = 250;
            tempVel.z *= 2;
            rb.velocity = tempVel;
            
        } else if (col.gameObject.CompareTag("Player2"))
        {
            //transform.Rotate(0, -180, 0);
            Vector3 tempVel = rb.velocity;
            tempVel.x *= 3;
            tempVel.z *= 2;
            rb.velocity = tempVel;
        }
    }

    private void Collect1()
    {
        GameManager.instance.score1 += scoreWorth;
        GameManager.instance.Respawn();
    }
    
    private void Collect2()
    {
        GameManager.instance.score2 += scoreWorth;
        GameManager.instance.Respawn();
    }
}
