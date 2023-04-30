using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Documento : MonoBehaviour
{
    public Sprite[] imageDocumento;
    [TextArea(100,10000)]
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
    public bool regras;
    private void Start()
    {
        if(!regras){
            transform.position = new Vector3(-0.08f,0.68f,0.66f);
            this.gameObject.SetActive(false);
            dentroImpressora=true;
        }
        audioFolha =GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
        
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
