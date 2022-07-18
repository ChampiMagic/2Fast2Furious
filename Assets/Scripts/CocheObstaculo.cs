using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CocheObstaculo : MonoBehaviour
{


    public GameObject cronometroGO;
    public Cronometro cronometroScript;

    public GameObject audioFX;
    public AudioFX audioFXScript;

    void Start()
    {
        cronometroGO = GameObject.FindObjectOfType<Cronometro>().gameObject;
        cronometroScript = cronometroGO.GetComponent<Cronometro>();

        audioFX = GameObject.FindObjectOfType<AudioFX>().gameObject;
        audioFXScript = audioFX.GetComponent<AudioFX>();
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.GetComponent<Coche>() != null)
        {

            audioFXScript.FXSonidoChoque();
            cronometroScript.tiempo = cronometroScript.tiempo - 20;
            Destroy(this.gameObject);
        }
    }
}
