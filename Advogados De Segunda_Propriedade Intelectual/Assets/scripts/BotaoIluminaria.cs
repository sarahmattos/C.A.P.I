using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotaoIluminaria : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject luzIluminaria;
    bool valor=true;
   private void OnMouseDown()
    {
        valor = !valor;
        luzIluminaria.SetActive(valor);
    }
}
