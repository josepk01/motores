using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField]
    private Text bestTimeText;
    [SerializeField]// Referencia al texto donde se mostrar� el tiempo m�nimo.
    private Button playButton; // Referencia al bot�n de "Jugar".

    //private bool updatedTime = false;

    private string bestTime = " "; // Variable para almacenar el tiempo m�nimo. -1 significa que no hay un tiempo a�n.

    void Start()
    {
        SetBestTime();
        // A�adir listener al bot�n para cargar la escena de juego
        playButton.onClick.AddListener(Jugar);
    }
    private void Update()
    {
        //if (!updatedTime)
        //{
        //    SetBestTime();
        //}
    }

    public void Jugar()
    {
        // Cargar la escena del juego
        GameManager.Instance.ResumeTimer();
        SceneManager.LoadScene("Juego");
    }

    // M�todo para actualizar el mejor tiempo cuando se gana una partida
    public void GetBestTime()
    {
        Debug.Log("primero");
        bestTime =GameManager.Instance.GetBestTime();
    }

    public void SetBestTime()
    {
        GetBestTime();
        // Si existe el mejor tiempo, actualizar el texto
        if (bestTime != " ")
        {
            bestTimeText.text = "Mejor tiempo: " + bestTime;
        }
        else
        {
            bestTimeText.text = "No se ha ganado ninguna partida.";
        }
        //updatedTime = true;
    }
}
