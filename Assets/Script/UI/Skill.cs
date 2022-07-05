using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skill : MonoBehaviour
{
    [SerializeField] private Image[] images;
    [SerializeField] private float changeTime;
    [SerializeField] private SkillPoint _skill;

    private void OnEnable()
    {
        _skill.StartSkill += OnValueChanged;
    }

    private void OnDisable()
    {
        _skill.StartSkill -= OnValueChanged;
    }

    private void OnValueChanged(GameObject skill)
    {
        if (skill)
        {
            StartCoroutine(ChangeSkill());
        }
    }

    private IEnumerator ChangeSkill()
    {
        int i = 0;
        float number = 0;
        float _numberOfScrolls = Random.Range(13, 24);

        while (number != _numberOfScrolls)
        {
            if (i < images.Length)
            {
                if (i == 0)
                {
                    images[i].gameObject.SetActive(true);
                }
            }

            var waitForOneSeconds = new WaitForSeconds(changeTime);
            yield return waitForOneSeconds;

            images[i].gameObject.SetActive(false);
            i++;

            if (i == images.Length)
            {
                i = 0;
                images[i].gameObject.SetActive(false);
            }
            else
            {
                images[i].gameObject.SetActive(true);
            }

            number += 1;
        }
    }
}
