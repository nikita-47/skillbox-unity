using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float hitForce;
    public float moveForce;
    private bool launched=false;
    private float currentTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime > 2 && !launched)
        {
            GetComponent<Rigidbody>().AddForce(moveForce, 0, 0, ForceMode.Impulse);
            launched = true;
        }   
    }
}
