using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]
public class EfeitoDigital : MonoBehaviour
{
    private TextMeshProUGUI compTexto;
    private AudioSource audio;
    private string mensagem;
    public bool imprimindo;
    public float tempo = 0.08f;

    private void Awake()
    {
        TryGetComponent(out compTexto);
        TryGetComponent(out audio);
        mensagem = compTexto.text; 
        compTexto.text = "";

    }
    private void OnEnable()
    {
         imprimirMensagem(mensagem);
    }
    private void OnDisable()
    {
        compTexto.text = mensagem;
        StopAllCoroutines();
    }
    public void imprimirMensagem(string m)
    {
        if(gameObject.activeInHierarchy)
        {
        if(imprimindo) return;
        imprimindo = true;
        StartCoroutine(Letra(m));
        }

    }
    IEnumerator Letra(string m)
    {
        string msg = "";
        foreach (var letra in m){
            msg += letra;
            compTexto.text = msg;
            audio.Play();
            yield return new WaitForSeconds(tempo);
        }
        imprimindo = false;
        StopAllCoroutines();


    }

}
