using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // TextMeshPro

public class GM : MonoBehaviour
{
    public enum Progress { ����Ʈ�ޱ���, ����Ʈ����_����X, ����Ʈ����_����O, ����Ʈ�Ϸ� };
    public Progress eProgress = Progress.����Ʈ�ޱ���;
    //TextMeshPro�� �ƴ϶� TextMeshProUGUI
    public TextMeshProUGUI disPlay;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
