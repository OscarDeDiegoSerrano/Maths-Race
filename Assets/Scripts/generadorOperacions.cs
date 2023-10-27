using UnityEngine;

public class GeneradorOperacions : MonoBehaviour
{
    public GeneradorRespostes generadorRespostes; // Asigna el GameObject "GeneradorRespostes" en el Inspector.

    // Variables para la operaci�n
    private int numero1;
    private int numero2;
    private char operador;
    private int resultadoCorrecto;

    // Genera una operaci�n que concuerda con la respuesta correcta
    private void GenerarOperacionConRespuestaCorrecta()
    {
        // Obt�n la respuesta correcta del GeneradorRespostes
        resultadoCorrecto = generadorRespostes.respuestaCorrecta;

        // Genera n�meros y operador basados en la respuesta correcta
        // Por ejemplo, aqu� podr�as generar una suma.
        numero1 = Random.Range(1, resultadoCorrecto);
        numero2 = resultadoCorrecto - numero1;
        operador = '+';

        // Crea la operaci�n y muestra en pantalla o realiza cualquier otra acci�n que necesites.
        string operacion = $"{numero1} {operador} {numero2} = ?";
        Debug.Log("Operaci�n: " + operacion);
    }

    // Llamas a este m�todo cuando quieras generar una operaci�n que concuerde con la respuesta correcta.
    public void GenerarOperacion()
    {
        // Llama al m�todo para generar la operaci�n con la respuesta correcta
        GenerarOperacionConRespuestaCorrecta();
    }
}
