using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    Text timeText;
    [SerializeField]
    Text messageText;

    private void Start()
    {
        if (messageText != null)
        {
            messageText.gameObject.SetActive(false); // Ocultar el texto al principio
        }
    }

    void Update()
    {
        if(timeText != null)
            timeText.text = GameManager.Instance.GetStrTimer();
    }

    public void Inform(string message, Color color)
    {
        if (messageText != null){
            messageText.text = message;
            messageText.color = color; // Cambiar el color según la situación
            messageText.gameObject.SetActive(true); // Mostrar el texto
        }
    }
}
