using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SEManager : MonoBehaviour
{
    //se�paudioSource���擾
    [SerializeField] AudioSource seAudioSource;
    //se���̎擾
    [SerializeField] List<SESoundData> seSoundDatas;
    //se�S�̂̃{�����[���擾
    [SerializeField] private float seMasterVolume = 1;

    //�ʃN���X����̎Q�Ƃ��\��
    public static SEManager Instance { get; private set; }

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
    //SE�Đ��p�֐�
    public void PlaySE(SESoundData.SE se)
    {
        SESoundData data = seSoundDatas.Find(data => data.Se == se);
        seAudioSource.volume = data.Volume * seMasterVolume;
        seAudioSource.PlayOneShot(data.AudioClip);
    }

    [System.Serializable]
    public class SESoundData
    {
        //�񋓌^��SE�̃��x����ݒ�
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
}