using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutSceneDialog : MonoBehaviour
{
    public Dictionary<int, string> dialogDict = new Dictionary<int, string>();

    private void Start()
    {
        dialogDict.Add(101, " ȯ���մϴ�! \n");
        dialogDict.Add(102, " ����� ������ �Ĵ翡�� \n ���ϰ� �� �����Դϴ�.");
        dialogDict.Add(103, " 1�� �̼��� \"����\"�Դϴ�. \n");
        dialogDict.Add(104, " ĳ���͸� ������, \n NPC���� ������ ������ �ּ���.");
        dialogDict.Add(105, " Ű���� ȭ��ǥ : �ٶ󺸱�, �̵� \n F : ��ȣ�ۿ�");

        dialogDict.Add(301, " 1�� �̼��� ������ ����ϼ̳׿�! \n");
        dialogDict.Add(302, " �ٷ� ���� �ܰ�� �Ѿ���� �ϰڽ��ϴ�. \n");
        dialogDict.Add(303, " 2�� �̼��� \"�丮\"�Դϴ�. \n");
        dialogDict.Add(304, " ������ ����, F�� ��Ÿ�� \n �丮�� �ϼ��ؼ� �� ������ �����ּ���.");
        dialogDict.Add(305, " Ű���� ȭ��ǥ : �ٶ󺸱�, �̵� \n Q or E : ����, F : ��ȣ�ۿ�");

        dialogDict.Add(501, " �丮���� �س� ����� \n ���ʰ� �� �ڰ��� �ֽ��ϴ�.");
        dialogDict.Add(502, " ������ �ܰ踦 ���� \n �ڰ��� �������ּ���.");
        dialogDict.Add(503, " 3�� �̼��� \"��� �ֹ�\"�Դϴ�. \n");
        dialogDict.Add(504, " �־��� ���� �ȿ��� \n �ʿ��� ��Ḧ �ֹ��� �ּ���.");
        dialogDict.Add(505, " Ű���� ȭ��ǥ : ���� ����, \n F : �ֹ�");

        dialogDict.Add(701, " 20XX�� XX�� XX��. \n");
        dialogDict.Add(702, " �� �Ĵ�, ���� �̻��ϴ�. \n");
        dialogDict.Add(703, " ȫ���� ���ϴµ�, \n �׻� �մ��� ã�ƿ´�.");
        dialogDict.Add(704, " �װ͵� �׻� ���� �������. \n");
        dialogDict.Add(705, " Ư���� �������� ���� �� ������...\n");
        dialogDict.Add(706, " ��� ���� �� �Ծ�����...? \n ���ڱ� ���� �谡 ������.");
        dialogDict.Add(707, " �Ҥ�..�ҽ���.. \n ����..����ġ��...");
    }
}
