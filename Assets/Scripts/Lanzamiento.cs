using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lanzamiento : MonoBehaviour
{
    //! Este script se encarga de administrar el lanzamiento de objetos.
    public GameObject chancla;
    public GameObject ObjetoInstanciado;
    void Start()
    {

    }


    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            ObjetoInstanciado = Instantiate(chancla, this.gameObject.transform.position, Random.rotation);
            ObjetoInstanciado.GetComponent<Rigidbody>().AddForce(this.gameObject.transform.forward * 2000, ForceMode.Acceleration);

        }
    }
}
