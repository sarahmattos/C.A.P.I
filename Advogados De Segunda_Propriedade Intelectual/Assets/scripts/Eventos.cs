using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Eventos : MonoBehaviour
{
    public bool globoOn, radioOn, mesaOn;
    public BotaoRadio btnRadio;
    public GameObject aviso;
    public CameraManager cm;
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
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Mesa") {
            mesaOn=false;
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
    }
}