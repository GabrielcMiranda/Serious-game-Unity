using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TimelineManager : MonoBehaviour
{
    public GameObject textBox;
    public PlayableDirector playableDirector;
    public Transform canvas;

    public int textoIndex;

    public List<string> dialogos;

    private TextBoxController CreateTextBox(string text)
    {
        TextBoxController textBoxController = Instantiate(textBox,canvas).GetComponent<TextBoxController>();
        textBoxController.SetText(text);
        return textBoxController;
    }

    public void CreateTextBox()
    {
        var textB = CreateTextBox(dialogos[textoIndex++]);
        textB.RegisterContinueAction(() =>
        {
            playableDirector.Play();
            Destroy(textB.gameObject);
        });
        playableDirector.Pause();
        
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
