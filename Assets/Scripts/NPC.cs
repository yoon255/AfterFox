using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NPC : MonoBehaviour
{
    public GameObject bubble;
    TextMeshProUGUI bubbleText;
    public string speech;

    private void Start()
    {
        Inital();
    }

    //�ʱ�ȭ �Լ�
    //�ʱⰪ�� �Ҵ��ϰų�
    //�������� �Ҵ��Ҷ� ���
    void Inital()
    {
        //1 or 2��� ���
        bubbleText = bubble.GetComponentInChildren<TextMeshProUGUI>();
        bubbleText = bubble.transform.GetChild(0).GetComponent<TextMeshProUGUI>();    
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player sPlayer = collision.gameObject.GetComponent<Player>();

        if (collision.CompareTag("Player"))
        {
            //����BGM����
            GM.instance.Vol_down();

            //��縦 ��
            switch (GM.instance.eProgress)
            {
                case GM.Progress.����Ʈ�ޱ���:
                    StartCoroutine(TyppingEffect("ü���� �ι�°�� �Ծ�"));
                    GM.instance.eProgress = GM.Progress.����Ʈ����_����X;
                    break;
                case GM.Progress.����Ʈ����_����X:
                    bubbleText.text = "� �԰� ��";
                    break;
                case GM.Progress.����Ʈ����_����O:
                    if(sPlayer.itemNames[1] == "cherry")
                    {
                        bubbleText.text = "���߾�.";
                        GM.instance.eProgress = GM.Progress.����Ʈ�Ϸ�;
                    }
                    else
                    {
                        bubbleText.text = "������," + "\n" + "ü���� 2��°��";
                        GM.instance.eProgress = GM.Progress.����Ʈ����_����X;
                        sPlayer.itemNames.Clear();
                    }
                    break;
                case GM.Progress.����Ʈ�Ϸ�:
                    bubbleText.text = "�����߾�";
                    break;
            }

            GM.instance.disPlay.text = GM.instance.eProgress.ToString();

            //��ǳ�� Ȱ��ȭ
            bubble.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GM.instance.Vol_up();
            bubble.SetActive(false);
        }
    }

    IEnumerator TyppingEffect(string talk)
    {
        bubbleText.text = "";

        speech = talk;

        for (int i = 0; i < speech.Length; i++)
        {
            bubbleText.text += speech[i];
            yield return new WaitForSeconds(0.1f);
        }
    }

}
