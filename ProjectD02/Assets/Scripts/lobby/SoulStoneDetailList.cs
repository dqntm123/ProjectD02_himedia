using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulStoneDetailList : MonoBehaviour {

    public List<string> stoneDetailStr;

     void Start()
    {


        stoneDetailStr[0] = " WIND 전방의 적 1명을 밀쳐내며 데미지는 주지 않습니다";
        stoneDetailStr[1] = "COMET  전방 일정범위의 3명의 적에게 데미지를 줍니다.";
        stoneDetailStr[2] = "FIRE  전방의 일정범위내 모든적에게 데미지를 줍니다.";
        stoneDetailStr[3] = "POISON  전방의 1명의 적에게 독데미지를 줍니다.";
        stoneDetailStr[4] = "THUNDER STORM  범위 내의 모든적에게 일정시간동안 스턴을 걸며 데미지를 줍니다.";
        stoneDetailStr[5] = "CURSED HEAL  플레이어 주변의 미니언들에게 일정HP를 회복 시켜줍니다.";
        stoneDetailStr[6] = "CONVERT  일정 마나를 엘릭서로 변환 합니다.";
        stoneDetailStr[7] = "ICE  전방의 범위내에 있는적을 일정시간동안 얼리며 데미지는 주지 않습니다.";
        stoneDetailStr[8] = "BULLET  전방의 1명의 적에게 데미지를 줍니다.";

    }



}
