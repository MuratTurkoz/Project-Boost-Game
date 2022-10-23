using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour, IMovement
{

    Rigidbody rb;
    [SerializeField] float mainThrust = 100f;
    [SerializeField] float rotationThrust = 1f;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {

        ProcessThrust();
        ProcessRotation();
    }

    public void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.LeftArrow))//Böylede yazılabilir
        {
            ApplyRotation(rotationThrust);
            // rb.MoveRotation(Quaternion.Euler());

        }
        // else if (Input.GetKeyDown(KeyCode.RightArrow))//Tek birkez çalışır.
        // {
        //     // rb.AddForce(Vector3.right, ForceMode.Force);
        //     transform.Rotate(-Vector3.forward * Time.deltaTime * mainThrust);
        //     //Vector3.forward 0 0 1
        // }
        //  asdasas
        else if (Input.GetKey(KeyCode.RightArrow))//Tek birkez çalışır.
        {
            ApplyRotation(-rotationThrust);
            // rb.AddForce(Vector3.right, ForceMode.Force);
            // transform.Rotate(Vector3.back * Time.deltaTime * rotationThrust);
            //Vector3.forward 0 0 1
        }
    }
    void ApplyRotation(float rotationThisFrame)
    {
        rb.freezeRotation = true;
        transform.Rotate(Vector3.forward * Time.deltaTime * rotationThisFrame);
        rb.freezeRotation = false;
    }

    /*Force 
    Add a continuous force to the rigidbody, using its mass.
    Kütlesini kullanarak katı cisme sürekli bir kuvvet ekleyin.
    Acceleration 
    Add a continuous acceleration to the rigidbody, ignoring its mass.
    Kütlesini göz ardı ederek katı cisme sürekli bir ivme ekleyin.
    Impulse	
    Add an instant force impulse to the rigidbody, using its mass.
    Kütlesini kullanarak katı cisme anlık bir kuvvet impulsu ekleyin.
    VelocityChange 
    Kütlesini yok sayarak, katı cisme anlık bir hız değişikliği ekleyin.
*/

    public void ProcessThrust()
    {
        if (Input.GetKey("up"))//Basılı tutulduğu kadar çalışır.
        {
            // float val = Input.GetAxis("up");
            // Debug.Log(val);
            // Vector2.up
            rb.AddForce(Vector2.up * mainThrust * Time.deltaTime);
        }

        // else if (Input.GetKeyDown("space"))//Tek birkez çalışır.
        // {
        //     rb.AddRelativeForce(100 * Time.deltaTime, 10, 10);
        //     // rb.AddForce(100 * Time.deltaTime, 10, 10, ForceMode.Force);
        // }
        else if (Input.GetKey("space"))
        {
            rb.AddRelativeForce(Vector2.up * Time.deltaTime * mainThrust, ForceMode.Force);
            // rb.AddForce(100 * Time.deltaTime, 10, 10, ForceMode.Force);
        }
        /*Vector3.up    0,1,0
        Vector3.down    0,-1,0
        Vector3.forward 0,0,1
        Vector3.back    0,0,-1
        Vector3.right   1,0,0
        Vector3.left   -1,0,0
        Vector3.one     1,1,1
        Vector3.zero    0,0,0
        */
        /*Force 
        Add a continuous force to the rigidbody, using its mass.
        Kütlesini kullanarak katı cisme sürekli bir kuvvet ekleyin.
        
        Acceleration 
        Add a continuous acceleration to the rigidbody, ignoring its mass.
        Kütlesini göz ardı ederek katı cisme sürekli bir ivme ekleyin.
        
        Impulse	
        Add an instant force impulse to the rigidbody, using its mass.
        Kütlesini kullanarak katı cisme anlık bir kuvvet impulsu ekleyin.
        
        VelocityChange 
        Kütlesini yok sayarak, katı cisme anlık bir hız değişikliği ekleyin.
    */
    }
}
