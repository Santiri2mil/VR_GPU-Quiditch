using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource source;
    public BtnSample refBut;
    private void OnEnable()
    {
        refBut.OnTriggerEvent += PlayMusic;
    }
    private void OnDisable()
    {
        refBut.OnTriggerEvent -= PlayMusic;
    }
    public void PlayMusic ()
    {
        source.Play();
        Debug.Log("Subele a esa madre");
    }
}
