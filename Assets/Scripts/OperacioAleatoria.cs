using UnityEngine;

public class OperacioAleatoria : MonoBehaviour
{
    private int operant1, operant2, resultat;

    void Start()
    {
        // Generate random operation and correct answer
        GenerarOperacionAleatoria();
    }

    void GenerarOperacionAleatoria()
    {
        int escollirOperant = Random.Range(0, 2);
        operant1 = Random.Range(50, 100);
        operant2 = Random.Range(0, 50);

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
        Invoke("GenerarRespuestas", .1f);
    }

    public void GenerarRespuestas()
    {
        GameObject.Find("GeneradorRespostes").GetComponent<GeneradorRespuestas>().GenerarRespuestas();
    }

    public int ObtenerResultado()
    {
        return resultat;
    }
}
