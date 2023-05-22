using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FasesManager : MonoBehaviour
{
    public enum Fases{
        DIA1,
        DIA2,
        DIA3,
    };
    // Start is called before the first frame update
    public Fases fases;
    public Compra compra;
    public Documento[] documentos;
    public Impressora impressora;
    public Pontuacao pontucao;
    [SerializeField] GameObject computador;
    [SerializeField] TMP_Text diaText;
    void Start()
    {
       // documentos = FindObjectsOfType<Documento>();
        updatePageFases();
        Debug.Log(impressora.esperaTime);
    }
    

    // Update is called once per frame
    public void changeFases()
    {
        switch(fases){
            case Fases.DIA1:
            this.fases = Fases.DIA2;
            break;
            case Fases.DIA2:
            this.fases = Fases.DIA3;
            break;
            case Fases.DIA3:
            this.fases = Fases.DIA1;
            break;
        }
        compra.enviarPresente();
        updatePageFases();
        impressora.resetaImpressora();
        pontucao.resetaPontuacao();
        UIManager.Instance.resetaDia();
    }
    public void updatePageFases()
    {
        diaText.text =fases.ToString();
        switch(fases){
            case Fases.DIA1:
            impressora.folhas = new List<GameObject>();
            foreach (Documento doc in documentos)
            {
                if(doc.dia1) impressora.folhas.Add(doc.gameObject);

            }
           pontucao.maxDocumentos= impressora.folhas.Count;
            break;

            case Fases.DIA2:
            computador.SetActive(true);
            impressora.folhas = new List<GameObject>();
            foreach (Documento doc in documentos)
            {
                if(doc.dia2) impressora.folhas.Add(doc.gameObject);

            }
            pontucao.maxDocumentos= impressora.folhas.Count;
            break;

            case Fases.DIA3:
            impressora.folhas = new List<GameObject>();
            foreach (Documento doc in documentos)
            {
                if(doc.dia3) impressora.folhas.Add(doc.gameObject);

            }
            pontucao.maxDocumentos= impressora.folhas.Count;
            break;
        }
    }
}
