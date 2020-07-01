using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkills : MonoBehaviour
{
    public Animator anim;
    public GameObject SkillPrefab;

    public AnimationClip SkillClip;
    private bool castingSkill = false;
    float castingSkillClipLength;
    public float skillCoolDown = 3;
    float skillCurrentTime = 0;
    bool skillCooldownActivated = false;


    // Start is called before the first frame update
    void Start()
    {
        if (SkillClip != null)
        {
            castingSkillClipLength = SkillClip.length;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (skillCooldownActivated)
        {
            skillCurrentTime += Time.deltaTime;
            if (skillCurrentTime >= skillCoolDown)
            {
                skillCooldownActivated = false;
                skillCurrentTime = 0;
            }
        }

        {
            if (Input.GetKeyDown(KeyCode.E) && !castingSkill && !skillCooldownActivated)
            {                
                CastSkillA();
            }
        }

        skillCurrentTime = Mathf.Clamp(skillCurrentTime, 0, skillCurrentTime);
    }

    void CastSkillA()
    {
          skillCooldownActivated = true;
          castingSkill = true;
          //Trigger the animation here
          anim.SetTrigger("CastSkillA");
          //Trigger the start animation events here
          StartCoroutine(CastingSkillA());
    }

    IEnumerator CastingSkillA()
    {
        yield return new WaitForSeconds(castingSkillClipLength);
        // trigger the stop animation events here
        castingSkill = false;
        GameObject explo = Instantiate(SkillPrefab , transform.position, transform.rotation);
    }

    void OnGUI()
    {
       // GUI.Button(new Rect(10, 40, 400, 30), "Press E to Cast a Skill. Skill current time: " + skillCurrentTime.ToString());
       // GUI.Button(new Rect(10, 70, 400, 30), "Skill A Cooldown Time: " + skillCoolDown.ToString());
    }
}
