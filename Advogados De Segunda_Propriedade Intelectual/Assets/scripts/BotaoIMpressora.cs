using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotaoIMpressora : MonoBehaviour
{
    public Impressora impressora;
    private CameraManager cm;
    private void Start()
    {
        cm = FindObjectOfType<CameraManager>();
    }
    private void OnMouseDown()
    {
        if(cm.sentado)impressora.lancarFolha();
    
    }
}
