using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutSceneDialog : MonoBehaviour
{
    public Dictionary<int, string> dialogDict = new Dictionary<int, string>();

    private void Start()
    {
        dialogDict.Add(101, " 환영합니다! \n");
        dialogDict.Add(102, " 당신은 수상한 식당에서 \n 일하게 된 직원입니다.");
        dialogDict.Add(103, " 1번 미션은 \"서빙\"입니다. \n");
        dialogDict.Add(104, " 캐릭터를 움직여, \n NPC에게 음식을 가져다 주세요.");
        dialogDict.Add(105, " 키보드 화살표 : 바라보기, 이동 \n F : 상호작용");

        dialogDict.Add(301, " 1번 미션을 무사히 통과하셨네요! \n");
        dialogDict.Add(302, " 바로 다음 단계로 넘어가도록 하겠습니다. \n");
        dialogDict.Add(303, " 2번 미션은 \"요리\"입니다. \n");
        dialogDict.Add(304, " 음식을 고르고, F를 연타해 \n 요리를 완성해서 문 밖으로 보내주세요.");
        dialogDict.Add(305, " 키보드 화살표 : 바라보기, 이동 \n Q or E : 선택, F : 상호작용");

        dialogDict.Add(501, " 요리까지 해낸 당신은 \n 오너가 될 자격이 있습니다.");
        dialogDict.Add(502, " 마지막 단계를 통해 \n 자격을 증명해주세요.");
        dialogDict.Add(503, " 3번 미션은 \"재료 주문\"입니다. \n");
        dialogDict.Add(504, " 주어진 예산 안에서 \n 필요한 재료를 주문해 주세요.");
        dialogDict.Add(505, " 키보드 화살표 : 수량 증감, \n F : 주문");

        dialogDict.Add(701, " 20XX년 XX월 XX일. \n");
        dialogDict.Add(702, " 이 식당, 뭔가 이상하다. \n");
        dialogDict.Add(703, " 홍보는 안하는데, \n 항상 손님이 찾아온다.");
        dialogDict.Add(704, " 그것도 항상 같은 사람들이. \n");
        dialogDict.Add(705, " 특별히 맛있지는 않은 것 같은데...\n");
        dialogDict.Add(706, " 어ㅈ제 내가 뭘 먹었더라...? \n 갑자기 나도 배가 고프다.");
        dialogDict.Add(707, " 소ㄴ..소시지.. \n ㅃㅕ..가루치즈...");

        dialogDict.Add(711, " 20XX년 XX월 XX일. \n");
        dialogDict.Add(712, " 이 식당, 아무래도 이상하다. \n");
        dialogDict.Add(713, " 도대체 그런 재료는 \n 누가 어디서 구해오는 거지?");
        dialogDict.Add(714, " 생각만 해도 구역질이 난다. \n 손가락이랑 저민 살, 뼛가루라니...");
        dialogDict.Add(715, " 이런 공간이 세상에 존재해서는 안된다.\n");
        dialogDict.Add(716, " 내가 피해자가 될지도 모르는데...\n");
        dialogDict.Add(717, " ...일은 그만두자. \n");
        dialogDict.Add(718, " 그리고 빠른 시일 내에 \n 경찰에 신고해야 한다.");
    }
}
