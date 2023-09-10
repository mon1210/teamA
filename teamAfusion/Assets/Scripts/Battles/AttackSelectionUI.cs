using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSelectionUI : MonoBehaviour
{
    //�킴���X�g�̈ʒu���̎擾
    [SerializeField] RectTransform movesParent;
    //�e�L�X�gPrefab�̎擾
    [SerializeField] SelectableText moveTextPrefab;
    //�q�v�f��SelectableText�����X�g��
    List<SelectableText> selectableTexts = new List<SelectableText>();


    //�I������Ă���v�f�̃C���f�b�N�X
    int selectedIndex;

    //selectedIndex���擾�ł���悤��
    public int SelectedIndex { get => selectedIndex; }



    //�����Ɋ܂܂�Ă���q�v�f���擾����֐�
    public void Init(List<Move> moves)
    {
        //�q�v�f��SelectableText���擾     prefab�����O�Ɏ擾���悤�Ƃ���
        //selectableTexts = GetComponentsInChildren<SelectableText>();
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

        //���X�g�̐����e�L�X�gprefab�����[�v����
        for(int i = 0; i < moves.Count; i++)
        {
            //�킴prefab�𐶐�
            SelectableText moveText = Instantiate(moveTextPrefab, movesParent);
            //�e�L�X�g�ɋZ�����Z�b�g
            moveText.SetMoveName(moves[i].Base.Name);
            //selectableText�ɐ��������킴prefab��ǉ�
            selectableTexts.Add(moveText);

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
        selectedIndex = Mathf.Clamp(selectedIndex, 0, selectableTexts.Count - 1);

        //�I������Ă���e�L�X�g�̐F�ύX
        for (int i = 0; i < selectableTexts.Count; i++)
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
