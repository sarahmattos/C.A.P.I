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
    public AudioClip lerfolha;
    public bool plagioAceito=false;
    public bool plagioNegado=false;
    public int corId=-1;
    public int idCerto;
    public string respostaCerta;
    [HideInInspector]
    public string resposta;
    public Image imagem;
    public GameObject plagio;
    public GameObject naoPlagio;
    [HideInInspector]
     public bool dentroImpressora;
     private Rigidbody rb;
    public bool regras;
    public bool introducao;
    public bool dia1;
    public bool dia2;
    public bool dia3;
    public bool dia4;
    public bool dia5;

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
    public bool pontuarId(){
        if(corId == idCerto){
            return true;
        }else{
            return false;
        }
    }
    public void playSound(){
        audioFolha.Play();
    }
}
