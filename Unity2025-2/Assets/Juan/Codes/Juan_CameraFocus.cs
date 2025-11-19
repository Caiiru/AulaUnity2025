using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class Juan_CameraFocus : MonoBehaviour
{
    public Transform target; // objeto a focar (ex: jogador)
    public Volume volume;
    private DepthOfField dof;

    void Start()
    {
        volume.profile.TryGet(out dof);
    }

    void Update()
    {
        if (dof != null && target != null)
        {
            float dist = Vector3.Distance(transform.position, target.position);
            dof.focusDistance.value = dist; // foca no jogador dinamicamente
        }
    }
}
