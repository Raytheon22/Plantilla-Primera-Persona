using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lanzamiento : MonoBehaviour
{
    // Start is called before the first frame update+
    public GameObject chancla;
    public GameObject ObjetoInstanciado;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            ObjetoInstanciado = Instantiate(chancla, this.gameObject.transform.position, Random.rotation);
            ObjetoInstanciado.GetComponent<Rigidbody>().AddForce(this.gameObject.transform.forward * 2000, ForceMode.Acceleration);

        }
    }
}
