using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    public Texture2D[] cursorTexture;
    [SerializeField] GameObject panelUiDocumento;
    [SerializeField] Image documentoImage;
    private void Start()
    {
        Instance=this;
        Cursor.SetCursor(UIManager.Instance.cursorTexture[0], Vector3.zero, CursorMode.Auto);
        //Physics.IgnoreLayerCollision(LayerMask.NameToLayer("IgnoreCollision"), LayerMask.NameToLayer("IgnoreCollision"));
    }
    public void setActive(bool valor){
        panelUiDocumento.SetActive(valor);
    }
    public void setImage(Sprite imagem){
        documentoImage.sprite =imagem;
    }
}
 