using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectOnHit : MonoBehaviour
{
    [SerializeField] private Animator animator;

    private void OnEnable()
    {
        float delay = animator.GetCurrentAnimatorStateInfo(0).length;
        StartCoroutine(DisableAfterTime(delay));
    }

    private IEnumerator DisableAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        EffectPooling.Instance.ReturnEffect(gameObject);
    }

}
