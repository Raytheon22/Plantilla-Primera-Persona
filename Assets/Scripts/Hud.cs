using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hud : MonoBehaviour
{
    //! Este script se encarga de manipular el HUD.
    public GameObject UIPausa;
    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Instantiate(UIPausa, Vector3.zero, Quaternion.identity);
        }
    }
}
