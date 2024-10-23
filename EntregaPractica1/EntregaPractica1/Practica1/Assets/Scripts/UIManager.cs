using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    Text livesText;
    [SerializeField]
    Text messageText;

    private void Start()
    {
        messageText.gameObject.SetActive(false); // Ocultar el texto al principio
    }

    void Update()
    {
        livesText.text = "Lives: " + GameManager.Instance.getLives();
    }

    public void Inform(string message, Color color)
    {
        messageText.text = message;
        messageText.color = color; // Cambiar el color según la situación
        messageText.gameObject.SetActive(true); // Mostrar el texto
    }
}
