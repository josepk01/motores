using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    Text timeText;
    [SerializeField]
    Text messageText;

    [SerializeField]
    private Button continueButton;

    private void Start()
    {
        GameManager.Instance.setUiManager(this);
        if (messageText != null)
        {
            messageText.gameObject.SetActive(false); // Ocultar el texto y boton al principio
            continueButton.gameObject.SetActive(false);
        }

        continueButton.onClick.AddListener(Volver);
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
            continueButton.gameObject.SetActive(true);
        }
    }

    private void Volver()
    {
        GameManager.Instance.restartBubbles();
        
        GameManager.Instance.RestartTimer();
        
        SceneManager.LoadScene("Menu");
    }
}
