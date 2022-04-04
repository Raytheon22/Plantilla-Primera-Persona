using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara : MonoBehaviour
{
    //!Este script se encarga de realizar la rotacion de la camara.
    public float sensibilidad; //falta manager de sensibilidad
    private float AceleracionY;
    void Start()
    {
        sensibilidad = 100; //? provisorio hasta tener manager singleton.
    }

    void Update()
    {
        //* ROTACION VERTICAL DE LA CAMARA.
        AceleracionY += -Input.GetAxis("Mouse Y") * sensibilidad * Time.deltaTime;
        AceleracionY = Mathf.Clamp(AceleracionY, -90, 90);
        transform.localRotation = Quaternion.Euler(AceleracionY, 0, 0f);
    }
}
