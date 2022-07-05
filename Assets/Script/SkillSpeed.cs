using RunnerMovementSystem;
using System.Collections;
using UnityEngine;

public class SkillSpeed : MonoBehaviour
{
    [SerializeField] private float changeTime;
    [SerializeField] private MovementSystem mover;

    private float _speedSecond;

    private void Start()
    {
        //_speedSecond = mover.CurrentSpeed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Player player))
        {
            Debug.Log("запусск ускорения");
            StartCoroutine(SpeedValueSecond());
        }
    }

    private IEnumerator SpeedValueSecond()
    {
        mover.CurrentSpeed *= 2;
        var waitForOneSeconds = new WaitForSeconds(changeTime);
        yield return waitForOneSeconds;

        //mover.CurrentSpeed = _speedSecond;
    }
}
