using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverObject : MonoBehaviour
{
    public bool isDragging = false;
    private Rigidbody rb;
    private Vector3 offset;
    public Documento documento;
    public Vector2 hotspot = Vector2.zero;
    public bool enterMouse;
    public float maxX, maxZ, minX, minZ, minY, maxY;

    Vector3 spawn= new Vector3(-0.25f,0.66f,-1.5f);
private void Update()
{
  
    if(documento!=null){
        if(Input.GetKey(KeyCode.Tab)){
                if(enterMouse){
                    Debug.Log("entermouse true "+documento.name);
                    UIManager.Instance.setActive(true);
                    UIManager.Instance.setImage(documento.imageDocumento);
                }
            }else{
                UIManager.Instance.setActive(false);
            }
    }
        

    if(transform.position.y<-10){
        transform.position=spawn;
        rb.freezeRotation =true;
    }
    
}
private void Start()
{
    //uIManager = FindObjectOfType<UIManager>();
    rb = GetComponent<Rigidbody>();
    rb.freezeRotation =true;
    documento = this.GetComponent<Documento>();
    //Cursor.SetCursor(UIManager.Instance.cursorTexture[0], hotspot, CursorMode.Auto);
}

private void OnMouseDown()
{
    if(documento!=null){
        if(!documento.dentroImpressora){
            isDragging = true;
            offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.WorldToScreenPoint(transform.position).z));
            rb.freezeRotation = true;
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            Cursor.SetCursor(UIManager.Instance.cursorTexture[1], hotspot, CursorMode.Auto);
        }
       
    }else{
            isDragging = true;
            offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.WorldToScreenPoint(transform.position).z));
            rb.freezeRotation = true;
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            Cursor.SetCursor(UIManager.Instance.cursorTexture[1], hotspot, CursorMode.Auto);
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
        transform.position = curPosition;
        }
        
    }else{
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.WorldToScreenPoint(transform.position).z);
        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
        curPosition.x = Mathf.Clamp(curPosition.x, minX, maxX);
        curPosition.z = Mathf.Clamp(curPosition.z, minZ, maxZ);
        curPosition.y = Mathf.Clamp(curPosition.y, minY, maxY);
        transform.position = curPosition;
    }
}

private void OnMouseUp()
{
    isDragging = false;
    rb.freezeRotation = false;
    Cursor.SetCursor(UIManager.Instance.cursorTexture[0], hotspot, CursorMode.Auto);
}
private void OnMouseEnter()
{
    
        enterMouse=true;
    
   
    
}
private void OnMouseExit()
{
     if(documento!=null){
        enterMouse=false;
        UIManager.Instance.setActive(false);
     }
}

}
