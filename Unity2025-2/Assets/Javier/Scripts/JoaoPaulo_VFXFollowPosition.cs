using UnityEngine;
using UnityEngine.VFX;

public class JoaoPaulo_VFXFollowPosition : MonoBehaviour
{
    public Transform target; // jogador
    public Vector3 offset = new Vector3(0, 0.05f, 0);
    public float rayLength = 1.0f; // quanto �para baixo� checar
    public string groundTag = "ground";

    private bool vfxActive = true; // opcional: controlar ativa��o do VFX

    void LateUpdate()
    {
        if (target == null) return;

        RaycastHit hit;
        // lan�a um raio para baixo a partir da posi��o do jogador
        if (Physics.Raycast(target.position, Vector3.down, out hit, rayLength))
        {
            if (hit.collider.CompareTag(groundTag))
            {
                // s� ativa o VFX se tocar o ch�o
                transform.position = hit.point + offset;
                transform.rotation = Quaternion.identity; // mant�m perpendicular ao ch�o
                if (!vfxActive)
                {
                    GetComponentInChildren<VisualEffect>().Play();
                    vfxActive = true;
                }
                return;
            }
        }

        // se n�o tocar ch�o, pausa o VFX
        if (vfxActive)
        {
            GetComponentInChildren<VisualEffect>().Stop();
            vfxActive = false;
        }
    }
}
