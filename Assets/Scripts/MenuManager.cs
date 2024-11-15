using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public Text bestTimeText; // Referencia al texto donde se mostrar� el tiempo m�nimo.
    public Button playButton; // Referencia al bot�n de "Jugar".

    private float bestTime = -1f; // Variable para almacenar el tiempo m�nimo. -1 significa que no hay un tiempo a�n.

    void Start()
    {
        // Si existe el mejor tiempo, actualizar el texto
        if (bestTime > 0)
        {
            bestTimeText.text = "Mejor tiempo: " + bestTime.ToString("F2") + " s";
        }
        else
        {
            bestTimeText.text = "No se ha ganado ninguna partida.";
        }

        // A�adir listener al bot�n para cargar la escena de juego
        playButton.onClick.AddListener(Jugar);
    }

    public void Jugar()
    {
        // Cargar la escena del juego
        SceneManager.LoadScene("Juego");
    }

    // M�todo para actualizar el mejor tiempo cuando se gana una partida
    public void UpdateBestTime(float newTime)
    {
        if (bestTime < 0 || newTime < bestTime)
        {
            bestTime = newTime;
        }
    }
}
