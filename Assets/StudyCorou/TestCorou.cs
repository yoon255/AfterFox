using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCorou : MonoBehaviour
{
    public IEnumerator a;


    // Start is called before the first frame update
    void Start()
    {
        a = Test();
    }

    // Update is called once per frame
    void Update()
    {
        //1번키를 누르면 a가 실행
        if (Input.GetKeyDown(KeyCode.Alpha1))
        { StartCoroutine(a); }
        //2번키를 누르면 a가 종료
        if (Input.GetKeyDown(KeyCode.Alpha2))
        { StopCoroutine(a); }
    }

    IEnumerator MakeBullet()
    {
        Debug.Log("총알발사");
        while(true)
        {
            yield return new WaitForSeconds(0.2f);
            Debug.Log("탕!");
        }
    }



    IEnumerator Test()
    {
        Debug.Log("총알장전");
        while(true)
        {
            yield return new WaitForSeconds(1);
            Debug.Log("발사");
        }
    }

}
