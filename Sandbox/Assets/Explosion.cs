using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public float hitForce;
    public float radius;
    private bool launched=false;
    private float currentTime;

    private Rigidbody[] balls;
    // Start is called before the first frame update
    void Start()
    {
        balls = FindObjectsOfType<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction;
        float distance;
        currentTime += Time.deltaTime;
        if (currentTime > 5 && !launched)
        {
            foreach (Rigidbody ball in balls)
            {
                direction = ball.GetComponentInParent<Transform>().position - transform.position;
                distance = Vector3.Distance(ball.GetComponentInParent<Transform>().position, transform.position);
                if (distance < radius)
                {
                    ball.AddForce(direction.normalized * (radius - distance)*hitForce, ForceMode.Impulse);
                }
            }
            //launched = true;
            currentTime = 0;
        }   
    }
}
