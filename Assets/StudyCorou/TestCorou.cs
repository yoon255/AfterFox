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
        //1��Ű�� ������ a�� ����
        if (Input.GetKeyDown(KeyCode.Alpha1))
        { StartCoroutine(a); }
        //2��Ű�� ������ a�� ����
        if (Input.GetKeyDown(KeyCode.Alpha2))
        { StopCoroutine(a); }
    }

    IEnumerator MakeBullet()
    {
        Debug.Log("�Ѿ˹߻�");
        while(true)
        {
            yield return new WaitForSeconds(0.2f);
            Debug.Log("��!");
        }
    }



    IEnumerator Test()
    {
        Debug.Log("�Ѿ�����");
        while(true)
        {
            yield return new WaitForSeconds(1);
            Debug.Log("�߻�");
        }
    }

}
