using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Luli : MonoBehaviour
{
    public float velh = 5f;
    public float velv = 7f;
    public int totalPulos = 1;
    public int QuantidadePulos = 1;
    private Rigidbody2D meuRB;
    private Animator meuAnim;


    // Start is called before the first frame update
    void Start()
    {
        //Pegando RB
        meuRB = GetComponent<Rigidbody2D>();
        meuAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Movendo();
        Pulando();
    }

    private void Movendo()
    {
        var movimento = Input.GetAxis("Horizontal") * velh;
        meuRB.velocity = new Vector2(movimento, meuRB.velocity.y);

        if (movimento != 0)
        {
            transform.localScale = new Vector3(Mathf.Sign(movimento), 1f, 1f);

            meuAnim.SetBool("Movendo", true);

        }
        else
        {
            meuAnim.SetBool("Movendo", false);
        }
    }

    private void Pulando()
    {
        Debug.Log("Pulo");
        var pulo = Input.GetButtonDown("Jump");

        meuAnim.SetBool("NoChao", true);

    if (pulo && QuantidadePulos > 0)
    {
        meuRB.velocity = new Vector2(meuRB.velocity.x, velv);
        QuantidadePulos--;

        //Avisando que estou no chao
        meuAnim.SetBool("NoChao", false);
    }
    
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Colidindo com o chao
        if (collision.gameObject.CompareTag("chao") )
        {
            QuantidadePulos = totalPulos;
        }
    }
}
