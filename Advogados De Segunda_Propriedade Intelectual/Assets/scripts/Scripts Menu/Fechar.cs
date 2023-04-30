using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fechar : MonoBehaviour
{
    public void Clicou()
    {
        Debug.Log("Fechou o jogo!");
        Application.Quit();
    }
}
