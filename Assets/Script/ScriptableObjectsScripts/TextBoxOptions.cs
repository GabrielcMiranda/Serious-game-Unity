using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Armazena textos que ser�o mostrados na caixa de texto
/// durante a jogabilidade
/// </summary>

//namespace BabyProject.Timeline
//{
[CreateAssetMenu(fileName = "TextBoxOptions", menuName = "ScriptableObject/TextBoxOptions")]
public class TextBoxOptions : ScriptableObject
{
    [SerializeField, TextArea(3, 8)] private string _textBoxText;

    public string TextBoxText
    {
        get { return _textBoxText; }
        set { _textBoxText = value; }
    }
}
//}