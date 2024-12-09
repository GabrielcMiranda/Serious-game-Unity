using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ControladorObjeto : MonoBehaviour
{

    public TextMeshProUGUI textMeshProUGUI;
    public int DigitoCerto;
    public Objects objeto;
    public InterfaceController interfaceController;
    void Start()
    {
        interfaceController = FindObjectOfType<InterfaceController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool isCorrect(){
        bool valido = interfaceController.objetoAtual.Equals(objeto);
        if(valido){
            textMeshProUGUI.text = DigitoCerto.ToString();
        }
        return valido;
    }
}
