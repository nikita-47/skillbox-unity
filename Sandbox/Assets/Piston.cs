using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piston : MonoBehaviour
{
    public int pistonForce;
    private float currentTime;
    private bool shouldAddForce;
    private Vector3 pistonVector = new Vector3(0,1,0);
    private Rigidbody rigidbody;

    private void Start()
    {
        shouldAddForce = true;
        rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        currentTime += Time.deltaTime;
        
        if (currentTime > 0)
        {
            shouldAddForce = true;
        }

        if (currentTime > 3)
        {
            currentTime = 0;
            shouldAddForce = false;
        }
     
        if (shouldAddForce)
        {
            rigidbody.AddForce(pistonVector * pistonForce, ForceMode.Force);
        }
    }
}
