using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoulUpGrade : MonoBehaviour {

    public GameObject targetSlot;
    public GameObject equipSlot;
    public GameObject ValueChang;
    public UILabel soulValue;
    void Awake()
    {
        //for (int i = 0; i < jewelBtn.Length; i++)
        //{
        //    jewelBtn[i] = GameObject.Find("EquipSlot" + i);
        //}
        //for (int i = 0; i < equipBtn.Length; i++)
        //{
        //    equipBtn[i] = GameObject.Find("Stone" + i);
        //}
    }

	void Start ()
    {

	}
	

	void Update ()
    {
		
	}

    public void SoulUp()
    {
        if (targetSlot == null)
        {
            ValueChang.SetActive(false);
        }
        if (equipSlot == null)
        {
            ValueChang.SetActive(false);
        }
        EffectSoundManager.iNstance.audios.clip = EffectSoundManager.iNstance.effectClip[0];
        EffectSoundManager.iNstance.audios.PlayOneShot(EffectSoundManager.iNstance.audios.clip);
        if (targetSlot != null && targetSlot.GetComponent<JewelBtn>().soulItem != null && MoneyManager.inStance.soulCount >= MoneyManager.inStance.stoneReinFoecValue[targetSlot.GetComponent<JewelBtn>().soulItem.GetComponent<SoulStone>().soulSkillNumber])
        {
            ValueChang.SetActive(true);
            if (SoulSkillManager.INSTANCE.stoneReinforce[targetSlot.GetComponent<JewelBtn>().soulItem.GetComponent<SoulStone>().soulSkillNumber] < 5)
            {
                SoulSkillManager.INSTANCE.stoneReinforce[targetSlot.GetComponent<JewelBtn>().soulItem.GetComponent<SoulStone>().soulSkillNumber] += 1;
                targetSlot.GetComponent<JewelBtn>().soulItem.GetComponent<SoulStone>().lvLabel[targetSlot.GetComponent<JewelBtn>().soulItem.GetComponent<SoulStone>().soulSkillNumber].text = "  " + SoulSkillManager.INSTANCE.stoneReinforce[targetSlot.GetComponent<JewelBtn>().soulItem.GetComponent<SoulStone>().soulSkillNumber].ToString();
                MoneyManager.inStance.soulCount -= MoneyManager.inStance.stoneReinFoecValue[targetSlot.GetComponent<JewelBtn>().soulItem.GetComponent<SoulStone>().soulSkillNumber];
                MoneyManager.inStance.stoneReinFoecValue[targetSlot.GetComponent<JewelBtn>().soulItem.GetComponent<SoulStone>().soulSkillNumber] *= 2;
                soulValue.text = MoneyManager.inStance.FoMatCount(MoneyManager.inStance.stoneReinFoecValue[targetSlot.GetComponent<JewelBtn>().soulItem.GetComponent<SoulStone>().soulSkillNumber]).ToString();
                if (SoulSkillManager.INSTANCE.stoneReinforce[targetSlot.GetComponent<JewelBtn>().soulItem.GetComponent<SoulStone>().soulSkillNumber] >= 5)
                {
                    targetSlot.GetComponent<JewelBtn>().soulItem.GetComponent<SoulStone>().lvLabel[targetSlot.GetComponent<JewelBtn>().soulItem.GetComponent<SoulStone>().soulSkillNumber].text = "Max";
                    soulValue.text = " Max";
                }
                //SoulSkillManager.INSTANCE.SaveSoulStone();
            }
        }
        if (equipSlot != null && equipSlot.GetComponent<EquipSlotBtn>().item != null && MoneyManager.inStance.soulCount>= MoneyManager.inStance.stoneReinFoecValue[equipSlot.GetComponent<EquipSlotBtn>().item.GetComponent<SoulStone>().soulSkillNumber])
        {
            ValueChang.SetActive(true);
            if (SoulSkillManager.INSTANCE.stoneReinforce[equipSlot.GetComponent<EquipSlotBtn>().item.GetComponent<SoulStone>().soulSkillNumber] < 5)
            {
                SoulSkillManager.INSTANCE.stoneReinforce[equipSlot.GetComponent<EquipSlotBtn>().item.GetComponent<SoulStone>().soulSkillNumber] += 1;
                equipSlot.GetComponent<EquipSlotBtn>().item.GetComponent<SoulStone>().lvLabel[equipSlot.GetComponent<EquipSlotBtn>().item.GetComponent<SoulStone>().soulSkillNumber].text = "  " + SoulSkillManager.INSTANCE.stoneReinforce[equipSlot.GetComponent<EquipSlotBtn>().item.GetComponent<SoulStone>().soulSkillNumber].ToString();
                MoneyManager.inStance.soulCount -= MoneyManager.inStance.stoneReinFoecValue[equipSlot.GetComponent<EquipSlotBtn>().item.GetComponent<SoulStone>().soulSkillNumber];
                MoneyManager.inStance.stoneReinFoecValue[equipSlot.GetComponent<EquipSlotBtn>().item.GetComponent<SoulStone>().soulSkillNumber] *= 2;
                soulValue.text = MoneyManager.inStance.FoMatCount(MoneyManager.inStance.stoneReinFoecValue[equipSlot.GetComponent<EquipSlotBtn>().item.GetComponent<SoulStone>().soulSkillNumber]).ToString();
                if (SoulSkillManager.INSTANCE.stoneReinforce[equipSlot.GetComponent<EquipSlotBtn>().item.GetComponent<SoulStone>().soulSkillNumber] >= 5)
                {
                    equipSlot.GetComponent<EquipSlotBtn>().item.GetComponent<SoulStone>().lvLabel[equipSlot.GetComponent<EquipSlotBtn>().item.GetComponent<SoulStone>().soulSkillNumber].text = "Max";
                    soulValue.text = " Max";
                }
                //SoulSkillManager.INSTANCE.SaveSoulStone();
            }
        }
    }
}
