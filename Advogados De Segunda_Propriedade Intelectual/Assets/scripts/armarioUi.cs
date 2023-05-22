using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class armarioUi : MonoBehaviour
{
    [SerializeField] GameObject[] setas;
    [SerializeField] GameObject armarioPanel;
    [SerializeField] TMP_Text textoUI;
    public Eventos evento;
     [SerializeField] MovementPlayer movementPlayer;
    bool valor;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P)){
          //  interfaceArmario();
        }
    }
    public void escolherCategoriaSeta(int aux){
        for(int i=0;i<setas.Length;i++){
            setas[i].SetActive(false);
        }
        setas[aux].SetActive(true);
    }
    public void escolherCategoriaTexto(string textoIp){
        textoUI.text= textoIp;
    }
    public void interfaceArmario(){
        valor = !valor;
        armarioPanel.SetActive(valor);
        if(valor){
            escolherCategoriaSeta(0);
            movementPlayer.moveSpeed=0;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            evento.armarioaux = true;
        }else{
            movementPlayer.moveSpeed= movementPlayer.moveSpeedDefault;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            evento.armarioaux = false;
        }
       
        escolherCategoriaTexto("Dica geral: Lorem ipsum dolor sit amet. Vel consequatur delectus sit voluptatem nemo ut alias provident hic quam eveniet qui molestiae tenetur. Est quae soluta sit asperiores molestiae vel enim suscipit.Eos voluptatibus corrupti ut odit animi a impedit nihil. Ea cumque exercitationem id omnis odit id neque error? Et voluptatem illo ut veniam fugit 33 maxime tempora id quis vero qui galisum omnis.Vel eveniet repellat et eaque galisum est molestiae quis. Vel facilis delectus vel magnam commodi et fugit perspiciatis.");
    }
}
