using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotaoComputador : MonoBehaviour
{
    AudioSource souondComputador;
    
     private void Start()
    {
        souondComputador = GetComponent<AudioSource>();
    }

     private void OnMouseDown()
    {
      souondComputador.Play();
       UIManager.Instance.abrirCompras();
    }
}
