using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour   
{
    [SerializeField] private GameObject PainelPausado;
    [SerializeField] private GameObject PainelControles;
    [SerializeField] private GameObject PainelOpcoes;
    bool PauseOn;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            PauseOn = !PauseOn;
            if (PauseOn)
            {
                AbrirPause();
            }
            else
            {
                Continuar();
            }
        }
    }

    public void Continuar()
    {
        PainelPausado.SetActive(false);
        PauseOn = false;
    }

    public void AbrirPause()
    {
        PainelPausado.SetActive(true);
    }

    public void AbrirControles()
    {
        PainelPausado.SetActive(false);
        PainelControles.SetActive(true);
    }

    public void FecharControles()
    {
        PainelControles.SetActive(false);
        PainelPausado.SetActive(true);       
    }

    public void AbrirOpcoes()
    {
        PainelPausado.SetActive(false);
        PainelOpcoes.SetActive(true);
    }

    public void FecharOpcoes()
    {
        PainelOpcoes.SetActive(false);
        PainelPausado.SetActive(true);
    }

    public void Sair()
    {
        SceneManager.LoadScene("MenuPrincipal");
    }
}
