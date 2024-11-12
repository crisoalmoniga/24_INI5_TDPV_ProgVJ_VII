using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUDController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI miTexto;

    [SerializeField] GameObject iconoVida;
    [SerializeField] GameObject contenedorIconosVida;

    public void ActualizarTextoHUD(string nuevoTexto)
    {
        Debug.Log("SE LLAMA " + nuevoTexto);
        miTexto.text = nuevoTexto;
    }

    public void ActualizarVidasHUD(int vidas)
    {
        Debug.Log("Llamada a ActualizarVidasHUD con " + vidas + " vidas.");
        if (EstaVacioContenedor())
        {
            CargarContenedor(vidas);
            Debug.Log("Cantidad de iconos tras cargar: " + CantidadIconosVidas());
            return;
        }

        if (CantidadIconosVidas() > vidas)
        {
            EliminarUltimoIcono();
        }
        else
        {
            CrearIcono();
        }
        Debug.Log("Cantidad de iconos tras actualizaci�n: " + CantidadIconosVidas());
    }

    private bool EstaVacioContenedor()
    {
        return contenedorIconosVida.transform.childCount == 0;
    }

    private int CantidadIconosVidas()
    {
        return contenedorIconosVida.transform.childCount;
    }

    private void EliminarUltimoIcono()
    {
        Transform contenedor = contenedorIconosVida.transform;
        GameObject.Destroy(contenedor.GetChild(contenedor.childCount - 1).gameObject);
    }

    private void CargarContenedor(int cantidadIconos)
    {
        for (int i = 0; i < cantidadIconos; i++)
        {
            CrearIcono();
        }
    }

    private void CrearIcono()
    {
        Debug.Log("Instanciando un nuevo icono de vida");
        Instantiate(iconoVida, contenedorIconosVida.transform);    
    }
}

