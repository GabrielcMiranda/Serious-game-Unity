using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


[CreateAssetMenu(fileName = "New Object", menuName = "Cofre Objects/Create new")]
public class Objects : ScriptableObject
{
    char[] alphabet = new char[26]{'a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z'};
   public String palavraCriptografada;
   public String palavraDescriptografada;
    
   public void criptografarPalavra(int translado){
    palavraCriptografada = "";
    for(int i = 0; i<palavraDescriptografada.Length;i++){
        for(int j = 0;j<26;j++){
            if(palavraDescriptografada[i].Equals(alphabet[j])){
                palavraCriptografada += alphabet[(j+translado)%26];
            }
        }
    }
   }
}
