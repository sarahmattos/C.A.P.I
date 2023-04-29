using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Impressora : MonoBehaviour
{
    [SerializeField] GameObject[] folhas;
    public Material[] materiais;
    Vector3 spawn2= new Vector3(-0.08f,0.66f,-1.5f);
    public GameObject capsulee;
    int id=-1;
    private IEnumerator coroutine;
    public bool aux, jogar;
   
    void Start()
    {
        transform.position = Vector3.MoveTowards(transform.position, spawn2, 1 * Time.deltaTime);

    }

    // Update is called once per frame
    void Update()
    {
        if(jogar){
            capsulee.GetComponent<Renderer>().material =materiais[1];
            folhas[id].SetActive(true);
            folhas[id].transform.position = Vector3.MoveTowards(folhas[id].transform.position, new Vector3(folhas[id].transform.position.x,folhas[id].transform.position.y,-1.5f), 3* Time.deltaTime);
            if(folhas[id].transform.position.z<=spawn2.z ){
                folhas[id].GetComponent<Documento>().dentroImpressora=false;
                 jogar=false;
                 capsulee.GetComponent<Renderer>().material =materiais[0];
            }
          
        }
       
    }
   
    public void lancarFolha(){
        if(id<folhas.Length-1&&jogar==false){
            id++;
            jogar=true;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if(other.tag=="Folha"){
            Documento doc = other.gameObject.GetComponent<Documento>();
            if(!doc.dentroImpressora){
                 MoverObject mov = other.gameObject.GetComponent<MoverObject>();
                if(mov.isDragging==false)other.gameObject.transform.position = spawn2;
            }
           
        }else{
            MoverObject mov = other.gameObject.GetComponent<MoverObject>();
            if(mov !=null){
                if(mov.isDragging==false)other.gameObject.transform.position = spawn2;

            }
        }
    }
    
}
