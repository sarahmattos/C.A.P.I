using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MOvementCam : MonoBehaviour
{
    // Start is called before the first frame update
    public float sensX;
    public float sensY;
    public Transform orientation;
    float xRotation;
    float yRotation;
    public Eventos evento;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!evento.armarioaux)sens();
    
    }
    public void sens(){
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;
    
        yRotation += mouseX;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f,90f);

        transform.rotation = Quaternion.Euler(xRotation, yRotation,0);
        orientation.rotation =Quaternion.Euler(0, yRotation,0);
    }
}
