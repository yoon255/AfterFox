using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // TextMeshPro

public class GM : MonoBehaviour
{
    static public GM instance;
    public enum Progress { 퀘스트받기전, 퀘스트받음_수행X, 퀘스트받음_수행O, 퀘스트완료 };
    public Progress eProgress = Progress.퀘스트받기전;
    //TextMeshPro가 아니라 TextMeshProUGUI
    public TextMeshProUGUI disPlay;

    private void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
