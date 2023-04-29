using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Documento : MonoBehaviour
{
    public Sprite[] imageDocumento;
    public string[] textosDocumento;
    AudioSource audioFolha;
    public bool plagioAceito;
    public bool plagioNegado;
    public string respostaCerta;
    public string resposta;
    public Image imagem;
    public GameObject plagio;
    public GameObject naoPlagio;
     public bool dentroImpressora;
     private Rigidbody rb;
    
    private void Start()
    {
        transform.position = new Vector3(-0.08f,0.68f,0.66f);
        audioFolha =GetComponent<AudioSource>();
        dentroImpressora=true;
        rb = GetComponent<Rigidbody>();
        this.gameObject.SetActive(false);
    }
    private void Update()
    {
        if(plagioAceito){
            //imagem.color=Color.green;
            plagio.SetActive(true);
            resposta ="Aceito";
        }
        if(plagioNegado){
            naoPlagio.SetActive(true);
            //imagem.color=Color.red;
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
    public void playSound(){
        audioFolha.Play();
    }
}
