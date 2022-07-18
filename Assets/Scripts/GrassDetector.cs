using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassDetector : MonoBehaviour
{

    public GameObject motorCalleGO;
    public MotorCarreteras motorCalleScript;

    public GameObject controladorCocheGO;
    public ControladorCoche controladorCocheScript;


    // Start is called before the first frame update
    void Start()
    {
        motorCalleGO = GameObject.FindObjectOfType<MotorCarreteras>().gameObject;
        motorCalleScript = motorCalleGO.GetComponent<MotorCarreteras>();

        controladorCocheGO = GameObject.FindObjectOfType<ControladorCoche>().gameObject;
        controladorCocheScript = controladorCocheGO.GetComponent<ControladorCoche>();
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.GetComponent<Coche>() != null)
        {
            motorCalleScript.velocidad = 10;
            controladorCocheScript.velocidad = 5;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.GetComponent<Coche>() != null)
        {
            motorCalleScript.velocidad = 15;
            controladorCocheScript.velocidad = 15;
        }
    }
}
