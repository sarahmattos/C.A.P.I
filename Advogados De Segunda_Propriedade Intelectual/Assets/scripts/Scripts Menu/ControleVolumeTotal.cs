using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleVolumeTotal : MonoBehaviour
{
    float volumeMaster;

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public void VolumeMaster(float volume)
    {
        volumeMaster = volume;
        AudioListener.volume = volumeMaster;
    }
}
