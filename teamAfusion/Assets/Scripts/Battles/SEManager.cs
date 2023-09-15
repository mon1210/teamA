using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SEManager : MonoBehaviour
{
    //se用audioSourceを取得
    [SerializeField] AudioSource seAudioSource;
    //se情報の取得
    [SerializeField] List<SESoundData> seSoundDatas;
    //se全体のボリューム取得
    [SerializeField] private float seMasterVolume = 1;

    //別クラスからの参照を可能に
    public static SEManager Instance { get; private set; }

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
    //SE再生用関数
    public void PlaySE(SESoundData.SE se)
    {
        SESoundData data = seSoundDatas.Find(data => data.Se == se);
        seAudioSource.volume = data.Volume * seMasterVolume;
        seAudioSource.PlayOneShot(data.AudioClip);
    }

    [System.Serializable]
    public class SESoundData
    {
        //列挙型でSEのラベルを設定
        public enum SE
        {
            Default = -1,
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
}