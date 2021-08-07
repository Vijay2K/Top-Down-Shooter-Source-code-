using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissolveEffect : MonoBehaviour
{
    [SerializeField] private float dissolveSpeed = 1f;
    [SerializeField] private Renderer[] renderers;

    private float dissolveValue = 1f;

    public IEnumerator Dissolve() {
        yield return new WaitForSeconds(3f);

        dissolveValue -= Time.deltaTime * dissolveSpeed;
        foreach(Renderer renderer in renderers) {
            renderer.material.SetFloat("Dissolve", dissolveValue);
        }
    }
}
