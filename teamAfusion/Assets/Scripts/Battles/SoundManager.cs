using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SoundManager : MonoBehaviour
{
    //bgm用audioSourceを取得
    [SerializeField] AudioSource bgmAudioSource;
    //se用audioSourceを取得
    [SerializeField] AudioSource seAudioSource;
    //bgm情報の取得
    [SerializeField] List<BGMSoundData> bgmSoundDatas;
    //se情報の取得
    [SerializeField] List<SESoundData> seSoundDatas;

    //音源全体のボリューム取得
    [SerializeField] private float masterVolume = 1;
    //bgm全体のボリューム取得
    [SerializeField] private float bgmMasterVolume = 1;
    //se全体のボリューム取得
    [SerializeField] private float seMasterVolume = 1;

    //別クラスからの参照を可能に
    public static SoundManager Instance { get; private set; }

    private void Awake()
    {
        //nullチェック
        if (Instance == null)
        {
            Instance = this;
            //シーン間で永続的に保持する
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            //すでにある場合は削除
            Destroy(gameObject);
        }
    }

    //BGM再生用関数
    public void PlayBGM(BGMSoundData.BGM bgm)
    {
        BGMSoundData data = bgmSoundDatas.Find(data => data.Bgm == bgm);
        bgmAudioSource.clip = data.AudioClip;
        bgmAudioSource.volume = data.Volume * bgmMasterVolume * masterVolume;
        bgmAudioSource.Play();
    }

    //SE再生用関数
    public void PlaySE(SESoundData.SE se)
    {
        SESoundData data = seSoundDatas.Find(data => data.Se == se);
        seAudioSource.volume = data.Volume * seMasterVolume * masterVolume;
        seAudioSource.PlayOneShot(data.AudioClip);
    }

}

[System.Serializable]
public class BGMSoundData
{
    //列挙型でBGMのラベルを設定
    public enum BGM
    {
        Default = - 1,
        FirstBattle,
        SecondBattle,
        ThirdBattle,
    }

    //ラベルの取得
    [SerializeField] private BGM bgm;
    //音源の取得
    [SerializeField] private AudioClip audioClip;
    [Range(0, 1)]
    //ボリュームの取得
    [SerializeField] private float volume = 1;

    //private変数の参照を可能に
    public BGM Bgm { get => bgm; }
    public AudioClip AudioClip { get => audioClip; }
    public float Volume { get => volume; }
}

[System.Serializable]
public class SESoundData
{
    //列挙型でSEのラベルを設定
    public enum SE
    {
        Default = - 1,
        Selection,
        Confirmation,
        Back,
        Victory,
        Defeat,
        Damage,
        Attack,
        Magic,
        Heal,
        Ultimate,

    }

    //ラベルの取得
    [SerializeField] private SE se;
    //音源の取得
    [SerializeField] private AudioClip audioClip;
    [Range(0, 1)]
    //ボリュームの取得
    [SerializeField] private float volume = 1;

    //private変数の参照を可能に
    public SE Se { get => se; }
    public AudioClip AudioClip { get => audioClip; }
    public float Volume { get => volume; }
}