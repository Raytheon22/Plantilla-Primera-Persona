using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    //!Este script se encarga de realizar el movimiento del personaje y modificar su horientacion. 
    private CharacterController Jugador;
    private float VelocidadY;
    [SerializeField] float Aceleracion;
    [SerializeField] bool HabilidadDeSaltar;
    [SerializeField] float FuerzaDeSalto;
    private bool Saltando;
    void Start()
    {
        Jugador = GetComponent<CharacterController>();
    }
    void Update()
    {
        Rotacion();
        Translacion();
        if (HabilidadDeSaltar && Saltando == false)
        {
            Salto();
        }
        Gravedad();
    }
    private void Translacion()
    {
        float Horizontal;
        float Vertical;
        Horizontal = Input.GetAxis("Horizontal");
        Vertical = Input.GetAxis("Vertical");
        //*HACIA ADELANTE.
        Jugador.Move(transform.forward * Vertical * Aceleracion * Time.deltaTime);
        //*HACIA LOS COSTADOS.
        Jugador.Move(transform.right * Horizontal * Aceleracion * Time.deltaTime);

    }
    private void Rotacion()
    {
        //*MOVIMIENTO HORIZONTAL DE CAMARA
        transform.Rotate(0, Input.GetAxis("Mouse X") * ManagerConfiguraciones.Sensibilidad * Time.deltaTime, 0); //!falta singleton de sensibilidad
    }
    private void Salto()
    {
        //*CAMBIO DE SENTIDO DE VELOCIDAD Y ACELERACION.
        if (Input.GetKeyDown(KeyCode.Space))
        {
            VelocidadY = FuerzaDeSalto * 2;
            Saltando = true;
        }
        //*EL JUGADOR ESTA CAYENDO?
        if (VelocidadY < -1)
        {
            Saltando = true;
        }
    }
    private void Gravedad()
    {
        //*MRUV CAIDA LIBRE
        VelocidadY = VelocidadY + Physics.gravity.y * Time.deltaTime;
        Jugador.Move(new Vector3(0, VelocidadY, 0) * Time.deltaTime);
        //Debug.Log("Velocidad final: " + VelocidadY); //! CONTROL

        //*EL JUGADOR ESTA EN EL SUELO?
        if (Jugador.isGrounded)
        {
            VelocidadY = 0;
            Saltando = false;
        }
    }
}
