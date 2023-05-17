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
    [SerializeField] GameObject tapete;
    [SerializeField] GameObject quadro;
    [SerializeField] Material defaultMaterial;
    [SerializeField] Material pp1;
    [SerializeField] Material pp2;
    [SerializeField] Renderer[] parede;
    public botoesCompra[] btnsCompra;
    public List<botoesCompra> todosBotoes;
    public List<botoesCompra> botoesPP;
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
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Comprar(botoesCompra btnCompra){
        if(!btnCompra.comprado){
             btnCompra.comprado=true;
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
       
        
    }
    public void checarBotoesDinheiro(){
        foreach (botoesCompra botoes in todosBotoes)
        {
           botoes.checaDinheiro();
        }
        foreach (botoesCompra botoes in botoesPP)
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
            if(itemPresente[i].NomeItem=="Tapete"){
                tapete.SetActive(true);
            }
            if(itemPresente[i].NomeItem=="Quadro"){
                quadro.SetActive(true);
            }
        }
        
        presente.SetActive(false);
         evento.aviso.SetActive(false);
         evento.presenteOn=false;
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
        //equipar = !equipar;
        btnCompra.equipado = !btnCompra.equipado;
        if(btnCompra.equipado){
            for(int i=0;i<botoesPP.Count;i++){
                if(botoesPP[i].item.NomeItem != btnCompra.item.NomeItem && botoesPP[i].comprado){
                    botoesPP[i].equipado=false;
                    botoesPP[i].texto.text = "Equipar";
                }
             }
            //desequipa todos os outros
            if(btnCompra.item.NomeItem=="PapelParede1"){
                for(int i=0;i<parede.Length;i++){
                    parede[i].material = pp1;
                }

            }
            if(btnCompra.item.NomeItem=="PapelParede2"){
                for(int i=0;i<parede.Length;i++){
                    parede[i].material = pp2;
                }
            }
             btnCompra.texto.text = "Desquipar";
        }else{
            if(btnCompra.item.NomeItem=="PapelParede1"){
                for(int i=0;i<parede.Length;i++){
                    parede[i].material = defaultMaterial;
                }
            }
            if(btnCompra.item.NomeItem=="PapelParede2"){
                for(int i=0;i<parede.Length;i++){
                    parede[i].material = defaultMaterial;
                }
            }
            btnCompra.texto.text = "Equipar";
        }
    }
}
