using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    //static특징을 활용.
    //- 공유함
    //- 다른곳에서 바로 불러올 수 있음
    //타스크립트에서 해당 스크립트를 호출할 수 있도록

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
