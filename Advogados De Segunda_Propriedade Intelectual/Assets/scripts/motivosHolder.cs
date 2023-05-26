using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class motivosHolder : MonoBehaviour
{
    [SerializeField] motivosManager[] motivos;
    // Start is called before the first frame update
    
    

    // Update is called once per frame
    public void ativarMotivos(){
        for(int i =0;i< motivos.Length; i++){
            motivos[i].gameObject.SetActive(false);
        }
        for(int i =0;i< Impressora.Instance.folhas.Count; i++){
            motivos[i].gameObject.SetActive(true);
            motivos[i].doc =Impressora.Instance.folhas[i].GetComponent<Documento>();
            motivos[i].mostrarMotivo();
        }
        
    }
    private void Update()
    {
        ativarMotivos();
    }
}
