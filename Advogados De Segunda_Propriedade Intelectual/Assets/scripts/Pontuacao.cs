using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pontuacao : MonoBehaviour
{
    public static Pontuacao Instance;
    AudioSource audioEnvelope;
    public AudioSource audioRelogio;
    public List<Documento> docs;
    bool checar;
    Collider target;
    public int maxDocumentos;
    public int Pontos;
    public int soma;
    public int bonus;
    public int erros;
    public int total;
    public bool fim;
    Vector3 spawn2= new Vector3(-0.08f,0.66f,-1.5f);
    void Start()
    {
        audioEnvelope = GetComponent<AudioSource>();
        Instance =this;
    }

    // Update is called once per frame
    void Update()
    {
        if(checar)Checar(target);
        
    }
     private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Folha"){
            target=other;
            checar=true;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if(other.tag!="Folha"&& other.tag!="Player"){
            MoverObject mov = other.gameObject.GetComponent<MoverObject>();
                if(mov.isDragging==false)other.gameObject.transform.position = spawn2;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.tag=="Folha"){
            
            checar=false;
        }
    }
    public void Checar(Collider other){
        
                MoverObject mov = other.gameObject.GetComponent<MoverObject>();
                if(mov.isDragging==false){
                    Documento doc = other.gameObject.GetComponent<Documento>();
                        if(doc.plagioAceito||doc.plagioNegado){
                            audioEnvelope.Play();
                            docs.Add(doc);
                            other.gameObject.SetActive(false);
                            checar=false;
                                if(docs.Count>=maxDocumentos){
                                     ChecarPontuacao();
                                }
                         }
                         else{
                            other.gameObject.transform.position = spawn2;
                            Rigidbody rg = other.gameObject.GetComponent<Rigidbody>();
                            rg.freezeRotation =true;
                }
            }
            
    }
    public void ChecarPontuacao(){
        foreach(Documento doc in docs){
            if(doc.pontuar()){
                Pontos++;
                soma+=15;

            }else{
                erros+=10;
            }
        }
        if(Pontos==maxDocumentos)bonus = 20;
        total = bonus + soma - erros;
        string acertos=Pontos+"/"+maxDocumentos;
        Debug.Log("Seus pontos: "+Pontos+"/"+maxDocumentos);
        UIManager.Instance.panelFinalTrue(soma,bonus,erros,total,acertos);
        fim=true;
        audioRelogio.Stop();
    }
    public void resetaPontuacao(){
        Pontos=0;
        soma=0;
        erros=0;
        fim=false;
        bonus=0;
        total=0;
        docs = new List<Documento>();
        audioRelogio.Play();
    }
}
