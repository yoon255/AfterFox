using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NPC : MonoBehaviour
{
    public GameObject bubble;
    TextMeshProUGUI bubbleText;

    
    private void Start()
    {
        Inital();
    }

    //초기화 함수
    //초기값을 할당하거나
    //변수를을 할당할때 사용
    void Inital()
    {
        //1 or 2방법 사용
        bubbleText = bubble.GetComponentInChildren<TextMeshProUGUI>();
        bubbleText = bubble.transform.GetChild(0).GetComponent<TextMeshProUGUI>();    
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player sPlayer = collision.gameObject.GetComponent<Player>();

        if (collision.CompareTag("Player"))
        {
            //메인BGM감소
            StartCoroutine(GM.instance.MainVol_Down());

            //대사를 지정
            switch (GM.instance.eProgress)
            {
                case GM.Progress.퀘스트받기전:
                    bubbleText.text = "체리를 두번째로 먹어";
                    GM.instance.eProgress = GM.Progress.퀘스트받음_수행X;
                    break;
                case GM.Progress.퀘스트받음_수행X:
                    bubbleText.text = "어서 먹고 와";
                    break;
                case GM.Progress.퀘스트받음_수행O:
                    if(sPlayer.itemNames[1] == "cherry")
                    {
                        bubbleText.text = "잘했어.";
                        GM.instance.eProgress = GM.Progress.퀘스트완료;
                    }
                    else
                    {
                        bubbleText.text = "잊지마," + "\n" + "체리는 2번째야";
                        GM.instance.eProgress = GM.Progress.퀘스트받음_수행X;
                        sPlayer.itemNames.Clear();
                    }
                    break;
                case GM.Progress.퀘스트완료:
                    bubbleText.text = "수고했어";
                    break;
            }

            GM.instance.disPlay.text = GM.instance.eProgress.ToString();

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
