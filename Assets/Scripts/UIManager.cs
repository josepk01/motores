using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text messageText;

    private void Start()
    {
        messageText.gameObject.SetActive(false); // Ocultar el texto al principio
    }

    public void Inform(string message, Color color)
    {
        messageText.text = message;
        messageText.color = color; // Cambiar el color según la situación
        messageText.gameObject.SetActive(true); // Mostrar el texto
    }
}
