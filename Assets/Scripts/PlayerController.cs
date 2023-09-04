using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rigidbody;
    private Animator animator;

    [SerializeField] private float speed = 2f;
    [SerializeField] private float rotationSpeed = 10f;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");



        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 3f;
        }
        else
        {
            speed = 2f;

        }
       
            Vector3 directionVector = new Vector3(-v, 0, h);

        if(directionVector.magnitude > Mathf.Abs(0.05f))
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(directionVector), Time.deltaTime * rotationSpeed);  

        animator.SetFloat("Speed", Vector3.ClampMagnitude(directionVector, 1).magnitude);
        rigidbody.velocity = Vector3.ClampMagnitude(directionVector,1) * speed;
    }
}
