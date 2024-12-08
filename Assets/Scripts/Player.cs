using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    static public Player instance;
    public List<string> itemNames;
    public float speed = 6f;
    public Rigidbody2D foxRB;
    public int jumpCount = 0;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
         
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        
        if(jumpCount < 2)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                jumpCount++;
                foxRB.velocity = new Vector2(0, 0);
                foxRB.AddForce(new Vector2(0, 1) * 20, ForceMode2D.Impulse);
            }
        }
    }

    void Move()
    {

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += new Vector3(+1, 0, 0) * Time.deltaTime * speed;
            transform.rotation = Quaternion.Euler(0, 0, 0);

            //유니티 회전 
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += new Vector3(-1, 0, 0) * Time.deltaTime * speed;
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }

        //참고: Input.GetAxisRaw("Horizontal"); //-1,0,1
    }




    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("item"))
        {
            itemNames.Add(collision.gameObject.name);

            if(GM.instance.eProgress == GM.Progress.퀘스트받음_수행X)
            {
                if(itemNames.Count == 2)
                {
                    GM.instance.eProgress = GM.Progress.퀘스트받음_수행O;
                    GM.instance.disPlay.text = GM.instance.eProgress.ToString();
                }
            }
        }
        if(collision.gameObject.CompareTag("floor"))
        {
            jumpCount = 0;
        }

    }


}
