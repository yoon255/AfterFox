using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog : MonoBehaviour
{
    //�̱���
    //[����] static�� Ư���� Ȱ����
    //       ��ũ��Ʈ�� ������ ������ ��, static�� �ٿ���.
    //       instance = this�� awake���� �ۼ��صδ°��� ����.
    static public Dog instance = null;



    void Awake()
    {
        instance = this;
    }


    static public int food = 5;
    public int food2 = 5;


    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {

    }
}
