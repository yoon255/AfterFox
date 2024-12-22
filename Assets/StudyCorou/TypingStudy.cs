using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TypingStudy : MonoBehaviour
{
    public Text info;
    public string speech = "¿À´Ã ¹ä ¸Ô¾ú´Ï";

    void Start()
    {
        StartCoroutine(TyppingEffect("¾Æ´Ï¿À"));
    }

    IEnumerator TyppingEffect(string talk)
    {
        info.text = "";

        speech = talk;

        for (int i = 0; i < speech.Length; i++)
        {
            info.text += speech[i];
            yield return new WaitForSeconds(0.1f);
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
