using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class Selecionador : MonoBehaviour, ISelectHandler
{
    public bool Jogoselecinado = false;
    public bool Sairselecinado = false;
    public bool Creditoselecinado = false;
    public bool Opcoeselecinado = false;


    //public GameObject opcoes;
    public Animator opcoes;
    public Animator creditos;
    public Animator sair;
    public Animator jogar;



    public void OnSelect(BaseEventData eventData)
    {


        

        
        string buttonName = this.gameObject.name;

        switch (buttonName)
        {
            case "jogar":

                // A��o para o Button1
                Debug.Log("Button1 was selected");
                opcoes.Play("OpcoesDescerPouco");
                creditos.Play("CreditoDescerPouco");
                sair.Play("SairDescerPouco");
                jogar.Play("JogoAlto");
                
                break;

            case "opcoes":
                // A��o para o Button2
                Debug.Log("Button2 was selected");

                opcoes.Play("OpcoesSubirPouco");
                creditos.Play("CreditoDescerPouco");
                sair.Play("SairDescerPouco");
                jogar.Play("JogoBaixo");
                break;

            case "credito":
                // A��o para o Button3
                Debug.Log("Button3 was selected");
                opcoes.Play("OpcoesDescerPouco");
                creditos.Play("CreditoSubirPouco");
                sair.Play("SairDescerPouco");
                jogar.Play("JogoBaixo");
                break;

            case "sair":
                // A��o para o Button4
                Debug.Log("Button4 was selected");
                opcoes.Play("OpcoesDescerPouco");
                creditos.Play("CreditoDescerPouco");
                sair.Play("SairSubirPouco");
                jogar.Play("JogoBaixo");
                break;

            default:
                // A��o padr�o caso o nome do bot�o n�o corresponda a nenhum caso
                Debug.Log("Unknown button was selected");
                break;

        }

        }

}
