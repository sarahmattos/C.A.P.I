using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class armarioUi : MonoBehaviour
{
    [SerializeField] GameObject[] setas;
    [SerializeField] GameObject armarioPanel;
    [SerializeField] TMP_Text textoUI;
    public Eventos evento;
     [SerializeField] MovementPlayer movementPlayer;
     public textoGrande geralTexto;
     public textoGrande atualTexto;
     [SerializeField] GameObject direitaBtn;
     [SerializeField] GameObject esquerdaBtn;

    bool valor;
    int id;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P)){
          //  interfaceArmario();
        }
    }
    public void escolherCategoriaSeta(int aux){
        for(int i=0;i<setas.Length;i++){
            setas[i].SetActive(false);
        }
        setas[aux].SetActive(true);
    }
    public void escolherCategoriaTexto(textoGrande textoIp){
        textoUI.text= textoIp.textosArmario[id];
        atualTexto =textoIp;
        if(id==0){
            if(textoIp.textosArmario.Length>1){
            direitaBtn.SetActive(true);
            esquerdaBtn.SetActive(false);
        }else{
             direitaBtn.SetActive(false);
             esquerdaBtn.SetActive(false);
        }
        }
        
    }
    public void resteId(){
        id=0;
    }
    public void direita(){
         esquerdaBtn.SetActive(true);
            id++;
            escolherCategoriaTexto(atualTexto);
             if(id==atualTexto.textosArmario.Length-1){
                direitaBtn.SetActive(false);
             }
             
        
        
    }
    public void esquerda(){
         direitaBtn.SetActive(true);
        id--;
        escolherCategoriaTexto(atualTexto);
        if(id==0){
                esquerdaBtn.SetActive(false);
             }
    }
    public void interfaceArmario(){
        valor = !valor;
        armarioPanel.SetActive(valor);
        if(valor){
            escolherCategoriaSeta(0);
            escolherCategoriaTexto(geralTexto);
            movementPlayer.moveSpeed=0;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            evento.armarioaux = true;
        }else{
            movementPlayer.moveSpeed= movementPlayer.moveSpeedDefault;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            evento.armarioaux = false;
        }
       
        
    }
}
