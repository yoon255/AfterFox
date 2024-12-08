using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public List<string> itemNames;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(1, 0, 0);
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
    }


}
