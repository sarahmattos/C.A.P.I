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
        DIA4,
        DIA5,
    };
    // Start is called before the first frame update
    public Fases fases;
    public Compra compra;
    public Documento[] documentos;
    public Impressora impressora;
    public Pontuacao pontucao;
    [SerializeField] GameObject computador;
    [SerializeField] GameObject regras;
    [SerializeField] TMP_Text diaText;
    public UIManager uIManager;
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
            this.fases = Fases.DIA4;
            break;
            case Fases.DIA4:
            this.fases = Fases.DIA5;
            break;
            case Fases.DIA5:
            UIManager.Instance.mudarCena(1);
            break;
        }
        compra.enviarPresente();
        updatePageFases();
        
        UIManager.Instance.changeIntroducao();
        impressora.resetaImpressora();
        pontucao.resetaPontuacao();
        UIManager.Instance.resetaDia();
    }
    public void updatePageFases()
    {
        diaText.text =fases.ToString();
        switch(fases){
            case Fases.DIA1:
            uIManager.idFase=1;
            impressora.folhas = new List<GameObject>();
            foreach (Documento doc in documentos)
            {
                if(doc.dia1) impressora.folhas.Add(doc.gameObject);

            }
           pontucao.maxDocumentos= impressora.folhas.Count;
            break;

            case Fases.DIA2:
            UIManager.Instance.idFase=2;
            computador.SetActive(true);
            regras.SetActive(false);
            impressora.folhas = new List<GameObject>();
            foreach (Documento doc in documentos)
            {
                if(doc.dia2) impressora.folhas.Add(doc.gameObject);

            }
            pontucao.maxDocumentos= impressora.folhas.Count;
            break;

            case Fases.DIA3:
            UIManager.Instance.idFase=3;
            pontucao.ipOn=true;
            //UIManager.Instance.buttonCorIp.SetActive(true);
            UIManager.Instance.buttonCorIpON = true;
            impressora.folhas = new List<GameObject>();
            foreach (Documento doc in documentos)
            {
                if(doc.dia3) impressora.folhas.Add(doc.gameObject);

            }
            pontucao.maxDocumentos= impressora.folhas.Count;
            break;
            case Fases.DIA4:
            UIManager.Instance.idFase=4;
            impressora.folhas = new List<GameObject>();
            foreach (Documento doc in documentos)
            {
                if(doc.dia4) impressora.folhas.Add(doc.gameObject);

            }
           pontucao.maxDocumentos= impressora.folhas.Count;
            break;
            case Fases.DIA5:
            UIManager.Instance.idFase=5;
            UIManager.Instance.botaoProximoPontuacao.SetActive(false);
            UIManager.Instance.botaoCntinuarPontuacao.SetActive(true);
            impressora.folhas = new List<GameObject>();
            foreach (Documento doc in documentos)
            {
                if(doc.dia5) impressora.folhas.Add(doc.gameObject);

            }
           pontucao.maxDocumentos= impressora.folhas.Count;
            break;
        }
    }
}
