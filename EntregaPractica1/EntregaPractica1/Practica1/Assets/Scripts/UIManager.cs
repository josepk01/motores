using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    
    //[SerializeField]
    //Canvas canvas;
    [SerializeField]
    Text infoText;

    //Descomentar todo lo relacionado con livesText (Y ASIGNAR EL TEXTO) para ver las vidas que te quedan en la UI
    [SerializeField]
    Text livesText;

    // Start is called before the first frame update
    void Start()
    {
        //canvas.gameObject.SetActive(false);
        infoText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        livesText.text = "Lives: " + GameManager.instance.getLives();
    }


    public void Inform(string info)
    {

        infoText.GetComponent<Text>().text = info;
        //canvas.gameObject.SetActive(true);
        infoText.gameObject.SetActive(true);
    }
}
