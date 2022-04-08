using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Interfaz : MonoBehaviour
{
    //!Este script se encarga de realizar las operaciones de la interfaz.

    public GameObject UIOpciones;
    void Start()
    {
        Cursor.visible = true;
    }
    public void CargarNivel(string NombreDeNivel)
    {
        Cursor.visible = false;
        SceneManager.LoadScene(NombreDeNivel);

    }
    public void Opciones()
    {
        Instantiate(UIOpciones, Vector3.zero, Quaternion.identity);
    }
    public void Salir()
    {
        Application.Quit();
    }
    public void Atras()
    {
        Destroy(this.gameObject);
    }
}
