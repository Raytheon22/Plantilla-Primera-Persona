using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ManagerConfiguraciones : MonoBehaviour
{
    //! Este script se encarga de administrar las configuraciones del juego.

    private static ManagerConfiguraciones ConfiguracionesJuego;
    public static int VolumenMusica = 100;
    public static int VolumenEfectos = 80;
    public static int Sensibilidad = 80;
    void Awake() //* DECLARACION DEL SINGLETON
    {
        if (ConfiguracionesJuego == null)
        {
            ConfiguracionesJuego = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this);
        }

    }
    void Start()
    {
        Sensibilidad = 100;
        VolumenEfectos = 80;
        VolumenMusica = 80;
    }

}
