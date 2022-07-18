using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorCoche : MonoBehaviour
{
    public GameObject MotorCalles;
    public MotorCarreteras MotorCallesScript;

    public  GameObject cocheGO;

    public float anguloDeGiro;
    public float velocidad;

    // Start is called before the first frame update
    void Start()
    {
        MotorCalles = GameObject.FindObjectOfType<MotorCarreteras>().gameObject;
        MotorCallesScript = MotorCalles.GetComponent<MotorCarreteras>();

        cocheGO = GameObject.FindObjectOfType<Coche>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {

        if(MotorCallesScript.inicioJuego)
        {
            float giroEnZ = 0;

            transform.Translate(Vector2.right * Input.GetAxis("Horizontal") * velocidad * Time.deltaTime);

            giroEnZ = Input.GetAxis("Horizontal") * -anguloDeGiro;

            cocheGO.transform.rotation = Quaternion.Euler(0,0, giroEnZ);
        }
        
    }
}
