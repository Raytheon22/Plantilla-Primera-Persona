using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManejoDeInstancias : MonoBehaviour
{

    void Update()
    {
        Invoke("Destruir", 10);
    }
    void Destruir()
    {
        Destroy(gameObject);
    }

}
