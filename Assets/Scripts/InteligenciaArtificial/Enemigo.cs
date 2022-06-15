using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class Enemigo : Inteligencia_Artificial, IDañable
{
    //todo: Clase que representa todos los enemigos.
    //! Para que este script funcione el gameobject principal, debe tener un navmesh agent y un trigger de tipo esfera.
    [SerializeField] int Vida;
    [Tooltip("En el caso de el enemigo patrulle se deben colocar los waypoints correspondientes en la lista")]
    [SerializeField] bool EstaPatrullando;
    [SerializeField] List<Transform> Waypoints;
    private int Waypoint;
    private float TiempoEnPunto = 5;  //* Cambiar si se quiere mas tiempo en cada punto.
    protected NavMeshAgent MovimientoPersonaje;


    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();

        if (EncontroObjetivo)
        {
            EstaPatrullando = false;
            MovimientoPersonaje.speed = 10;
            IrAlObjetivo(ObjetivoPrincipal.transform);
        }
        else if (EstaPatrullando)
        {
            Patrullar();
        }
    }




    protected override void InicializarIA()
    {
        base.InicializarIA();
        MovimientoPersonaje = GetComponent<NavMeshAgent>();
        if (EstaPatrullando)
        {
            IrAlObjetivo(Waypoints[Waypoint].transform);
        }


    }
    protected virtual void IrAlObjetivo(Transform Destino)
    {
        MovimientoPersonaje.destination = Destino.position;
    }
    protected void Patrullar()
    {
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
        EncontroObjetivo = true;
        Vida = Vida - Cantidad;
    }

}
