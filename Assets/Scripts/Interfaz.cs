using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Interfaz : MonoBehaviour
{
    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void CargarNivel(string NombreDeNivel)
    {
        SceneManager.LoadScene(NombreDeNivel);
    }
    public void Opciones()
    {
        Debug.Log("Opciones");
    }
    public void Salir()
    {
        Application.Quit();
    }
}
