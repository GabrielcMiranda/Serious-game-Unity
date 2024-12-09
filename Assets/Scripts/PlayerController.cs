using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerController : MonoBehaviour
{
    public ControladorObjeto controladorObjeto;

    public InterfaceController interfaceController;
    public CapsuleCollider2D capsuleCollider2D;

    private Collider2D objetoColisor;
    public GameObject folhaPapel;
    private Rigidbody2D _playerRigidbody2D;

    private Animator _playerAnimator;
    public float _playerSpeed;
    private Vector2 _playerDirection;

    // Start is called before the first frame update
    void Start()
    {
        _playerRigidbody2D = GetComponent<Rigidbody2D>();
        _playerAnimator = GetComponent<Animator>();
        interfaceController = FindObjectOfType<InterfaceController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        _playerDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if(_playerDirection.sqrMagnitude > 0){
            _playerAnimator.SetInteger("Movimento", 1);
        }
        else{
            _playerAnimator.SetInteger("Movimento", 0);
        }
        Flip();

        if(objetoColisor != null && capsuleCollider2D.IsTouching(objetoColisor)){
            if (Input.GetKeyDown(KeyCode.E) && _activeFolhaRoutine == null && controladorObjeto != null && controladorObjeto.isCorrect())
            {
                _activeFolhaRoutine = StartCoroutine(ActiveFolhaPapel());
            }

        }
        else{
            folhaPapel.SetActive(false);
        }
    }

    void FixedUpdate(){

        _playerRigidbody2D.MovePosition(_playerRigidbody2D.position + _playerDirection.normalized * _playerSpeed * Time.fixedDeltaTime);
    }

    void Flip(){

        if(_playerDirection.x > 0){
            transform.eulerAngles = new Vector2(0f, 0f);
        }
        if(_playerDirection.x < 0){
            transform.eulerAngles = new Vector2(0f, 180f);
        }
    }

    private Coroutine _activeFolhaRoutine;

    void OnTriggerStay2D(Collider2D col)
    {
        ControladorObjeto aux = col.gameObject.GetComponent<ControladorObjeto>();
        if (aux != null && aux.isCorrect())
        {
            controladorObjeto = aux;
            objetoColisor = col;


        }
    }

    IEnumerator ActiveFolhaPapel()
    {
        yield return new WaitForEndOfFrame();
        folhaPapel.SetActive(!folhaPapel.activeInHierarchy);
        yield return new WaitForEndOfFrame();
        _activeFolhaRoutine = null;
    }

    


    
}
