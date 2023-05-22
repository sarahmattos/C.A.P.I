using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotaoComputador : MonoBehaviour
{
    
    
     private void OnMouseDown()
    {
       UIManager.Instance.abrirCompras();
    }
}
