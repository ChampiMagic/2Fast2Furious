using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuentaAtras : MonoBehaviour
{

     public GameObject motorCarreterasGO;
     public MotorCarreteras motorCarreterasScript;

     public Sprite[] numeros;

     public GameObject contadorNumerosGO;
     public SpriteRenderer contadorNumerosComp;

     public GameObject controladorCocheGO;
     public GameObject cocheGO;
    
    void Start()
    {
        InicioComponentes();
    }

    void InicioComponentes()
    {
        motorCarreterasGO = GameObject.Find("MotorCalle");
        motorCarreterasScript = motorCarreterasGO.GetComponent<MotorCarreteras>();

        contadorNumerosGO = GameObject.Find("ContadorNumeros");
        contadorNumerosComp = contadorNumerosGO.GetComponent<SpriteRenderer>();

        controladorCocheGO = GameObject.Find("ControladorCoche");
        cocheGO = GameObject.Find("Coche");

        InicioCuentaAtras();
    }
    
    void InicioCuentaAtras()
    {
        StartCoroutine(Contando());
    }

    IEnumerator Contando()
    {
        controladorCocheGO.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(2);

        contadorNumerosComp.sprite = numeros[1];
        this.gameObject.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(1);

        contadorNumerosComp.sprite = numeros[2];
        this.gameObject.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(1);

        contadorNumerosComp.sprite = numeros[3];
        motorCarreterasScript.inicioJuego = true;
        contadorNumerosGO.GetComponent<AudioSource>().Play();
        cocheGO.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(2);

        contadorNumerosGO.SetActive(false);
    }
}
