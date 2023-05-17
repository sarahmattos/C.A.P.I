using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Compra : MonoBehaviour
{
    public List<Itens> itemPresente;
    [SerializeField] GameObject presente;
    //itens
    [SerializeField] GameObject ventilador;
    [SerializeField] GameObject poltrona;
    [SerializeField] GameObject papelParede1;
    [SerializeField] GameObject papelParede2;
    public botoesCompra[] btnsCompra;
    public List<botoesCompra> todosBotoes;
     botoesCompra btnAtual;
    bool equipar;
    // Start is called before the first frame update
    void Start()
    {
        btnsCompra =FindObjectsOfType<botoesCompra>();
        foreach (botoesCompra botoes in btnsCompra)
        {
            todosBotoes.Add(botoes);
        }
        checarBotoesDinheiro();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Comprar(Itens item){
        Pontuacao.Instance.totalFinal -= item.valorItem;
        if(item.presente==true)itemPresente.Add(item);
        mudarInterface(item);
        checarBotoesDinheiro();
        
    }
    public void checarBotoesDinheiro(){
        foreach (botoesCompra botoes in todosBotoes)
        {
           botoes.checaDinheiro();
        }
    }
    public void enviarPresente(){
        //no proximo dia chegar um presente
        checarBotoesDinheiro();
        if(itemPresente!=null){
             presente.SetActive(true);
        }
    }
    public void abrirPresente(){
        for(int i=0; i<itemPresente.Count;i++){
            if(itemPresente[i].NomeItem=="Ventilador"){
                ventilador.SetActive(true);
            }
            if(itemPresente[i].NomeItem=="Poltrona"){
                poltrona.SetActive(true);
            }
        }
        
        presente.SetActive(false);
        itemPresente = new List<Itens>();
        
    }
     public void mudarInterface(Itens item){
        for(int i=0;i<todosBotoes.Count;i++){
            if(todosBotoes[i].item == item){
                btnAtual = todosBotoes[i];
                todosBotoes.Remove(todosBotoes[i]);
            }
        }
        if(!item.presente){
            btnAtual.texto.text = "Equipar";
            
        }else{
            btnAtual.texto.text = "Comprado";
            btnAtual.btn.interactable=false;
            btnAtual.btn.image.color = Color.red;
        }
    }
    public void equiparItem(Itens item){
        equipar = !equipar;
        if(equipar){
            if(item.NomeItem=="PapelParede1"){
                papelParede1.SetActive(true);
            }
            if(item.NomeItem=="PapelParede2"){
                papelParede2.SetActive(true);
            }
        }else{
            if(item.NomeItem=="PapelParede1"){
                papelParede1.SetActive(false);
            }
            if(item.NomeItem=="PapelParede2"){
                papelParede2.SetActive(false);
            }
        }
    }
}
