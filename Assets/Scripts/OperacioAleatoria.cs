using UnityEngine;

public class OperacioAleatoria : MonoBehaviour
{
    private int operant1, operant2, resultat;

    public enum PosicioResposta
    {
        Esquerra,
        Centre,
        Dreta
    }

    private PosicioResposta _posicioResposta;

    void Start()
    {
        // Generate random operation and correct answer
        GenerarOperacionAleatoria();
    }

    void GenerarOperacionAleatoria()
    {
        int escollirOperant = Random.Range(0, 4);
        operant1 = Random.Range(0, 100);
        operant2 = Random.Range(0, 100);

        switch (escollirOperant)
        {
            case 0:
                resultat = operant1 + operant2;
                gameObject.GetComponent<TMPro.TextMeshPro>().text = "" + operant1 + " + " + operant2;
                break;

            case 1:
                resultat = operant1 - operant2;
                gameObject.GetComponent<TMPro.TextMeshPro>().text =  "" + operant1 + " - " + operant2;
                break;

            case 2:
                resultat = operant1 * operant2;
                gameObject.GetComponent<TMPro.TextMeshPro>().text = "" + operant1 + " * " + operant2;
                break;

            case 3:
                // Ensure operant2 is not zero for division
                operant2 = Mathf.Max(1, operant2);
                resultat = operant1 / operant2;
                gameObject.GetComponent<TMPro.TextMeshPro>().text = "" + operant1 + " / " + operant2;
                break;

            default:
                gameObject.GetComponent<TMPro.TextMeshPro>().text = "Opció no contemplada";
                break;
        }


        // Set the correct answer in GeneradorRespuestas
        FindObjectOfType<GeneradorRespuestas>().SetRespuestaCorrecta(resultat);
    }

    public int ObtenerResultado()
    {
        return resultat;
    }
}
