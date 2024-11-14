using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public Text bestTimeText; // Referencia al texto donde se mostrará el tiempo mínimo.
    public Button playButton; // Referencia al botón de "Jugar".

    private float bestTime = -1f; // Variable para almacenar el tiempo mínimo. -1 significa que no hay un tiempo aún.

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

        // Añadir listener al botón para cargar la escena de juego
        playButton.onClick.AddListener(Jugar);
    }

    public void Jugar()
    {
        // Cargar la escena del juego
        SceneManager.LoadScene("Juego");
    }

    // Método para actualizar el mejor tiempo cuando se gana una partida
    public void UpdateBestTime(float newTime)
    {
        if (bestTime < 0 || newTime < bestTime)
        {
            bestTime = newTime;
        }
    }
}
