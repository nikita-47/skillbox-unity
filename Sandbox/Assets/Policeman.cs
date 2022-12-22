using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Policeman : MonoBehaviour
{
    public float hitForce;
    public float moveForce;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        GetComponent<Rigidbody>().AddForce(0, 0, moveForce, ForceMode.Force);
    }

    void OnCollisionEnter(Collision collision)
    {
        Rigidbody target = collision.gameObject.GetComponent<Rigidbody>();
        Vector3 direction = collision.gameObject.transform.position- transform.position;
        Vector3 force = direction.normalized * hitForce;
        if (collision.gameObject.tag == "zombie"&& target != null)
        {
            target.AddForce(force, ForceMode.Impulse);
        }
    }
}
