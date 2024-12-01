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
            //��縦 ����
            switch (GM.instance.eProgress)
            {
                case GM.Progress.����Ʈ�ޱ���:
                    bubbleText.text = "ü���� �ι�°�� �Ծ�";
                    break;
                case GM.Progress.����Ʈ����_����X:
                    bubbleText.text = "� �԰� ��";
                    break;
                case GM.Progress.����Ʈ����_����O:
                    //2��° ���� �������� �̸��� ����
                    //bubbleText.text = "���߾�.";
                    //bubbleText.text = "������," + "\n" + "ü���� 2��°��";
                    break;
                case GM.Progress.����Ʈ�Ϸ�:
                    bubbleText.text = "�����߾�";
                    break;
            }

            //��ǳ�� Ȱ��ȭ
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
