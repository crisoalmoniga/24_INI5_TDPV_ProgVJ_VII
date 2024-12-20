using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Herir : MonoBehaviour
{
    // Variables a configurar desde el editor
    [Header("Configuracion")]
    [SerializeField] int puntos = 1;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Jugador jugador = collision.gameObject.GetComponent<Jugador>();

            // Validaci�n para asegurar que el componente Jugador no es null
            if (jugador != null)
            {
                jugador.ModificarVida(-puntos);
                Debug.Log("PUNTOS DE DA�O REALIZADOS AL JUGADOR: " + puntos);

                // Opcional: Desactiva el objeto despu�s de aplicar el da�o
                gameObject.SetActive(false);
            }
            else
            {
                Debug.LogError("No se encontr� el componente Jugador en el objeto de colisi�n.");
            }
        }
    }
}
