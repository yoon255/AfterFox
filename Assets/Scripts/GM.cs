using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // TextMeshPro
using UnityEngine.UI;

public class GM : MonoBehaviour
{
    static public GM instance;

    public GameObject can_SNL;

    public enum Progress { 퀘스트받기전, 퀘스트받음_수행X, 퀘스트받음_수행O, 퀘스트완료 };
    public Progress eProgress = Progress.퀘스트받기전;
    //TextMeshPro가 아니라 TextMeshProUGUI
    public TextMeshProUGUI disPlay;

    public AudioSource cameraAS;
    public Slider sliderBG;

    public AudioSource playerAS;
    public Slider sliderEffect;

    private void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Cancel"))
        {
            //창이 꺼져있으면 -> 켜주면
            //켜있으면 -> 까주면 됨.

            //can_SNL.activeSelf: 현재 내 상태를 점검
            //                    on:  true
            //                    off: false
            //! : 반대 
            //!can_SNL.activeSelf : 내 상태의 반대
            can_SNL.SetActive(!can_SNL.activeSelf);
        }
    }

    public void Button_continu()
    {
        can_SNL.SetActive(false);
    }
    public void Button_save()
    {
        //[저장]
        //퀘스트진행도
        PlayerPrefs.SetInt("questProcess", (int)eProgress);
        Debug.Log(PlayerPrefs.GetInt("questProcess"));

        //캐릭터위치
        //PlayerPrefs: int, string, float 만 저장가능
        //             따라서, x,y,z를 분리해서 저장.
        PlayerPrefs.SetFloat("posX", Player.instance.transform.position.x);
        PlayerPrefs.SetFloat("posY", Player.instance.transform.position.y);
        PlayerPrefs.SetFloat("posZ", Player.instance.transform.position.z);
    }
    public void Button_Load()
    {
        //*불러오는것에 그치지 않고, 대입을 해줘야함.

        //저장한 값을 불러옴
        int process = PlayerPrefs.GetInt("questProcess");
        //Vector3 (posX, posY, posZ)
        float a = PlayerPrefs.GetFloat("posX");
        float b = PlayerPrefs.GetFloat("posY");
        float c = PlayerPrefs.GetFloat("posZ");
        
        //불러온 값으로 대입
        eProgress = (Progress)process;
        disPlay.text = eProgress.ToString();    
        Player.instance.transform.position = new Vector3(a, b, c);  
    }


    public void Button_exit()
    {
        //전처리기: pre(전)process(처리)
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; //에디터 종료   
#else
        Application.Quit(); //어플리케이션 종료
#endif
    }

    public void SetBG()
    {
        cameraAS.volume = sliderBG.value;

    }
    //~47분
    //효과음 slider를 움직이면, 효과음(플레이어의 점프사운드)이 조절되도록
    public void SetEffect()
    {
        playerAS.volume = sliderEffect.value;   
    }

}
