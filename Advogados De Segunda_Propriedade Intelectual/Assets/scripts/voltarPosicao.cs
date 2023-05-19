using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class voltarPosicao : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 spawn2= new Vector3(-0.08f,0.66f,-1.5f);
  
    // Update is called once per frame
     private void OnTriggerStay(Collider other)
    {
        if(other.tag!="Player"&&other.tag!="botao"){
            MoverObject mov = other.gameObject.GetComponent<MoverObject>();
                if(mov.isDragging==false)other.gameObject.transform.position = spawn2;
        }
    }
}
