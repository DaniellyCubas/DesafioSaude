using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        int quantidade = FindObjectsOfType<GameManager>().Length;
        Debug.Log(quantidade);

        if ( quantidade > 1)
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IniciaJogo()
    {
        SceneManager.LoadScene(1);
    }

    IEnumerator PrimeiraCena()
    {
        yield return new WaitForSeconds(2f);
        //Todo codigo daqui so vai rodar depois de 2 segundos
        SceneManager.LoadScene(0);
    }

    public void Inicio()
    {
        //Iniciando corotina
        StartCoroutine(PrimeiraCena()); 
    }
    public void Sair()
    {
        Application.Quit();
        Debug.Log("Fechei");
    }
}
