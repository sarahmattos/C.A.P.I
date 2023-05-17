using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    
    public GameObject cameraSentado;
    public GameObject cameraAndando;
    public bool sentado=true;
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
        mudarCamera();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E)&& troca && evento.mesaOn){
            sentado = !sentado;
            mudarCamera();
            troca=false;
            
        }
        if(Input.GetKeyUp(KeyCode.E)&& troca==false){
            troca = true;
        }
    }
    public void mudarCamera(){
        
        if(sentado){
            evento.aviso.SetActive(false);
            cameraSentado.SetActive(true);
            cameraAndando.SetActive(false);

        }else{
            cameraSentado.SetActive(false);
            cameraAndando.SetActive(true);
             pc.transform.position = posicaoPlayer;
             pc.transform.rotation = rotationPlayer;
            cameraAndando.transform.position = posicaoCamera;
            cameraAndando.transform.rotation = rotationCamera;
            
        }
    }
}
