using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPlayer : MonoBehaviour
{
    public float moveSpeed, moveSpeedDefault;
    
    public float gorundDrag;
    public float PlayerHeight;
    public LayerMask whatIsGround;
    bool grounded;
    public Transform orientation;

    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;
    Rigidbody rb;
    public CameraManager cm;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        moveSpeedDefault = moveSpeed;
        //rb.freezeRotation =true;
    }

    // Update is called once per frame
    void Update()
    {
        grounded = Physics.Raycast(transform.position , Vector3.down, PlayerHeight * 0.5f + 0.2f, whatIsGround);
        myINput();
        speedControl();
        if(grounded)
            rb.drag = gorundDrag;
            else
            rb.drag = 0;
    }
    private void FixedUpdate()
    {
        //if(!cm.sentado)
        move();
    }
    public void myINput(){
       horizontalInput = Input.GetAxisRaw("Horizontal");
       verticalInput = Input.GetAxisRaw("Vertical");
    }
    public void move(){
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.D))
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
        rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
    }
    public void speedControl(){
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f,rb.velocity.z );
        if(flatVel.magnitude>moveSpeed){
            Vector3 limiteVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limiteVel.x,rb.velocity.y,limiteVel.z);
        }
    }
}
