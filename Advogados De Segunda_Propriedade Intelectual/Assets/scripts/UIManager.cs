using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    public Texture2D[] cursorTexture;
    Vector2 hotspot;
    [SerializeField] GameObject panelUiDocumento;
    [SerializeField] Image documentoImage;
    private void Start()
    {
        Instance=this;
        SetarCursor(UIManager.Instance.cursorTexture[0]);
        //Physics.IgnoreLayerCollision(LayerMask.NameToLayer("IgnoreCollision"), LayerMask.NameToLayer("IgnoreCollision"));
    }
    public void setActive(bool valor){
        panelUiDocumento.SetActive(valor);
    }
    public void setImage(Sprite imagem){
        documentoImage.sprite =imagem;
    }
    public void SetarCursor(Texture2D textura){
         //hotspot = new Vector2(30*textura.width/100,30*textura.height/100);
         hotspot = new Vector2(0,0);
         Cursor.SetCursor(textura, hotspot, CursorMode.Auto);
    }
}
 