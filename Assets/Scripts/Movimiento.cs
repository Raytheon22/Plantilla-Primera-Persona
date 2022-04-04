using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    //!Este script se encarga de realizar el movimiento del personaje y modificar su horientacion. 
    private CharacterController Jugador;
    private float Horizontal;
    private float Vertical;
    [SerializeField] float Aceleracion;
    [SerializeField] float FuerzaDeSalto;
    [SerializeField] float TiempoDeVuelo;
    [SerializeField] float AlturaDeSalto;
    private bool Saltando;

    void Start()
    {
        Jugador = GetComponent<CharacterController>();
    }

    void Update()
    {
        Horizontal = Input.GetAxis("Horizontal");
        Vertical = Input.GetAxis("Vertical");
        Rotacion();
        Translacion();
        Salto();
    }

    private void Translacion()
    {
        //*HACIA ADELANTE.
        Jugador.Move(transform.forward * Vertical * Aceleracion * Time.deltaTime);

        //*HACIA LOS COSTADOS.
        Jugador.Move(transform.right * Horizontal * Aceleracion * Time.deltaTime);
    }
    private void Rotacion()
    {
        //*MOVIMIENTO HORIZONTAL DE CAMARA
        transform.Rotate(0, Input.GetAxis("Mouse X") * 100 * Time.deltaTime, 0); //!falta singleton de sensibilidad
    }
    private void Salto()
    {
        //*SALTO
        Jugador.Move(transform.up * AlturaDeSalto * Time.deltaTime);

        //*GRAVEDAD
        Jugador.Move(Physics.gravity * Time.deltaTime);

        //*FISICA SIMULADA DEL SALTO.
        //!FALTA PROBAR BIEN.
        if (Jugador.isGrounded)
        {
            Saltando = false;
            AlturaDeSalto = 0;
        }
        if (Jugador.isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            AlturaDeSalto = FuerzaDeSalto;
            Saltando = true;
        }
        if (Saltando)
        {
            AlturaDeSalto = AlturaDeSalto - TiempoDeVuelo * Time.deltaTime;
        }
    }
}
