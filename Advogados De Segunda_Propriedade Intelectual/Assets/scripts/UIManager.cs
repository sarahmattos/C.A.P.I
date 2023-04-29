using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    public Texture2D[] cursorTexture;
    Vector2 hotspot;
    [SerializeField] Sprite defaultSprite;
    [SerializeField] TMP_Text textoDocumento;
    [SerializeField] GameObject panelUiDocumento;
    [SerializeField] GameObject esquerdaSeta;
    [SerializeField] GameObject direitaSeta;
    [SerializeField] GameObject zoomTexto;
    [SerializeField] Image documentoImage;
    string[] recebeTextos;
    Sprite[] imagenDefault;
    public bool reseta=true;
    int recebeTamanho;
    int id;
    bool ler=false;
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
    public void paginas(Sprite[] imagensDocumento, string[] textos){
        recebeTextos =textos;
        recebeTamanho=imagensDocumento.Length;
        imagenDefault=imagensDocumento;
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
}
 