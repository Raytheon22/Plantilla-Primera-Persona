using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Opciones : MonoBehaviour
{
    //! Este script se encarga de administrar la pantalla de opciones del juego.

    [SerializeField] Slider Sensibilidad;
    [SerializeField] Slider VolumenMusica;
    [SerializeField] Slider VolumenEfecto;

    void Awake()
    {
        Sensibilidad.value = ManagerConfiguraciones.Sensibilidad;
        VolumenMusica.value = ManagerConfiguraciones.VolumenMusica;
        VolumenEfecto.value = ManagerConfiguraciones.VolumenEfectos;
    }

    void Update()
    {
        if (Sensibilidad.value != ManagerConfiguraciones.Sensibilidad)
        {
            ManagerConfiguraciones.Sensibilidad = (int)Sensibilidad.value;
        }
        if (VolumenMusica.value != ManagerConfiguraciones.VolumenMusica)
        {
            ManagerConfiguraciones.VolumenMusica = (int)VolumenMusica.value;
        }
        if (VolumenMusica.value != ManagerConfiguraciones.VolumenEfectos)
        {
            ManagerConfiguraciones.VolumenEfectos = (int)VolumenEfecto.value;
        }
    }

}
