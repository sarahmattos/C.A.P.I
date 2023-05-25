using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    
    public GameObject cameraSentado;
    public GameObject cameraAndando;
    public bool sentado=true;
    public BoxCollider[] boxColliders;
    public Rigidbody rgP;
    bool troca = true;
    public Vector3 posicaoCamera;
    public Vector3 posicaoPlayer;
    public Quaternion rotationCamera;
    public Quaternion rotationPlayer;
    public PlayerController pc;

    public Eventos evento;
    void Start()
    {
        posicaoCamera = cameraAndando.transform.position;
        rotationCamera = cameraAndando.transform.rotation;
        rotationPlayer =  pc.transform.rotation;
        posicaoPlayer =  pc.transform.position;
        boxColliders = pc.gameObject.GetComponentsInChildren<BoxCollider>();
        //mudarCamera();
    }

    // Update is called once per frame
    void Update()
    {
        //if(Input.GetKeyDown(KeyCode.E)&& troca && evento.mesaOn){
          //  sentado = !sentado;
           // mudarCamera();
           // troca=false;
            
       // }
       // if(Input.GetKeyUp(KeyCode.E)&& troca==false && evento.mesaOn==false){
        //    troca = true;
        //}
    }
    public void mudarCamera(){
         sentado = !sentado;
        if(sentado){
            evento.mesaOn=true;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            rgP.useGravity=false;
            evento.aviso.SetActive(false);
            foreach (BoxCollider collider in boxColliders)
                {
                    collider.enabled = false;
                }
            cameraSentado.SetActive(true);
            cameraAndando.SetActive(false);

        }else{
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            foreach (BoxCollider collider in boxColliders)
                {
                    collider.enabled = true;
                }
            rgP.useGravity=true;
            cameraSentado.SetActive(false);
            cameraAndando.SetActive(true);
             pc.transform.position = posicaoPlayer;
             pc.transform.rotation = rotationPlayer;
            cameraAndando.transform.position = posicaoCamera;
            cameraAndando.transform.rotation = rotationCamera;
            evento.mesaOn=false;
            
        }
    }
}
