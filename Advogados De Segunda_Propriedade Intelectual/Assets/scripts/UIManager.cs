using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    public Texture2D[] cursorTexture;
    public Sprite compradoImage, equiparImage, desequiparImage;
    Vector2 hotspot;
    [SerializeField] Sprite defaultSprite;
    [SerializeField] TMP_Text textoDocumento;
    [SerializeField] GameObject panelUiDocumento;
    [SerializeField] GameObject seta1;
    [SerializeField] GameObject seta2;
    [SerializeField] GameObject esquerdaSeta;
    [SerializeField] GameObject direitaSeta;
    [SerializeField] GameObject zoomTexto;
    [SerializeField] Image documentoImage;
    [SerializeField] GameObject bonuObj;
    [SerializeField] GameObject panelFinal;
    [SerializeField] TMP_Text bonuUI;
    [SerializeField] TMP_Text somaUI;
    [SerializeField] TMP_Text erroUI;
    [SerializeField] TMP_Text totalUI;
    [SerializeField] TMP_Text quantidade;
    [SerializeField] TMP_Text dinheiro;
    [SerializeField] GameObject panelCompra;
    [SerializeField] GameObject panelCompraObjeto;
    [SerializeField] GameObject panelCompraPapeis;

   [SerializeField] private CanvasGroup telfinalgrupo ;

    [SerializeField] private bool fadeIn = false;
    [SerializeField] private bool fadeOut = false;

    string[] recebeTextos;
    Sprite[] imagenDefault;
    public bool reseta=true;
    int recebeTamanho;
    public Documento doc;
    int id;
    bool ler=false;
    public bool zoomON;
    public bool compraON;
    public Compra compra;
    private void Start()
    {
        Instance=this;
        SetarCursor(UIManager.Instance.cursorTexture[0]);
        //Physics.IgnoreLayerCollision(LayerMask.NameToLayer("IgnoreCollision"), LayerMask.NameToLayer("IgnoreCollision"));
    }
    public void setActive(bool valor){
        panelUiDocumento.SetActive(valor);
        
    }
    
    public void configuracaoSetas(){
        if(recebeTamanho>1){
                if(id!=recebeTamanho-1){
                    if(id==0){
                    direitaSeta.SetActive(true);
                    esquerdaSeta.SetActive(false);
                }else{
                    direitaSeta.SetActive(true);
                    esquerdaSeta.SetActive(true);
                }
            }else{
                direitaSeta.SetActive(false);
                esquerdaSeta.SetActive(true);
            }
        }else{
            direitaSeta.SetActive(false);
            esquerdaSeta.SetActive(false);
        }
    }
    public void LerTexto(){
        ler=!ler;
        if(ler)setTexto();
        if(!ler)setImage();
    }
    
    public void setImage(){
        Debug.Log("id: "+id+" tamanho: "+recebeTamanho);
         textoDocumento.text="";
        documentoImage.sprite =imagenDefault[id];
        zoomTexto.SetActive(false);
    }
    public void setTexto(){
         textoDocumento.text = recebeTextos[id];
         zoomTexto.SetActive(true);
    }
    public void chamarCerto(){
        configuracaoSetas();
        doc.playSound();
        if(ler){
            setTexto();
        }else{
            setImage();
        }
    }
    public void setaDireita(){
        id++;
        chamarCerto();
    }
    
    public void setaEsquerda(){
        id--;
        chamarCerto();
    }
    public void paginas(Documento documento){
        recebeTextos =documento.textosDocumento;
        recebeTamanho=documento.imageDocumento.Length;
        imagenDefault=documento.imageDocumento;
        doc=documento;
        setImage();
        chamarCerto();
    }
    public void SetarCursor(Texture2D textura){
         //hotspot = new Vector2(30*textura.width/100,30*textura.height/100);
         hotspot = new Vector2(0,0);
         Cursor.SetCursor(textura, hotspot, CursorMode.Auto);
    }
    public void resetaIda(){
        id=0;
        ler=false;
    }
    public void panelFinalTrue(int soma, int bonus, int erro, int total, string acertos){


        panelFinal.SetActive(true);
        ShowUi();
        //HideUi();
        somaUI.text+= soma.ToString()+",00";
        erroUI.text+= erro.ToString()+",00";
        totalUI.text+= total.ToString()+",00";
        quantidade.text=acertos;
        if(bonus>0){
            bonuUI.text+= bonus.ToString()+",00";
            bonuObj.SetActive(true);
        }
        
    }
    public void resetaDia(){
        somaUI.text = "R$ ";
        erroUI.text = "R$ ";
        totalUI.text = "R$ ";
        bonuUI.text= "R$ ";
        HideUi();
        panelFinal.SetActive(false);
         bonuObj.SetActive(false);
    }
    public void mudarCena(int i){
         SceneManager.LoadScene(i);
    }


    public void ShowUi()
    {

        fadeIn = true;

    }

    public void HideUi()
    {

        fadeOut = true;

    }

    private void Update()
    {

        if(fadeIn == true)
        {

            telfinalgrupo.alpha += Time.deltaTime;
            if(telfinalgrupo.alpha >= 1) { fadeIn = false; }

        }
        if(Input.GetKeyDown(KeyCode.C)){
            compraON = !compraON;
            if(compraON){
                compra.checarBotoesDinheiro();
                panelCompra.SetActive(true);
                panelCompraObjeto.SetActive(true);
                panelCompraPapeis.SetActive(false);
            }else{
                if(!compraON)panelCompra.SetActive(false);
            }
            
        }
        dinheiro.text ="R$"+Pontuacao.Instance.totalFinal.ToString()+",00";
        
    }
    public void fechar(){
        compraON = !compraON;
        if(!compraON){
            panelCompra.SetActive(false);
        }
    }
    public void panelObjetoCompra(){
        panelCompraObjeto.SetActive(true);
        panelCompraPapeis.SetActive(false);
        seta1.SetActive(true);
        seta2.SetActive(false);
    }
    public void panelPapeisCompra(){
        panelCompraObjeto.SetActive(false);
        panelCompraPapeis.SetActive(true);
        seta1.SetActive(false);
        seta2.SetActive(true);
    }
}
 