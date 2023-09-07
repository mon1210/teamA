using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleDialog : MonoBehaviour
{
    //�e�L�X�g�擾
    [SerializeField] private Text text;
    //���b�Ԋu�ŕ������\������邩�����߂�
    [SerializeField] private float letterPerSecond;

    //0.1�b��1�������\������悤�ȃR���[�`��
    public IEnumerator TypeDialog(string line)
    {
        //�e�L�X�g�����
        text.text = "";

        //�ꕶ�������b�Z�[�W��\��
        foreach (char letter in line)
        {
            text.text += letter;

            yield return new WaitForSeconds(letterPerSecond);

        }
    }
}
