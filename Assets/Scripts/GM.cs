using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // TextMeshPro

public class GM : MonoBehaviour
{
    static public GM instance;

    public GameObject can_SNL;

    public enum Progress { ����Ʈ�ޱ���, ����Ʈ����_����X, ����Ʈ����_����O, ����Ʈ�Ϸ� };
    public Progress eProgress = Progress.����Ʈ�ޱ���;
    //TextMeshPro�� �ƴ϶� TextMeshProUGUI
    public TextMeshProUGUI disPlay;

    private void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Cancel"))
        {
            //â�� ���������� -> ���ָ�
            //�������� -> ���ָ� ��.

            //can_SNL.activeSelf: ���� �� ���¸� ����
            //                    on:  true
            //                    off: false
            //! : �ݴ� 
            //!can_SNL.activeSelf : �� ������ �ݴ�
            can_SNL.SetActive(!can_SNL.activeSelf);
        }
    }

    public void Button_continu()
    {
        can_SNL.SetActive(false);
    }
    public void Button_save()
    {
        //[����]
        //����Ʈ���൵
        PlayerPrefs.SetInt("questProcess", (int)eProgress);
        Debug.Log(PlayerPrefs.GetInt("questProcess"));

        //ĳ������ġ
        //PlayerPrefs: int, string, float �� ���尡��
        //             ����, x,y,z�� �и��ؼ� ����.
        PlayerPrefs.SetFloat("posX", Player.instance.transform.position.x);
        PlayerPrefs.SetFloat("posY", Player.instance.transform.position.y);
        PlayerPrefs.SetFloat("posZ", Player.instance.transform.position.z);
    }
    public void Button_Load()
    {
        //*�ҷ����°Ϳ� ��ġ�� �ʰ�, ������ �������.

        //������ ���� �ҷ���
        int process = PlayerPrefs.GetInt("questProcess");
        //Vector3 (posX, posY, posZ)

        //�ҷ��� ������ ����
        eProgress = (Progress)process;
    }

}
