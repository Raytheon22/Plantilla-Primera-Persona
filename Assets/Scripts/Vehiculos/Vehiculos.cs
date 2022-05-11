using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehiculos : MonoBehaviour
{
    [SerializeField] WheelCollider RuedaDerechaDelantera;
    [SerializeField] WheelCollider RuedaIzquierdaDelantera;
    [SerializeField] WheelCollider RuedaDerechaTrasera;
    [SerializeField] WheelCollider RuedaIzquierdaTrasera;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            Debug.Log("Moviendose");
            RuedaDerechaTrasera.motorTorque = 1500;
            RuedaIzquierdaTrasera.motorTorque = 1500;
        }
    }
}
