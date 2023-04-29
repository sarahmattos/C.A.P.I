using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Documento : MonoBehaviour
{
    public Sprite[] imageDocumento;
    public string[] textosDocumento;
    public bool plagioAceito;
    public bool plagioNegado;
    public string respostaCerta;
    public string resposta;
    public Image imagem;
     public bool dentroImpressora;
     private Rigidbody rb;
    
    private void Start()
    {
        transform.position = new Vector3(-0.25f,0.68f,0.66f);
        dentroImpressora=true;
        rb = GetComponent<Rigidbody>();
        this.gameObject.SetActive(false);
    }
    private void Update()
    {
        if(plagioAceito){
            imagem.color=Color.green;
            resposta ="Aceito";
        }
        if(plagioNegado){
            imagem.color=Color.red;
            resposta ="Negado";
        }
        
    }
    public bool pontuar(){
        if(resposta == respostaCerta){
            return true;
        }else{
            return false;
        }
    }
}
