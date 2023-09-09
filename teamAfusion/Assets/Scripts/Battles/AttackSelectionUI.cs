using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSelectionUI : MonoBehaviour
{
    //
    [SerializeField] RectTransform movesParent;
    //
    [SerializeField] SelectableText moveTextPrefab;
    //�擾�����q�v�f��SelectableText�̐����o��
    [SerializeField] SelectableText[] selectableTexts;


    //�I������Ă���v�f�̃C���f�b�N�X
    int selectedIndex;

    //selectedIndex���擾�ł���悤��
    public int SelectedIndex { get => selectedIndex; }


    //�����Ɋ܂܂�Ă���q�v�f���擾����֐�
    public void Init(List<Move> moves)
    {
        //�q�v�f��SelectableText���擾
        selectableTexts = GetComponentsInChildren<SelectableText>();
        setUISize(moves);
    }

    //�Z�̐��ɍ��킹��UI�̃T�C�Y��ς���֐�
    private void setUISize(List<Move> moves)
    {
        Vector2 uiSize = movesParent.sizeDelta;
        //UI�̃T�C�Y��y����(��)��50+100*�Z�̐����L�΂�
        uiSize.y = 50 + 100 * moves.Count;
        //�đ��
        movesParent.sizeDelta = uiSize;
        //���X�g�̐����e�L�X�gprefab�𐶐�
        for(int i = 0; i < moves.Count; i++)
        {
            SelectableText moveText = Instantiate(moveTextPrefab, movesParent);
            moveText.SetMoveName(moves[i].Base.Name);
        }
    }


    //�I�𒆂̃e�L�X�g�̐F��ύX����֐�
    public void ChangeTextColor()
    {
        //����͂ŏ�̃e�L�X�g�I��
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            selectedIndex--;
        }
        //�����͂ŉ��̃e�L�X�g�I��
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            selectedIndex++;
        }

        //index���e�L�X�g���𒴂��Ȃ��悤��
        selectedIndex = Mathf.Clamp(selectedIndex, 0, selectableTexts.Length - 1);

        //�I������Ă���e�L�X�g�̐F�ύX
        for (int i = 0; i < selectableTexts.Length; i++)
        {
            if (selectedIndex == i)
            {
                selectableTexts[i].SetSelectedColor(true);
            }
            else
            {
                selectableTexts[i].SetSelectedColor(false);
            }

        }
    }

    //UI��\�����邽�߂̊֐�
    public void OpenSelectionUI()
    {
        //0�ɏ�����
        selectedIndex = 0;
        //UI��\��
        gameObject.SetActive(true);

    }
    //UI����邽�߂̊֐�
    public void CloseSelectionUI()
    {
        //0�ɏ�����
        selectedIndex = 0;
        //UI�����
        gameObject.SetActive(false);

    }
}
