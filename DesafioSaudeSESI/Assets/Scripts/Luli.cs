using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Luli : MonoBehaviour
{
    public float velh = 5f;
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

}
