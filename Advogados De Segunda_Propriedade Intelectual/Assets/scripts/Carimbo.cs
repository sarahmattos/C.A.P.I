using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carimbo : MonoBehaviour
{
    // Start is called before the first frame update
    public bool aceitar,negar;
    public bool carimbarBool;
    Collider target;
    AudioSource audioCarimbo;
    MoverObject move;
    void Start()
    {
        move =GetComponentInChildren<MoverObject>();
        audioCarimbo =GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(1) && carimbarBool){
            carimbar(target.gameObject);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if(other.tag=="Folha"){
            target=other;
            if(move.isDragging){
                carimbarBool=true;
            }else{
                carimbarBool=false;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.tag=="Folha"){
            target=null;
            carimbarBool=false;
        }
    }
    public void carimbar(GameObject other){
       Documento doc = other.GetComponent<Documento>();
       if(doc.plagioAceito==false && doc.plagioNegado==false){
            audioCarimbo.Play();
            if(aceitar) doc.plagioAceito=true;
            if(negar) doc.plagioNegado=true;
        
       }
      
    }
}
