using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverObject : MonoBehaviour
{
    public bool isDragging = false;
    private Rigidbody rb;
    private Vector3 offset;
    public Documento documento;
    public bool enterMouse;
    bool keyDown;
    public float maxX, maxZ, minX, minZ, minY, maxY;
    
    Vector3 spawn= new Vector3(-0.25f,0.66f,-1.5f);
private void Update()
{
  
    if(documento!=null){
        
        if(Input.GetKeyDown(KeyCode.Tab)){   
            if(keyDown==false){
                if(enterMouse && UIManager.Instance.zoomON==false){
                    UIManager.Instance.setActive(true);
                    UIManager.Instance.paginas(documento);
                    keyDown=true;
                    documento.playSound();  
                    UIManager.Instance.zoomON=true;
                 }
            }else{
                 UIManager.Instance.setActive(false);
                UIManager.Instance.resetaIda();
                keyDown=false;
                UIManager.Instance.zoomON=false;
            }
        
    }
        
    }
    //if(transform.position.y<10){
       // transform.position=spawn;
   // }
    rb.freezeRotation =true;
}
private void Start()
{
    rb = GetComponent<Rigidbody>();
    documento = this.GetComponent<Documento>();
}

private void OnMouseDown()
{
    if(documento!=null){
        if(!documento.dentroImpressora){
            isDragging = true;
            offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.WorldToScreenPoint(transform.position).z));
            //rb.freezeRotation = true;
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            UIManager.Instance.SetarCursor(UIManager.Instance.cursorTexture[1]);
        }
       
    }else{
            isDragging = true;
            offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.WorldToScreenPoint(transform.position).z));
            //rb.freezeRotation = true;
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            UIManager.Instance.SetarCursor(UIManager.Instance.cursorTexture[1]);
    }
}

private void OnMouseDrag()
{
    if(documento!=null){
        if(!documento.dentroImpressora){
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.WorldToScreenPoint(transform.position).z);
        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
        curPosition.x = Mathf.Clamp(curPosition.x, minX, maxX);
        curPosition.z = Mathf.Clamp(curPosition.z, minZ, maxZ);
        curPosition.y = Mathf.Clamp(curPosition.y, minY, maxY);
        transform.position = new Vector3(curPosition.x,transform.position.y,curPosition.z);
        //Vector3 movement = new Vector3(curPosition.x,transform.position.y,curPosition.z);
        //rb.AddForce(movement * 1f);
        }
        
    }else{
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.WorldToScreenPoint(transform.position).z);
        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
        curPosition.x = Mathf.Clamp(curPosition.x, minX, maxX);
        curPosition.z = Mathf.Clamp(curPosition.z, minZ, maxZ);
        curPosition.y = Mathf.Clamp(curPosition.y, minY, maxY);
        transform.position = new Vector3(curPosition.x,transform.position.y,curPosition.z);
    }
}

private void OnMouseUp()
{
    isDragging = false;
    UIManager.Instance.SetarCursor(UIManager.Instance.cursorTexture[0]);
}
private void OnMouseEnter()
{
    //if(UIManager.Instance.reseta)enterMouse=true;
    enterMouse=true;
}
 private void OnMouseOver()
 {
     //if(UIManager.Instance.reseta)enterMouse=true;
     enterMouse=true;
 }
private void OnMouseExit()
{
     if(documento!=null){
        enterMouse=false;
       // UIManager.Instance.setActive(false);
       //UIManager.Instance.resetaIda();
     }
}
private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("chao")){
            transform.position=spawn;
        }
    }

}
