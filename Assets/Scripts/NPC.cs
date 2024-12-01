using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NPC : MonoBehaviour
{
    public GameObject bubble;
    public TextMeshProUGUI bubbleText;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            //대사를 지정
            switch (GM.instance.eProgress)
            {
                case GM.Progress.퀘스트받기전:
                    bubbleText.text = "체리를 두번째로 먹어";
                    break;
                case GM.Progress.퀘스트받음_수행X:
                    bubbleText.text = "어서 먹고 와";
                    break;
                case GM.Progress.퀘스트받음_수행O:
                    //2번째 먹은 아이템의 이름에 따라서
                    //bubbleText.text = "잘했어.";
                    //bubbleText.text = "잊지마," + "\n" + "체리는 2번째야";
                    break;
                case GM.Progress.퀘스트완료:
                    bubbleText.text = "수고했어";
                    break;
            }

            //말풍선 활성화
            bubble.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            bubble.SetActive(false);
        }
    }
}
