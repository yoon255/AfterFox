using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // TextMeshPro
using UnityEngine.UI;
using UnityEngine.Audio;

public class GM : MonoBehaviour
{
    static public GM instance;

    public GameObject can_SNL;

    public enum Progress { ����Ʈ�ޱ���, ����Ʈ����_����X, ����Ʈ����_����O, ����Ʈ�Ϸ� };
    public Progress eProgress = Progress.����Ʈ�ޱ���;
    //TextMeshPro�� �ƴ϶� TextMeshProUGUI
    public TextMeshProUGUI disPlay;

    public AudioMixer mixer;
    public AudioSource cameraAS;
    [SerializeField] float cameraAS_oriVol;
    public Slider sliderBG;

    public AudioSource playerAS;
    public Slider sliderEffect;

    public GameObject canSound;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        cameraAS_oriVol = cameraAS.volume;
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

        //����
        PlayerPrefs.SetFloat("valueBG", sliderBG.value);
        PlayerPrefs.SetFloat("valueEffect", sliderEffect.value);
    }
    public void Button_Load()
    {
        //*�ҷ����°Ϳ� ��ġ�� �ʰ�, ������ �������.

        //������ ���� �ҷ���
        int process = PlayerPrefs.GetInt("questProcess");
        //Vector3 (posX, posY, posZ)
        float a = PlayerPrefs.GetFloat("posX");
        float b = PlayerPrefs.GetFloat("posY");
        float c = PlayerPrefs.GetFloat("posZ");
        float vBG = PlayerPrefs.GetFloat("valueBG");
        float vEffect = PlayerPrefs.GetFloat("valueEffect");

        //�ҷ��� ������ ����
        eProgress = (Progress)process;
        disPlay.text = eProgress.ToString();    
        Player.instance.transform.position = new Vector3(a, b, c);  
        sliderBG.value = vBG;
        sliderEffect.value = vEffect;
    }


    public void Button_exit()
    {
        //��ó����: pre(��)process(ó��)
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; //������ ����   
#else
        Application.Quit(); //���ø����̼� ����
#endif
    }

    public void SetBG()
    {
        //���� ����� ������
        //cameraAS.volume = sliderBG.value;

        //mixerȰ����
        if(sliderBG.value == -40)
        {
            mixer.SetFloat("ExposedPara_bg", -80);
        }
        else
        {
            mixer.SetFloat("ExposedPara_bg", sliderBG.value);
        }
    }
    //~47��
    //ȿ���� slider�� �����̸�, ȿ����(�÷��̾��� ��������)�� �����ǵ���
    public void SetEffect()
    {
        if(sliderEffect.value == -40)
        {
            mixer.SetFloat("ExposedPara_effect", -80);
        }
        else
        {
            mixer.SetFloat("ExposedPara_effect", sliderEffect.value);
        }
    }
    public void ActiveSetSound(bool a)
    {
        canSound.SetActive(a);
    }

    public IEnumerator MainVol_Down()
    {
        //���������ݺ�: 0�̵ɶ�����
        while(cameraAS.volume > 0.05f)
        {
            cameraAS.volume -= 0.01f;
            yield return null; //�� 0.02
        }
        cameraAS.volume = 0;
    }
    public IEnumerator MainVol_Up()
    {
        //���������ݺ�: 0�̵ɶ�����
        while (cameraAS.volume < cameraAS_oriVol)
        {
            cameraAS.volume += 0.01f;
            yield return null; //�� 0.02
        }
        cameraAS.volume = cameraAS_oriVol;
    }
    public void Vol_up()
    {
        StopCoroutine("MainVol_Down");
        StartCoroutine("MainVol_Up");
    }
    public void Vol_down()
    {
        StopAllCoroutines();
        StartCoroutine("MainVol_Down");
    }



}
