using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class InterfaceController : MonoBehaviour
{
    public List<string> listaCodigosCorretos = new(){"7","9","8","1"};
    public List<string> listaChavesCorretos = new(){"An(n) = (n+((183/262) em Z11))mod 26","An(n) = (n+((229/178) em Z7))mod 26","An(n) = (n+((165/289) em Z23))mod 26","An(n) = (n+((27/19) em Z14))mod 26"};

    public List<int> listaTransladosCifras = new(){2,4,18,11};
    public int faseAtual;

    public Dictionary<int, TMP_InputField> inputPorFase = new();

    public Dictionary<int, List<Objects>>objetosPorFase = new();

    public Objects objetoAtual;
    public TMP_InputField n1;
    public TMP_InputField n2;
    public TMP_InputField n3;
    public TMP_InputField n4;
    public TextMeshProUGUI palavraCodificada;
    public TextMeshProUGUI codigoCripto;
    public GameObject telaCofre;
    public GameObject telaFinal;
    public Rigidbody2D player;

    public List<Objects> objetosf1;
    public List<Objects> objetosf2;
    public List<Objects> objetosf3;
    public List<Objects> objetosf4;

    bool cofreActive = false;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
        inputPorFase = new()
        {
            {
                0,n1
            },
            {
                1,n2
            },
            {
                2,n3
            },
            {
                3,n4
            },
        };

        objetosPorFase = new(){
            {
                0,objetosf1
            },
            {
                1,objetosf2
            },
            {
                2,objetosf3
            },
            {
                3,objetosf4
            },
        };
        gerarFase();
    }

    // Update is called once per frame
    void Update()
    {
        OpenCofre();
        Exit();
    }

    void OpenCofre(){
        if(player.position.x >= 4 && player.position.x <=5 && player.position.y >= 4.5 && player.position.y <= 4.9){
            if(Input.GetKeyDown(KeyCode.E)){
                cofreActive = !cofreActive;
                telaCofre.SetActive(cofreActive);
            }
        }
    }

    void gerarFase(){
        int randomico = UnityEngine.Random.Range(0, objetosf1.Count);
        objetosPorFase[faseAtual][randomico].criptografarPalavra(listaTransladosCifras[faseAtual]);
        palavraCodificada.text =objetosPorFase[faseAtual][randomico].palavraCriptografada;
        codigoCripto.text = listaChavesCorretos[faseAtual];
        objetoAtual = objetosPorFase[faseAtual][randomico];
        

    }

    public void verificarFase(string valor){
        if(listaCodigosCorretos[faseAtual] == valor){
            inputPorFase[faseAtual++].interactable = false;
            if(faseAtual < inputPorFase.Count){
                inputPorFase[faseAtual].interactable = true;
                gerarFase();
            }
            if(faseAtual == 4){
                palavraCodificada.text = "Você encontrou a chave!!";
                codigoCripto.text = "";
            }
        }
    }
    void Exit(){
        if(faseAtual == 4 && player.position.x >= 19 && player.position.x <=22 && player.position.y >= -3.5 && player.position.y <= -3){
            if(Input.GetKeyDown(KeyCode.E)){
                telaFinal.SetActive(true);
            }
        }
    }
}
