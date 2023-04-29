using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipalManager : MonoBehaviour
{
    public GameObject UI_Opcoes;
    private bool mover;

    public GameObject UI_Jogar;
    public GameObject UI_Sair;  

    public GameObject UI_Creditos;
    private bool mover_2;

    public void Opcoes_menu()
    {
        mover = !mover;
        if(mover_2){mover_2 = false;}
    }

    public void Creditos_menu()
    {
        mover_2 = !mover_2;
        if(mover){mover = false;}
    }

    public void Jogar()
    {
        SceneManager.LoadScene(1);
    }

    public void Sair()
    {
        Application.Quit();
    }

    public void Update()
    {
        if(mover)
        {
            
            if(UI_Opcoes.transform.position.y >= 350)
            {
                //Nao faz nada
            }
            else
            {
                //Indo para cima
                UI_Opcoes.transform.position = Vector3.MoveTowards(UI_Opcoes.transform.position, new Vector3(UI_Opcoes.transform.position.x,350f,-1.5f), 450 * Time.deltaTime);
            }
        }
        else
        {
            if(UI_Opcoes.transform.position.y <= -835)
            {
                //Nao faz nada
            }
            else
            {
                //Indo para baixo
                UI_Opcoes.transform.position = Vector3.MoveTowards(UI_Opcoes.transform.position, new Vector3(UI_Opcoes.transform.position.x,-250f,-1.5f), 450 * Time.deltaTime);
            }
        }

        //Movendo os creditos
        if(mover_2)
        {
            
            if(UI_Creditos.transform.position.y >= 350)
            {
                //Nao faz nada
            }
            else
            {
                //Indo para cima
                UI_Creditos.transform.position = Vector3.MoveTowards(UI_Creditos.transform.position, new Vector3(UI_Creditos.transform.position.x,350f,-1.5f), 450 * Time.deltaTime);
            }
        }
        else
        {
            if(UI_Creditos.transform.position.y <= -835)
            {
                //Nao faz nada
            }
            else
            {
                //Indo para baixo
                UI_Creditos.transform.position = Vector3.MoveTowards(UI_Creditos.transform.position, new Vector3(UI_Creditos.transform.position.x,-250f,-1.5f), 450 * Time.deltaTime);
            }
        }
        
        
    }
   
}
