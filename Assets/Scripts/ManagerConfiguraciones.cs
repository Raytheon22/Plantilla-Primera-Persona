using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ManagerConfiguraciones : MonoBehaviour
{
    //! Este script se encarga de administrar las configuraciones del juego.
    private static ManagerConfiguraciones ConfiguracionesJuego;
    public static int VolumenMusica = 40;
    public static int VolumenEfectos = 70;
    public static int Sensibilidad = 100;
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
    void Update()
    {

    }

}
