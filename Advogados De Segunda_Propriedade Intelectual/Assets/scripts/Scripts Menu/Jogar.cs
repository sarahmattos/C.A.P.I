using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Jogar : MonoBehaviour
{
    [SerializeField] private string nomeDaSala;

    public void Clicou()
    {
        SceneManager.LoadScene(nomeDaSala);
    }
}
