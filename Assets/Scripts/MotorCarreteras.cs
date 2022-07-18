using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotorCarreteras : MonoBehaviour
{

    public GameObject contenedorCallesGO;
    public GameObject[] contenedorCallesArray;

    public float velocidad;
    public bool inicioJuego;
    public bool juegoTerminado;

    private int contadorCalles = 0;
    private int numeroSelectorCalles = 0;

    public GameObject calleAnterior;
    public GameObject calleNueva;

    public float tamañoCalle;

    public Vector3 medidaLimitePantalla;
    public bool salioDePantalla;

    public GameObject myCamGo;
    public Camera myCamComp;

    public GameObject cocheGO;
    public GameObject audioFX;
    public AudioFX audioFXScript;
    public GameObject bgFinalGO;



    void Start()
    {
        contenedorCallesGO = GameObject.Find("ContenedorCalles");
        myCamGo = GameObject.Find("Main Camera");
        myCamComp = myCamGo.GetComponent<Camera>();

        bgFinalGO = GameObject.Find("PanelGameOver");
        bgFinalGO.SetActive(false);

        audioFX = GameObject.Find("AudioFX");
        audioFXScript = audioFX.GetComponent<AudioFX>();

        cocheGO = GameObject.FindObjectOfType<Coche>().gameObject;

        BuscoCalles();
        MedirPantalla();
        IniciarJuego();
    }

    void IniciarJuego()
    {
        VelocidadMotorCarretera();
    }

    void VelocidadMotorCarretera()
    {
        velocidad = 15;
    }

    void BuscoCalles()
    {
        contenedorCallesArray = GameObject.FindGameObjectsWithTag("Calle");
        for(int i=0; i< contenedorCallesArray.Length; i++)
        {
            contenedorCallesArray[i].gameObject.transform.parent = contenedorCallesGO.transform;
            contenedorCallesArray[i].gameObject.SetActive(false);
            contenedorCallesArray[i].gameObject.name = "CalleOFF_" + i;
        }

        CrearCalles();
    }

    void CrearCalles()
    {
        contadorCalles ++;
        numeroSelectorCalles = Random.Range(0, contenedorCallesArray.Length);

        GameObject Calle = Instantiate(contenedorCallesArray[numeroSelectorCalles]);
        Calle.SetActive(true);
        Calle.name = "Calle"+contadorCalles;
        Calle.transform.parent = gameObject.transform;

        PosicionoCalle();

    }

    void PosicionoCalle()
    {
        calleAnterior = GameObject.Find("Calle" + (contadorCalles - 1));
        calleNueva = GameObject.Find("Calle" + contadorCalles);
        MidoCalle();
        calleNueva.transform.position = new Vector3(calleAnterior.transform.position.x, calleAnterior.transform.position.y + tamañoCalle, 0);
        salioDePantalla = false;
    }

    void MidoCalle()
    {
        for(int i=0; i< calleAnterior.transform.childCount; i++)
        {
            if(calleAnterior.transform.GetChild(i).gameObject.GetComponent<Piezas>() != null)
            {
                float tamañoPieza = calleAnterior.transform.GetChild(i).gameObject.GetComponent<SpriteRenderer>().bounds.size.y;
                tamañoCalle += tamañoPieza; 
            }

            
        }
    }

    void MedirPantalla()
    {
        medidaLimitePantalla = new Vector3(0, myCamComp.ScreenToWorldPoint(new Vector3(0,0,0)).y - 0.5f, 0);
    }
    
    void Update()
    {
        if (inicioJuego && !juegoTerminado)
        {
            transform.Translate(Vector3.down * velocidad * Time.deltaTime);
            
             if (calleAnterior.transform.position.y + tamañoCalle < medidaLimitePantalla.y && !salioDePantalla)
            {
                salioDePantalla = true;
                DestruyoCalles();
            }
        }
       
    }

    void DestruyoCalles()
    {
        Destroy(calleAnterior);
        tamañoCalle = 0;
        calleAnterior = null;
        CrearCalles();
    }


    public void JuegoterminadoEstados()
    {
        cocheGO.GetComponent<AudioSource>().Stop();
        audioFXScript.FXMusic();
        bgFinalGO.SetActive(true);
    }
}
