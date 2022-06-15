using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Inteligencia_Artificial : MonoBehaviour
{
    //todo: Clase ABSTRACTA maestra.
    protected GameObject ObjetivoPrincipal;
    protected bool EncontroObjetivo;
    [Header("Propiedades del enemigo:")]
    [SerializeField] private int RadioDeDeteccion;

    //* Flujo principal.
    protected virtual void Start()
    {
        InicializarIA();
    }

    protected virtual void Update()
    {
    }


    protected virtual void InicializarIA()
    {
        GetComponent<SphereCollider>().radius = RadioDeDeteccion;
    }
    protected virtual void OnTriggerEnter(Collider ObjetoDetectado)  //* Deteccion y filtrado de objetivos que cumplan con las condiciones.
    {
        if (ObjetoDetectado.tag == "Player")
        {
            EncontroObjetivo = true;
            ObjetivoPrincipal = ObjetoDetectado.transform.root.gameObject;
        }
    }
}
