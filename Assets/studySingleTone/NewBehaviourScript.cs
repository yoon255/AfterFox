using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    //staticƯ¡�� Ȱ��.
    //- ������
    //- �ٸ������� �ٷ� �ҷ��� �� ����
    //Ÿ��ũ��Ʈ���� �ش� ��ũ��Ʈ�� ȣ���� �� �ֵ���

    static public NewBehaviourScript instance;

    void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
