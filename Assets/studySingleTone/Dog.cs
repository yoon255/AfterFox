using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog : MonoBehaviour
{
    //싱글톤
    //[개념] static의 특성을 활용해
    //       스크립트를 변수로 선언한 뒤, static을 붙여줌.
    //       instance = this는 awake에서 작성해두는것이 좋음.
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
