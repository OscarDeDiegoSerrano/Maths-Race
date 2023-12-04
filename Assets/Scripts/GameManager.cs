using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject player1;
    public GameObject TextGameOver;
    public GameObject Titol;
    public GameObject BotoInici;
    public GameObject BotoStory;
    public GameObject BotoControls;
    public GameObject BotoRanking;
    public GameObject BotoNext;
    public GameObject generadorRespostes;
    public GameObject generadorOperacions;
    public GameObject BotoTornarInici;
    public GameObject IMGcontroles;
    public GameObject IMGstory1, IMGstory2, IMGstory3;
    public GameObject IMGrespuesta;
    public GameObject IMGoperacion;

    public enum EstatsGameManager
    {
        Inici,
        PantallaStory,
        PantallaStory2,
        PantallaStory3,
        PantallaControls,
        PantallaRanking,
        Jugant,
        GameOver
    }

    public EstatsGameManager _estatGameManager;

    // Start is called before the first frame update
    void Start()
    {
        _estatGameManager = EstatsGameManager.Inici;
        ActualitzaEstatGameManager();
    }

    // Update is called once per frame
    void Update()
    {
        // Puedes agregar lógica de actualización aquí si es necesario
    }

    private void ActualitzaEstatGameManager()
    {
        switch (_estatGameManager)
        {
            case EstatsGameManager.Inici:
                player1.SetActive(false);
                Titol.SetActive(true);
                TextGameOver.SetActive(false);
                BotoInici.SetActive(true);
                BotoStory.SetActive(true);
                BotoControls.SetActive(true);
                BotoRanking.SetActive(true);
                BotoTornarInici.SetActive(false);
                BotoNext.SetActive(false);
                IMGcontroles.SetActive(false);
                IMGstory1.SetActive(false);
                IMGstory2.SetActive(false);
                IMGstory3.SetActive(false);
                generadorRespostes.GetComponent<GeneradorRespuestas>().PosarIniciFalse(); // Corregir el nombre del método
                generadorOperacions.GetComponent<GeneradorOperacions>().PosarIniciarFalse(); // Corregir el nombre del método
                GameObject.Find("GeneradorOperacions").GetComponent<GeneradorOperacions>().AturarGeneracioOperacions();
                break;

            case EstatsGameManager.Jugant:
                GameObject.Find("GeneradorOperacions").GetComponent<GeneradorOperacions>().IniciGeneracioOperacions();

                player1.SetActive(true);
                Titol.SetActive(false);
                TextGameOver.SetActive(false);
                BotoInici.SetActive(false);
                BotoStory.SetActive(false);
                BotoControls.SetActive(false);
                BotoRanking.SetActive(false);
                BotoTornarInici.SetActive(true); // Para pruebas
                BotoNext.SetActive(false);
                IMGcontroles.SetActive(false);
                IMGstory1.SetActive(false);
                IMGstory2.SetActive(false);
                IMGstory3.SetActive(false);
                break;

            case EstatsGameManager.PantallaStory:
                player1.SetActive(false);
                Titol.SetActive(false);
                TextGameOver.SetActive(false);
                BotoInici.SetActive(false);
                BotoStory.SetActive(false);
                BotoControls.SetActive(false);
                BotoRanking.SetActive(false);
                BotoNext.SetActive(true);
                IMGcontroles.SetActive(false);
                BotoTornarInici.SetActive(false);
                IMGstory1.SetActive(true);
                IMGstory2.SetActive(false);
                IMGstory3.SetActive(false);
                break;

            case EstatsGameManager.PantallaStory2:
                player1.SetActive(false);
                Titol.SetActive(false);
                TextGameOver.SetActive(false);
                BotoInici.SetActive(false);
                BotoStory.SetActive(false);
                BotoControls.SetActive(false);
                BotoRanking.SetActive(false);
                BotoNext.SetActive(true);
                IMGcontroles.SetActive(false);
                BotoTornarInici.SetActive(false);
                IMGstory1.SetActive(false);
                IMGstory2.SetActive(true);
                IMGstory3.SetActive(false);
                break;

            case EstatsGameManager.PantallaStory3:
                player1.SetActive(false);
                Titol.SetActive(false);
                TextGameOver.SetActive(false);
                BotoInici.SetActive(false);
                BotoStory.SetActive(false);
                BotoControls.SetActive(false);
                BotoRanking.SetActive(false);
                BotoNext.SetActive(false);
                IMGcontroles.SetActive(false);
                BotoTornarInici.SetActive(true);
                IMGstory1.SetActive(false);
                IMGstory2.SetActive(false);
                IMGstory3.SetActive(true);
                break;

            case EstatsGameManager.PantallaControls:
                player1.SetActive(false);
                Titol.SetActive(true);
                TextGameOver.SetActive(false);
                BotoInici.SetActive(false);
                BotoStory.SetActive(false);
                BotoControls.SetActive(false);
                BotoRanking.SetActive(false);
                BotoNext.SetActive(false);
                IMGcontroles.SetActive(true);
                BotoTornarInici.SetActive(true);
                IMGstory1.SetActive(false);
                IMGstory2.SetActive(false);
                IMGstory3.SetActive(false);
                break;
        }
    }

    public void PassarAEstatInici()
    {
        _estatGameManager = EstatsGameManager.Inici;
        ActualitzaEstatGameManager();
    }

    public void PassarAPantallaStory()
    {
        if (_estatGameManager == EstatsGameManager.PantallaStory)
        {
            _estatGameManager = EstatsGameManager.PantallaStory2;
        }
        else if (_estatGameManager == EstatsGameManager.PantallaStory2)
        {
            _estatGameManager = EstatsGameManager.PantallaStory3;
        }
        else
        {
            _estatGameManager = EstatsGameManager.PantallaStory;
        }

        ActualitzaEstatGameManager();
    }

    public void PassarAEstatControls()
    {
        _estatGameManager = EstatsGameManager.PantallaControls;
        ActualitzaEstatGameManager();
    }

    public void PassarAEstatJugant()
    {
        _estatGameManager = EstatsGameManager.Jugant;
        generadorRespostes.GetComponent<GeneradorRespuestas>().PosarIniciFalse(); // Corregir el nombre del método
        generadorOperacions.GetComponent<GeneradorOperacions>().PosarIniciarFalse(); // Corregir el nombre del método

        ActualitzaEstatGameManager();
    }

    public void PassarAEstatGameOver()
    {
        _estatGameManager = EstatsGameManager.GameOver;
        ActualitzaEstatGameManager();
    }

}
