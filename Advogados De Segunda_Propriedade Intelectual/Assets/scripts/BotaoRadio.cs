using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotaoRadio : MonoBehaviour
{
    // Start is called before the first frame update
    AudioSource audioRadio;
    bool valor;
    private void Start()
    {
        audioRadio = GetComponent<AudioSource>();
    }
   public void PlayMusic()
    {
        valor = !valor;
        audioRadio.mute=valor;
    }
}
