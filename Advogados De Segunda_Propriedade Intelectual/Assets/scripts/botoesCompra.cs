using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class botoesCompra : MonoBehaviour
{
    public Itens item;
    [HideInInspector]
    public TMP_Text texto;
    public TMP_Text textoDinheiro;
    //[HideInInspector]
    public Button btn;
    public bool comprado;
    public bool equipado;
    void Start()
    {
        texto = GetComponentInChildren<TMP_Text>();
        btn = GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        textoDinheiro.text = item.NomeItem+"\n"+"R$"+item.valorItem.ToString()+",00";
    }
    public void checaDinheiro(){
        if(item.valorItem> Pontuacao.Instance.totalFinal){
            if(!comprado)btn.interactable=false;
        }else{
             btn.interactable=true;
        }
    }
}
