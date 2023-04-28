using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotaoIMpressora : MonoBehaviour
{
    public Impressora impressora;
    private void OnMouseDown()
{
    impressora.lancarFolha();
    
}
}
