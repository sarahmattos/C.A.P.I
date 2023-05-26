using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class UIManager : MonoBehaviour
{
    FasesManager fasesManager;
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
    [SerializeField] GameObject panelFinal2;
    [SerializeField] public GameObject buttonCorIp;
    public bool buttonCorIpON;
    [SerializeField] TMP_Text bonuUI;
    [SerializeField] TMP_Text somaUI;
    [SerializeField] TMP_Text erroUI;
    [SerializeField] TMP_Text totalUI;
    [SerializeField] TMP_Text tota2lUI;
    [SerializeField] TMP_Text quantidade;
    [SerializeField] TMP_Text quantidade2;
    [SerializeField] TMP_Text analise;
    [SerializeField] TMP_Text dinheiro;
    [SerializeField] TMP_Text diasText;
    [SerializeField] GameObject panelCompra;
    [SerializeField] GameObject panelCompraObjeto;
    [SerializeField] GameObject panelCompraPapeis;
    [SerializeField] Color[] coresIP;
    [SerializeField]public  Color coreIPDefalut;
    public Image imgIpCor;
   [SerializeField] private CanvasGroup telfinalgrupo;

    [SerializeField] private bool fadeIn = false;
    [SerializeField] private bool fadeOut = false;

    string[] recebeTextos;
    Sprite[] imagenDefault;
    [SerializeField] public GameObject botaoProximoPontuacao;
    [SerializeField] public GameObject botaoCntinuarPontuacao;
    [SerializeField] Image spriteIntroducao;
    public bool reseta=true;
    int recebeTamanho;
    public Documento doc;
    int id;
    public int idFase;
    public int auxcor;
    bool ler=false;
    public bool zoomON;
    public bool compraON;
    public Compra compra;
    public Documento documentoIntroducao;

    bool pararmusica;
    public AudioSource souondComputador;
    public AudioSource souondClick;
    [SerializeField] AudioSource auidoLeitura;
    private void Start()
    {
        Instance=this;
        SetarCursor(UIManager.Instance.cursorTexture[0]);
        //Physics.IgnoreLayerCollision(LayerMask.NameToLayer("IgnoreCollision"), LayerMask.NameToLayer("IgnoreCollision"));
    }
    
    public void setActive(bool valor){
        panelUiDocumento.SetActive(valor);
        
    }  
    public void ativar(GameObject panel){
        panel.SetActive(true);
        
    }  
    public void dsativar(GameObject panel){
        panel.SetActive(false);
        
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
    public void ouvirTexto(){
        pararmusica =!pararmusica;
        if(!doc.introducao){
            auidoLeitura.clip = doc.lerfolha;
        }else{
             auidoLeitura.clip = doc.audiosIntroducao[idFase-1];
        }
        
        if(pararmusica)auidoLeitura.Play();
        if(!pararmusica)auidoLeitura.Stop();
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
    public void changeIntroducao(){
       spriteIntroducao.sprite =documentoIntroducao.imageDocumento[idFase-1];
    }
    public void paginas(Documento documento){
        
        if(!documento.introducao){
            recebeTextos =documento.textosDocumento;
            recebeTamanho=documento.imageDocumento.Length;
            imagenDefault=documento.imageDocumento;
            if(buttonCorIpON){
                buttonCorIp.SetActive(true);
            }
        }else{
            buttonCorIp.SetActive(false);
            recebeTamanho=1;
            recebeTextos= new string[recebeTamanho];
            recebeTextos[0] =documento.textosDocumento[idFase-1];
            imagenDefault = new Sprite[recebeTamanho];
            imagenDefault[0]=documento.imageDocumento[idFase-1];
        }
        
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
        auidoLeitura.Stop();
        pararmusica =false;
    }
    public void panelFinalTrue(int soma, int bonus, int erro, int total, string acertos){


        panelFinal.SetActive(true);
        ShowUi();
        //HideUi();
        diasText.text = "DIA "+idFase;
        somaUI.text+= soma.ToString()+",00";
        erroUI.text+= erro.ToString()+",00";
        totalUI.text+= total.ToString()+",00";
        quantidade.text=acertos;
        if(bonus>0){
            bonuUI.text+= bonus.ToString()+",00";
            bonuObj.SetActive(true);
        }
        
    }
    public void detalhesFnais(int pontos, int dinheiro){
        panelFinal2.SetActive(true);
        tota2lUI.text= " R$ "+dinheiro.ToString()+",00";
        quantidade2.text= pontos.ToString()+"/17";
        if(pontos>=0&& pontos<6){
            analise.text= "E eu achando que eu fazia mal o meu trabalho, pelo visto tem sempre alguém pior, é meu caro, parece que uma semana já foi o suficiente para ver que esse trabalho não é para você, 'VOCÊ ESTÁ DEMITIDO !!!' imagina eu falando isso gritando, sempre quis fazer isso. Do seu antigo chefe Sobs.";
        }
        if(pontos>=6 && pontos<12){
            analise.text= "O RH disse que você foi mais ou menos, mas não se preocupe, seu amigo Sobs te defendeu. Eu disse que você está apenas se adaptando e espero que você pegue no tranco logo, mas caso contrário, vou ter que tomar medidas mais severas. Do seu chefe, Sobs.";
        }
        if(pontos>=12 && pontos<16){
            analise.text= "Parabéns! Pelo que ouvi falar do RH, você está se saindo muito bem. É sua primeira semana, então não espere um aumento ou algo do tipo. No entanto, continue assim e você chegará longe. Do seu amigão e chefe, Sobs.";
        }
        if(pontos>=15 ){
            analise.text= "Caramba eu não esperava isso de você , mas devo dizer que você superou minhas expectativas, PARABÉNS!!! você se saiu muito bem, mas vou dizer uma vez só: NÃO ROUBE MEU TRABALHO EU SEI ONDE VOCÊ MORA!";
        }
        
    }
    public void resetaDia(){
        somaUI.text = "R$ ";
        erroUI.text = "R$ ";
        totalUI.text = "R$ ";
        bonuUI.text= "R$ ";
        telfinalgrupo.alpha = 0;
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
            if(telfinalgrupo.alpha >= 1) { fadeIn = false;  }


        }
       
        dinheiro.text ="R$"+Pontuacao.Instance.totalFinal.ToString()+",00";
        
    }
    public void abrirCompras(){
        compraON = !compraON;
            if(compraON){
                souondComputador.Play();
                compra.checarBotoesDinheiro();
                panelCompra.SetActive(true);
                panelObjetoCompra();
            }
    }

    public void Click(){

        souondClick.Play();
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
    public void mudaCor(Image img){
        img.color= coresIP[auxcor];
        doc.corId = auxcor;
        auxcor++;
        if(auxcor>=coresIP.Length){
            auxcor=0;
        }
       
        
        
    }
}
 