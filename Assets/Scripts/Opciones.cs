using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Opciones : MonoBehaviour
{

    void Start()
    {

    }
    void Update()
    {
        Debug.Log(ManagerConfiguraciones.Sensibilidad);
    }
    public void CambiarSensibilidad(float Numero)
    {
        ManagerConfiguraciones.Sensibilidad = (int)Numero;
    }
    public void CambiarVolumenMusica(float Numero)
    {
        ManagerConfiguraciones.VolumenEfectos = (int)Numero;
    }
    public void CambiarVolumenEfectos(float Numero)
    {
        ManagerConfiguraciones.VolumenMusica = (int)Numero;
    }
}
