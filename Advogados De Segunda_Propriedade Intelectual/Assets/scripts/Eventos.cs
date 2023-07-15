using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Eventos : MonoBehaviour
{
    public bool globoOn, radioOn, mesaOn, presenteOn, armarioOn, luzOn;
    public BotaoRadio btnRadio;
    public bool acenderam;
    public GameObject aviso;
    public CameraManager cm;
    public Compra compra;
    public armarioUi armario;
    public Animator globo;
    public GameObject luz;
    public bool armarioaux;
    public AudioSource interruptorSFX, globoSFX;

    public Animator luzanim;

    // Start is called before the first frame update
    void Start()
    {
        mesaOn=true;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E)){
            if(radioOn)btnRadio.PlayMusic();
            if(presenteOn)compra.abrirPresente();
            if(mesaOn&&!UIManager.Instance.compraON && !UIManager.Instance.zoomON)cm.mudarCamera();
            if(globoOn){
                globo.Play("GloboGirando");
                Debug.Log("rodou");
                globoSFX.Play();
            }
            if(armarioOn)armario.interfaceArmario();
             if(luzOn)acender();
        }

    }

    public void acender(){
        interruptorSFX.Play();
        acenderam = !acenderam;
        if(acenderam == true){

            luz.SetActive(false);
            luzanim.SetBool("LuzOff", true);

        }
        else
        {
            luz.SetActive(true);
            luzanim.SetBool("LuzOff", false);
        }


    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Mesa") {
            mesaOn=true;
            if(!cm.sentado)aviso.SetActive(true);
        }
        if (other.gameObject.tag == "Globo") {
            globoOn=true;
            aviso.SetActive(true);
        }
        if (other.gameObject.tag == "Radio") {
            radioOn=true;
            aviso.SetActive(true);
        }
        if (other.gameObject.tag == "Presente") {
            presenteOn=true;
            aviso.SetActive(true);
        }
        if (other.gameObject.tag == "Armario") {
            armarioOn=true;
            aviso.SetActive(true);
        }

        if (other.gameObject.tag == "Luz") {
            luzOn=true;
            aviso.SetActive(true);

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Mesa") {
            if(!cm.sentado)mesaOn=false;
            aviso.SetActive(false);
        }
        if (other.gameObject.tag == "Globo") {
            globoOn=false;
            aviso.SetActive(false);
        }
        if (other.gameObject.tag == "Radio") {
            radioOn=false;
            aviso.SetActive(false);
        }
        if (other.gameObject.tag == "Presente") {
            presenteOn=false;
            aviso.SetActive(false);
        }
        if (other.gameObject.tag == "Armario") {
            armarioOn=false;
            aviso.SetActive(false);
        }
        if (other.gameObject.tag == "Luz") {
            luzOn=false;
            aviso.SetActive(false);
        }
    }
}
