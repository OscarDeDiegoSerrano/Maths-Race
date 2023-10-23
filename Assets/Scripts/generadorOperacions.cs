using UnityEngine;

public class GeneradorOperacions : MonoBehaviour
{
    public GeneradorRespostes generadorRespostes; // Asigna el GameObject "GeneradorRespostes" en el Inspector.

    // Variables para la operación
    private int numero1;
    private int numero2;
    private char operador;
    private int resultadoCorrecto;

    // Genera una operación que concuerda con la respuesta correcta
    private void GenerarOperacionConRespuestaCorrecta()
    {
        // Obtén la respuesta correcta del GeneradorRespostes
        resultadoCorrecto = generadorRespostes.respuestaCorrecta;

        // Genera números y operador basados en la respuesta correcta
        // Por ejemplo, aquí podrías generar una suma.
        numero1 = Random.Range(1, resultadoCorrecto);
        numero2 = resultadoCorrecto - numero1;
        operador = '+';

        // Crea la operación y muestra en pantalla o realiza cualquier otra acción que necesites.
        string operacion = $"{numero1} {operador} {numero2} = ?";
        Debug.Log("Operación: " + operacion);
    }

    // Llamas a este método cuando quieras generar una operación que concuerde con la respuesta correcta.
    public void GenerarOperacion()
    {
        // Llama al método para generar la operación con la respuesta correcta
        GenerarOperacionConRespuestaCorrecta();
    }
}
