using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class TextBoxController : MonoBehaviour
{
    public UnityEvent OnClosePanel;

    [SerializeField]
    private TextMeshProUGUI _text;

    [SerializeField]
    private Button _continueButton;
    [SerializeField]
    private string _playerName;
    [SerializeField]
    private TextMeshProUGUI _playerNameText;
    [SerializeField]
    private bool _enableButton;
    private Action _continueAction;
    private Animator _animator;

    private void Start()
    {
        _continueButton.gameObject.SetActive(_enableButton);
        _animator = GetComponent<Animator>();
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            _continueAction?.Invoke();
        }

        if (_animator != null)
        {
            _animator.SetBool("IsNameEmpty", string.IsNullOrEmpty(_playerNameText.text));
        }
    }

    public void OnEnable()
    {
        if (_playerNameText != null && _playerName != null)
        {
            _playerNameText.text = _playerName;
        }
    }

    public void OnDisable()
    {
        OnClosePanel?.Invoke();
    }

    public void SetText(string text)
    {
        _text.text = text;
    }

    public void RegisterContinueAction(Action action)
    {
        StartCoroutine(ActiveContinueButton());
        _continueAction = action;
        _continueButton.onClick.AddListener(() => action.Invoke());
    }

    private IEnumerator ActiveContinueButton()
    {
        yield return new WaitForEndOfFrame();
        _continueButton.gameObject.SetActive(true);
    }
}
