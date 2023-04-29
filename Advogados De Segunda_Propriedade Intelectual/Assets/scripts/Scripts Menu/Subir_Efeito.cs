using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Subir_Efeito : MonoBehaviour
{
    public GameObject Objeto;

    void OnMouseOver()
    {
        Debug.Log("MOUSE EM CIMA");
        if(Objeto.transform.position.y <= 449)
        Objeto.transform.position = Vector3.MoveTowards(Objeto.transform.position, new Vector3(Objeto.transform.position.x,200f,-1.5f), 450 * Time.deltaTime);
    }

    void OnMouseExit()
    {
        Debug.Log("MOUSE saiu");
        if(Objeto.transform.position.y >= 409)
        Objeto.transform.position = Vector3.MoveTowards(Objeto.transform.position, new Vector3(Objeto.transform.position.x,-100f,-1.5f), 450 * Time.deltaTime);
    }

}
