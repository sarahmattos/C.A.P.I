using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerOpcoes : MonoBehaviour
{
    [SerializeField] private Animator myOpcoes = null;
    [SerializeField] private bool cimaTrigger = false;
    [SerializeField] private bool baixoTrigger = false;

    private bool comecando = true;
    int contador = 0;
    int controller = 0;


    void Start()
    {
        myOpcoes.Play("OpcoesIdle");
    }

    public void Clicou()
    {
        //Garantindo que da primeira vez que clicar vai subir e que no comeco nao vai bugar a animacao
        if(controller <= 0)
        {
            cimaTrigger = false;
            baixoTrigger = true;
            controller++;
        }
        
        //Invertendo
        if(!comecando && controller >= 1)
        {
            cimaTrigger = !cimaTrigger;
            baixoTrigger = !baixoTrigger;
        }

    }

    void FixedUpdate()
    {
        if(contador < 60)
        {
            contador++;
        }
        else
        {
            comecando = false;
        }
    }

    void Update()
    {
        if(!comecando)
        {
            if(cimaTrigger == true){myOpcoes.Play("OpcoesCima");}
            if(baixoTrigger == true){myOpcoes.Play("OpcoesBaixo");}
        }
        else{myOpcoes.Play("OpcoesIdle");}

    }

 }
