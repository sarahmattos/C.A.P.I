using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotaoIluminaria : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject luzIluminaria;
    AudioSource souondLampada;
    private CameraManager cm;
    bool valor=true;
    private void Start()
    {
        souondLampada = GetComponent<AudioSource>();
        cm = FindObjectOfType<CameraManager>();
    }
   private void OnMouseDown()
    {
        if(cm.sentado){
            valor = !valor;
            souondLampada.Play();
            luzIluminaria.SetActive(valor);
        }
    }
}
