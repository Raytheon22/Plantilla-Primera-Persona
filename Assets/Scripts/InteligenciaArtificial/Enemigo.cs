using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/*
Esteban Pablo Perez 2022.
*/

public abstract class Enemigo : Inteligencia_Artificial, IDañable
{
    //todo: Clase que representa todos los enemigos.
    //! Para que este script funcione el gameobject principal, debe tener un navmesh agent y un trigger de tipo esfera.
    [SerializeField] int Vida;
    [SerializeField] int Velocidad;
    [SerializeField] int AlturaMaxDeSalto;
    [Tooltip("En el caso de el enemigo patrulle se deben colocar los waypoints correspondientes en la lista")]
    [SerializeField] bool EstaPatrullando;
    [SerializeField] List<Transform> Waypoints;
    private int Waypoint;
    private float TiempoEnPunto = 5;  //* Cambiar si se quiere mas tiempo en cada punto.
    protected NavMeshAgent MovimientoPersonaje;
    protected Rigidbody Fisicas;
    private bool AccionesEjecutadas;
    protected bool Salto;
    private float ColdownDeSalto = 2;


    //* Flujo Principal
    protected override void Start()
    {
        base.Start();
        MovimientoPersonaje.speed = Velocidad;
    }
    protected override void FixedUpdate()
    {
        base.FixedUpdate();
    }


    //* Estados de la AI.
    protected override void Pasivo()
    {
        base.Pasivo();
        if (EstaPatrullando)
        {
            Patrullar();
        }
    }
    protected override void Alerta()
    {
        if (!Saltando())
        {
            IrAlObjetivo(ObjetivoPrincipal.transform);
        }
        base.Alerta();
    }
    protected override void Hostil()
    {
        base.Hostil();
        if (Apuntar(CercaniaParaAccion))
        {
            MovimientoPersonaje.speed = Velocidad / 5;
            MovimientoPersonaje.angularSpeed = 0;
            if (!AccionesEjecutadas)
            {
                Acciones();
            }
        }
        else
        {
            if (!Saltando())
            {
                MovimientoPersonaje.speed = Velocidad * 5;
                MovimientoPersonaje.angularSpeed = 360;
                IrAlObjetivo(ObjetivoPrincipal.transform);
            }
        }

    }
    //*Comportamiento de la AI.
    protected override void Acciones()
    {
        base.Acciones();
        AccionesEjecutadas = true;
    }

    protected void Atacar()
    {
        Debug.Log("Atacar");
    }
    protected void Saltar()
    {
        MovimientoPersonaje.enabled = false;
        Fisicas.isKinematic = false;
        //* Tiro parabolico
        Vector3 PosicionDeJugador = ObjetivoPrincipal.transform.position - transform.position;
        float FuerzaX;
        float FuerzaY;
        float FuerzaZ;
        FuerzaY = Mathf.Sqrt(-2 * Physics.gravity.y * AlturaMaxDeSalto);
        FuerzaX = PosicionDeJugador.x / ((-FuerzaY / Physics.gravity.y) + Mathf.Sqrt(2 * (PosicionDeJugador.y - AlturaMaxDeSalto) / Physics.gravity.y));
        FuerzaZ = PosicionDeJugador.z / ((-FuerzaY / Physics.gravity.y) + Mathf.Sqrt(2 * (PosicionDeJugador.y - AlturaMaxDeSalto) / Physics.gravity.y));

        Fisicas.velocity = Fisicas.velocity + new Vector3(FuerzaX * 1.7f, FuerzaY, FuerzaZ);
        Invoke("IniciarSalto", 0.5f);
    }

    //* Herramientas de la IA.
    protected override void InicializarIA()
    {
        base.InicializarIA();
        MovimientoPersonaje = GetComponent<NavMeshAgent>();
        if (GetComponent<Rigidbody>() != null)
        {
            Fisicas = GetComponent<Rigidbody>();
            Fisicas.isKinematic = true;
        }
    }
    protected virtual void IrAlObjetivo(Transform Destino)
    {
        MovimientoPersonaje.destination = Destino.position;
    }
    protected void Patrullar()
    {
        IrAlObjetivo(Waypoints[Waypoint].transform);
        if ((Vector3.Distance(transform.position, MovimientoPersonaje.destination) <= 1f))
        {
            TiempoEnPunto = TiempoEnPunto - 1 * Time.deltaTime;
            if (TiempoEnPunto <= 0)
            {
                if (Waypoint + 1 < Waypoints.Count)
                {
                    Waypoint++;
                }
                else
                {
                    Waypoints.Reverse();
                    Waypoint = 1;
                }
                IrAlObjetivo(Waypoints[Waypoint].transform);
                TiempoEnPunto = 5;
            }
        }
    }
    public virtual void RecibirDaño(int Cantidad)
    {
        // EncontroObjetivo = true;
        Vida = Vida - Cantidad;
    }
    protected void IniciarSalto()
    {
        Salto = true;
    }
    protected bool Saltando()
    {
        RaycastHit Suelo;
        if (Physics.Raycast(transform.position, -transform.up, out Suelo, 1.1f))
        {
            if (Suelo.transform.tag == "Escenario" && Salto)
            {
                MovimientoPersonaje.enabled = true;
                Fisicas.isKinematic = true;
                IrAlObjetivo(ObjetivoPrincipal.transform);
                Salto = false;
            }
            return false;
        }
        else
        {
            return true;
        }
    }

}


