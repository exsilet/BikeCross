using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SkillPoint : MonoBehaviour
{
    [SerializeField] private GameObject _star;

    public event UnityAction<GameObject> StartSkill;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Player player))
        {
            _star.SetActive(false);
            StartSkill?.Invoke(_star);
        }
    }
}
