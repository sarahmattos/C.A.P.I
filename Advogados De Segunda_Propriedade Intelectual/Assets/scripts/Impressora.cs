using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Impressora : MonoBehaviour
{
    public static Impressora Instance;
    public List<GameObject> folhas;
    [SerializeField] GameObject folhaBranca;
    [SerializeField] GameObject folhaBrancaDefault;
    public Material[] materiais;
    Vector3 spawn2= new Vector3(-0.08f,0.66f,-1.5f);
    public GameObject capsulee;
    AudioSource audioImpressora;
    [HideInInspector]
    public int id=-1;
    private IEnumerator coroutine;
    public bool aux, jogar, boolJogar;
    Coroutine currentCourotine;
    public float esperaTime, esperaTime2;
    Rigidbody rgFolhaBranca;
    public Transform transFolhaBranca;
    public Vector3 inicialTransP;
    public Quaternion inicialTransR;
    void Start()
    {
        transform.position = Vector3.MoveTowards(transform.position, spawn2, 1 * Time.deltaTime);
        audioImpressora = GetComponent<AudioSource>();   
        transFolhaBranca= folhaBranca.GetComponent<Transform>();
        inicialTransP=transFolhaBranca.position;
        inicialTransR=transFolhaBranca.rotation;
        rgFolhaBranca= folhaBranca.GetComponent<Rigidbody>();
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if(jogar){
            folhas[id].SetActive(true);
            folhas[id].transform.position = Vector3.MoveTowards(folhas[id].transform.position, new Vector3(folhas[id].transform.position.x,folhas[id].transform.position.y,-1.5f), 3* Time.deltaTime);
            if(folhas[id].transform.position.z<=spawn2.z ){
                 folhas[id].GetComponent<Documento>().dentroImpressora=false;
                jogar=false;
                rgFolhaBranca.useGravity=false;
                 if(id<folhas.Count-1){
                    transFolhaBranca.position=inicialTransP;
                    transFolhaBranca.rotation=inicialTransR;
                 }else{
                    transFolhaBranca.gameObject.SetActive(false);
                 }
                if(id==folhas.Count-2)folhaBrancaDefault.SetActive(false);
                 coroutine = esperaEmudaCor(esperaTime2);
                StartCoroutine(coroutine);
            }
          
        }
       
    }
    IEnumerator esperaEvai(float time){
        yield return new WaitForSeconds(time);
        jogar=true;
    }
    IEnumerator esperaEmudaCor(float time){
        yield return new WaitForSeconds(time);
        capsulee.GetComponent<Renderer>().material =materiais[0];
        boolJogar=false;
    }
    public void lancarFolha(){
        if(id<folhas.Count-1&&boolJogar==false){
            boolJogar=true;
            id++;
            audioImpressora.Play();
            capsulee.GetComponent<Renderer>().material =materiais[1];
            rgFolhaBranca.useGravity=true;
            coroutine = esperaEvai(esperaTime);
            StartCoroutine(coroutine);
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
    public void resetaImpressora(){
        id=-1;
         transFolhaBranca.position=inicialTransP;
        transFolhaBranca.rotation=inicialTransR;
         transFolhaBranca.gameObject.SetActive(true);
         folhaBrancaDefault.SetActive(true);
    }
    
}
