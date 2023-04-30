using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotaoIluminaria : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject luzIluminaria;
    AudioSource souondLampada;
    bool valor=true;
    private void Start()
    {
        souondLampada = GetComponent<AudioSource>();
    }
   private void OnMouseDown()
    {
        valor = !valor;
        souondLampada.Play();
        luzIluminaria.SetActive(valor);
    }
}
