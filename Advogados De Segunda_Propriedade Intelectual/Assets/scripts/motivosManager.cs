using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class motivosManager : MonoBehaviour
{
    public Documento doc;
    public TMP_Text[] textos;
    // Start is called before the first frame update
    void Start()
    {
        textos= GetComponentsInChildren<TMP_Text>();
    }

    public void mostrarMotivo(){
        textos[0].text = doc.nomeDocumento;
        textos[1].text = doc.motivoDocumento;
        textos[2].text = doc.respostaCor;
        textos[2].color = doc.corResposta;
    }
}
