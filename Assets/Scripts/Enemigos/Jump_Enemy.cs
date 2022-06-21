using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/*
Esteban Pablo Perez 2022.
*/

public class Jump_Enemy : Enemigo
{
    bool ejecutado;
    protected override void FixedUpdate()
    {
        base.FixedUpdate();
    }
    protected override void Hostil()
    {
        base.Hostil();
        if (Apuntar(20) && !ejecutado && DistanciaConObjetivo() > 10)
        {
            Saltar();
            ejecutado = true;
        }
        if (DistanciaConObjetivo() < 5)
        {
            ejecutado = false;
        }
    }
    protected override void Acciones()
    {
        base.Acciones();
        Atacar();
    }

}



