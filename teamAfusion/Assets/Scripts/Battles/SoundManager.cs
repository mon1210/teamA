using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SoundManager : MonoBehaviour
{
    //bgm�paudioSource���擾
    [SerializeField] AudioSource bgmAudioSource;
    //se�paudioSource���擾
    [SerializeField] AudioSource seAudioSource;
    //bgm���̎擾
    [SerializeField] List<BGMSoundData> bgmSoundDatas;
    //se���̎擾
    [SerializeField] List<SESoundData> seSoundDatas;

    //�����S�̂̃{�����[���擾
    [SerializeField] private float masterVolume = 1;
    //bgm�S�̂̃{�����[���擾
    [SerializeField] private float bgmMasterVolume = 1;
    //se�S�̂̃{�����[���擾
    [SerializeField] private float seMasterVolume = 1;

    //�ʃN���X����̎Q�Ƃ��\��
    public static SoundManager Instance { get; private set; }

    private void Awake()
    {
        //null�`�F�b�N
        if (Instance == null)
        {
            Instance = this;
            //�V�[���Ԃŉi���I�ɕێ�����
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            //���łɂ���ꍇ�͍폜
            Destroy(gameObject);
        }
    }

    //BGM�Đ��p�֐�
    public void PlayBGM(BGMSoundData.BGM bgm)
    {
        BGMSoundData data = bgmSoundDatas.Find(data => data.Bgm == bgm);
        bgmAudioSource.clip = data.AudioClip;
        bgmAudioSource.volume = data.Volume * bgmMasterVolume * masterVolume;
        bgmAudioSource.Play();
    }

    //SE�Đ��p�֐�
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
    //�񋓌^��BGM�̃��x����ݒ�
    public enum BGM
    {
        Default = - 1,
        FirstBattle,
        SecondBattle,
        ThirdBattle,
    }

    //���x���̎擾
    [SerializeField] private BGM bgm;
    //�����̎擾
    [SerializeField] private AudioClip audioClip;
    [Range(0, 1)]
    //�{�����[���̎擾
    [SerializeField] private float volume = 1;

    //private�ϐ��̎Q�Ƃ��\��
    public BGM Bgm { get => bgm; }
    public AudioClip AudioClip { get => audioClip; }
    public float Volume { get => volume; }
}

[System.Serializable]
public class SESoundData
{
    //�񋓌^��SE�̃��x����ݒ�
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

    //���x���̎擾
    [SerializeField] private SE se;
    //�����̎擾
    [SerializeField] private AudioClip audioClip;
    [Range(0, 1)]
    //�{�����[���̎擾
    [SerializeField] private float volume = 1;

    //private�ϐ��̎Q�Ƃ��\��
    public SE Se { get => se; }
    public AudioClip AudioClip { get => audioClip; }
    public float Volume { get => volume; }
}