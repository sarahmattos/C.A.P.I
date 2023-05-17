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
    public Eventos evento;
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
    public void Comprar(botoesCompra btnCompra){
        if(!btnCompra.comprado){
             Pontuacao.Instance.totalFinal -= btnCompra.item.valorItem;
             mudarInterface(btnCompra);
            checarBotoesDinheiro();
            if(btnCompra.item.presente==true){
                itemPresente.Add(btnCompra.item);
            }else{
                equiparItem(btnCompra);
            }
        }else{
            if(!btnCompra.item.presente){
                equiparItem(btnCompra);
            }
        }
        btnCompra.comprado=true;
        
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
        if(itemPresente.Count>0){
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
         evento.aviso.SetActive(false);
        itemPresente = new List<Itens>();
        
    }
     public void mudarInterface(botoesCompra btnCompra){
        for(int i=0;i<todosBotoes.Count;i++){
            if(todosBotoes[i].item.NomeItem == btnCompra.item.NomeItem){
                todosBotoes.Remove(todosBotoes[i]);
            }
        }
        if(btnCompra.item.presente){
            btnCompra.texto.text = "Comprado";
            btnCompra.btn.interactable=false;
            btnCompra.btn.image.color = Color.red;
        }
            
        
    }
    public void equiparItem(botoesCompra btnCompra){
        equipar = !equipar;
        if(equipar){
            if(btnCompra.item.NomeItem=="PapelParede1"){
                papelParede1.SetActive(true);
            }
            if(btnCompra.item.NomeItem=="PapelParede2"){
                papelParede2.SetActive(true);
            }
             btnCompra.texto.text = "Desquipar";
        }else{
            if(btnCompra.item.NomeItem=="PapelParede1"){
                papelParede1.SetActive(false);
            }
            if(btnCompra.item.NomeItem=="PapelParede2"){
                papelParede2.SetActive(false);
            }
            btnCompra.texto.text = "Equipar";
        }
    }
}
