using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillManager : MonoBehaviour {

    public GameObject[] skill;
    
    public GameObject manaMG;
    public GameObject player;
    public GameObject maincamera;
    public UISprite[] skillImage;
    public UILabel[] skillcostLabel;
    public float skillmo;
    public float statetime;
    public bool skillstart = false;
    public Dictionary<int, string> skillIcon;
    public GameObject bm;


    void Start ()
    {
        bm = GameObject.Find("BeefManager");
        skillIcon = new Dictionary<int, string>();
        manaMG = GameObject.Find("ManaManager");
        player = GameObject.Find("Player");
        maincamera = GameObject.Find("Main Camera");
        skillIcon.Add(0, "Stone0");
        skillIcon.Add(1, "Stone1");
        skillIcon.Add(2, "Stone2");
        skillIcon.Add(3, "Stone3");
        skillIcon.Add(4, "Stone4");
        skillIcon.Add(5, "Stone5");
        skillIcon.Add(6, "Stone6");
        skillIcon.Add(7, "Stone7");
        skillIcon.Add(8, "Stone8");
        for (int i = 0; i < SoulSkillManager.INSTANCE.soulskillNunber.Count; i++)
        {
            if (SoulSkillManager.INSTANCE.soulskillNunber[i] >-1 && SoulSkillManager.INSTANCE.skillCostValue[i]>-1)
            {
                skillImage[i].GetComponent<UISprite>().spriteName = skillIcon[SoulSkillManager.INSTANCE.soulskillNunber[i]];
                skillImage[i].gameObject.SetActive(true);
                skillcostLabel[i].text = SoulSkillManager.INSTANCE.skillCostValue[i].ToString();
            }
        }
     }
	
	void Update ()
    {
        if(skillstart == true)
        {
            player.GetComponent<PlayerController>().moveSpeed = 0;
            maincamera.GetComponent<MainCameraMove>().cameraSpeed = 0;
            statetime += Time.deltaTime;
            if (statetime > skillmo)
            {
             
                player.GetComponent<PlayerController>().playstate = PlayerController.PLAYSTATE.NONE;
                skillstart = false;
                statetime = 0;
                player.GetComponent<PlayerController>().moveSpeed = 0.4f;
                maincamera.GetComponent<MainCameraMove>().cameraSpeed = 0.4f;
            }
        }               
	}

    public void Skill1()
    {
        if (manaMG.GetComponent<ManaManager>().manaCount >= SoulSkillManager.INSTANCE.skillCostValue[0])
        {
            EffectSoundManager.iNstance.audios.clip = EffectSoundManager.iNstance.effectClip[0];
            EffectSoundManager.iNstance.audios.PlayOneShot(EffectSoundManager.iNstance.audios.clip);
            manaMG.GetComponent<ManaManager>().manaCount -= SoulSkillManager.INSTANCE.skillCostValue[0];
            //manaMG.GetComponent<ManaManager>().manaCount -= skill[SoulSkillManager.INSTANCE.soulskillNunber[0]].GetComponent<Bullet>().skillCost;
            manaMG.GetComponent<ManaManager>().manaGauge.transform.localScale -= new Vector3(SoulSkillManager.INSTANCE.skillCostValue[0] / manaMG.GetComponent<ManaManager>().manaMax * 360, 0, 0);

            if (skill[SoulSkillManager.INSTANCE.soulskillNunber[0]].GetComponent<Bullet>().skills != Bullet.SKILLS.CONVERT || skill[SoulSkillManager.INSTANCE.soulskillNunber[0]].GetComponent<Bullet>().skills != Bullet.SKILLS.HILL)
            {
                Instantiate(skill[SoulSkillManager.INSTANCE.soulskillNunber[0]], new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation);
            }
            if (skill[SoulSkillManager.INSTANCE.soulskillNunber[0]].GetComponent<Bullet>().skills == Bullet.SKILLS.CONVERT)
            {
                if (bm.GetComponent<BeefManager>().beefCount < 90)
                {
                    bm.GetComponent<BeefManager>().beefCount += skill[SoulSkillManager.INSTANCE.soulskillNunber[0]].GetComponent<Bullet>().skillAtk;
                }
            }
            if (skill[SoulSkillManager.INSTANCE.soulskillNunber[0]].GetComponent<Bullet>().skills == Bullet.SKILLS.HILL)
            {
                Instantiate(skill[SoulSkillManager.INSTANCE.soulskillNunber[0]], new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z), player.transform.rotation);
            }

            if (skill[SoulSkillManager.INSTANCE.soulskillNunber[0]].GetComponent<Bullet>().skills == Bullet.SKILLS.THUNDERSTORM)
            {
                EffectSoundManager.iNstance.audios.clip = EffectSoundManager.iNstance.effectClip[3];
                EffectSoundManager.iNstance.audios.PlayOneShot(EffectSoundManager.iNstance.audios.clip);
            }

            skillstart = true;
        }
    }   

    public void Skill2()
    {
        if (manaMG.GetComponent<ManaManager>().manaCount >= SoulSkillManager.INSTANCE.skillCostValue[1])
        {
            EffectSoundManager.iNstance.audios.clip = EffectSoundManager.iNstance.effectClip[0];
            EffectSoundManager.iNstance.audios.PlayOneShot(EffectSoundManager.iNstance.audios.clip);
            manaMG.GetComponent<ManaManager>().manaCount -= SoulSkillManager.INSTANCE.skillCostValue[1];
            manaMG.GetComponent<ManaManager>().manaGauge.transform.localScale -= new Vector3(SoulSkillManager.INSTANCE.skillCostValue[1] / manaMG.GetComponent<ManaManager>().manaMax * 360, 0, 0);

            if (skill[SoulSkillManager.INSTANCE.soulskillNunber[1]].GetComponent<Bullet>().skills != Bullet.SKILLS.CONVERT || skill[SoulSkillManager.INSTANCE.soulskillNunber[1]].GetComponent<Bullet>().skills != Bullet.SKILLS.HILL )
            {
                Instantiate(skill[SoulSkillManager.INSTANCE.soulskillNunber[1]], new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation);
            }
            if (skill[SoulSkillManager.INSTANCE.soulskillNunber[1]].GetComponent<Bullet>().skills == Bullet.SKILLS.CONVERT)
            {
                if (bm.GetComponent<BeefManager>().beefCount < 90)
                {
                    bm.GetComponent<BeefManager>().beefCount += skill[SoulSkillManager.INSTANCE.soulskillNunber[1]].GetComponent<Bullet>().skillAtk;
                }
            }

            if(skill[SoulSkillManager.INSTANCE.soulskillNunber[1]].GetComponent<Bullet>().skills==Bullet.SKILLS.HILL)
            {
                Instantiate(skill[SoulSkillManager.INSTANCE.soulskillNunber[1]], new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z), player.transform.rotation);
            }

            if (skill[SoulSkillManager.INSTANCE.soulskillNunber[1]].GetComponent<Bullet>().skills == Bullet.SKILLS.THUNDERSTORM)
            {
                EffectSoundManager.iNstance.audios.clip = EffectSoundManager.iNstance.effectClip[3];
                EffectSoundManager.iNstance.audios.PlayOneShot(EffectSoundManager.iNstance.audios.clip);
            }



            skillstart = true;

        }
    }
    public void Skill3()
    {
        if (manaMG.GetComponent<ManaManager>().manaCount >= SoulSkillManager.INSTANCE.skillCostValue[2])
        {
            EffectSoundManager.iNstance.audios.clip = EffectSoundManager.iNstance.effectClip[0];
            EffectSoundManager.iNstance.audios.PlayOneShot(EffectSoundManager.iNstance.audios.clip);
            manaMG.GetComponent<ManaManager>().manaCount -= SoulSkillManager.INSTANCE.skillCostValue[2];
            manaMG.GetComponent<ManaManager>().manaGauge.transform.localScale -= new Vector3(SoulSkillManager.INSTANCE.skillCostValue[2] / manaMG.GetComponent<ManaManager>().manaMax * 360, 0, 0);
            if (skill[SoulSkillManager.INSTANCE.soulskillNunber[2]].GetComponent<Bullet>().skills != Bullet.SKILLS.CONVERT || skill[SoulSkillManager.INSTANCE.soulskillNunber[2]].GetComponent<Bullet>().skills != Bullet.SKILLS.HILL || skill[SoulSkillManager.INSTANCE.soulskillNunber[2]].GetComponent<Bullet>().skills != Bullet.SKILLS.THUNDERSTORM)
            {
                Instantiate(skill[SoulSkillManager.INSTANCE.soulskillNunber[2]], new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation);
            }
            if (skill[SoulSkillManager.INSTANCE.soulskillNunber[2]].GetComponent<Bullet>().skills == Bullet.SKILLS.CONVERT)
            {
                if (bm.GetComponent<BeefManager>().beefCount < 90)
                {
                    bm.GetComponent<BeefManager>().beefCount += skill[SoulSkillManager.INSTANCE.soulskillNunber[2]].GetComponent<Bullet>().skillAtk;
                }
            }

            if (skill[SoulSkillManager.INSTANCE.soulskillNunber[2]].GetComponent<Bullet>().skills == Bullet.SKILLS.HILL)
            {
                Instantiate(skill[SoulSkillManager.INSTANCE.soulskillNunber[2]], new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z), player.transform.rotation);
            }


            if (skill[SoulSkillManager.INSTANCE.soulskillNunber[2]].GetComponent<Bullet>().skills == Bullet.SKILLS.THUNDERSTORM)
            {
                EffectSoundManager.iNstance.audios.clip = EffectSoundManager.iNstance.effectClip[3];
                EffectSoundManager.iNstance.audios.PlayOneShot(EffectSoundManager.iNstance.audios.clip);
            }


            skillstart = true;
        }
    }

}
