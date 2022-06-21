using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
Esteban Pablo Perez 2022.
*/
public abstract class Inteligencia_Artificial : MonoBehaviour
{
    //todo: Clase ABSTRACTA maestra.
    public Image SimboloSuperior;
    protected GameObject ObjetivoPrincipal;
    protected bool ObjetivoDetectado;
    [Header("Propiedades del enemigo:")]
    protected int Estado;
    [SerializeField] protected int RangoDeDeteccion;
    [SerializeField] protected int AnguloDeDeteccion;
    [SerializeField] protected int CercaniaParaAccion;
    private float TiempoDeDeteccion;

    //* Flujo principal.
    protected virtual void Start()
    {
        InicializarIA();
    }
    protected virtual void FixedUpdate()
    {
        ActualizarUI();
        switch (Estado)
        {
            case 0:
                {
                    Pasivo();
                    break;
                }
            case 1:
                {
                    Alerta();
                    break;
                }
            case 2:
                {
                    Hostil();
                    break;
                }
        }
    }


    //* Estados de la AI.
    protected virtual void Pasivo()
    {
        Estado = 0;
        if (ObjetivoPrincipal != null)
        {
            if (ConoDeVision())
            {
                Alerta();
            }
        }
    }
    protected virtual void Alerta()
    {
        Apuntar(CercaniaParaAccion);
        Estado = 1;
        if (ConoDeVision())
        {
            TiempoDeDeteccion = TiempoDeDeteccion + (6 / DistanciaConObjetivo() * Time.deltaTime);
            if (TiempoDeDeteccion >= 1)
            {
                TiempoDeDeteccion = 1;
                Hostil();
            }
        }
        else
        {
            TiempoDeDeteccion = TiempoDeDeteccion - 0.1f * Time.deltaTime;
            if (TiempoDeDeteccion <= 0)
            {
                TiempoDeDeteccion = 0;
                Pasivo();
            }
        }
    }
    protected virtual void Hostil()
    {
        Estado = 2;
        // Debug.Log("Hostil");
    }

    //* Comportamiento de la AI.
    protected virtual void Acciones()
    {

    }

    //* Herramientas de la IA.
    protected virtual void ActualizarUI()
    {
        SimboloSuperior.transform.parent.gameObject.transform.LookAt(Camera.main.transform);
        Image Simbolo = SimboloSuperior.GetComponent<Image>();
        Simbolo.fillAmount = TiempoDeDeteccion;
        if (Simbolo.fillAmount == 1)
        {
            SimboloSuperior.color = new Color(255, 0, 0, 255);
        }
    }
    protected virtual void InicializarIA()
    {
        GetComponent<SphereCollider>().radius = RangoDeDeteccion;
        TiempoDeDeteccion = 0;
    }
    protected virtual void OnTriggerEnter(Collider ObjetoDetectado)  //* Deteccion y filtrado de objetivos que cumplan con las condiciones.
    {
        if (ObjetoDetectado.tag == "Player")
        {
            ObjetivoPrincipal = ObjetoDetectado.transform.root.gameObject;
        }
    }
    protected virtual bool ConoDeVision()
    {
        Vector3 DireccionDeObjetivo = Vector3.Normalize(ObjetivoPrincipal.transform.position - transform.position);
        if ((Mathf.Rad2Deg * Mathf.Acos(Vector3.Dot(transform.forward.normalized, DireccionDeObjetivo))) < AnguloDeDeteccion)
        {
            RaycastHit ObjetoDetectado;
            if (Physics.Raycast(transform.position, DireccionDeObjetivo, out ObjetoDetectado))
            {
                if (ObjetoDetectado.transform.tag == "Player")
                {
                    ObjetivoDetectado = true;
                    return true;
                }
            }
        }
        return false;
    }
    protected virtual bool Apuntar(float Rango) //* Siempre mira al jugador
    {
        RaycastHit ObjetoDetectado;
        if (Physics.Raycast(transform.position, ObjetivoPrincipal.transform.position - transform.position, out ObjetoDetectado, Rango))
        {
            if (ObjetoDetectado.transform.tag == "Player")
            {
                var lookPos = ObjetivoPrincipal.transform.position - transform.transform.position;
                lookPos.y = 0;
                var rotation = Quaternion.LookRotation(lookPos);
                transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 25);
                return true;
            }
        }
        return false;
    }
    protected virtual float DistanciaConObjetivo()
    {
        float Distancia = 0;
        Distancia = Vector3.Distance(transform.position, ObjetivoPrincipal.transform.position);
        return Distancia;
    }
}


