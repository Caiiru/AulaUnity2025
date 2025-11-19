using UnityEngine;

public class Juan_SemiTransparent : MonoBehaviour
{
    public float alpha = 0.5f; // transparência inicial (0 = invisível, 1 = opaco)
    private Material mat;

    void Start()
    {
        mat = GetComponent<Renderer>().material;

        // muda o modo do shader para Transparent
        mat.SetFloat("_Mode", 3); 
        mat.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
        mat.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
        mat.SetInt("_ZWrite", 0);
        mat.DisableKeyword("_ALPHATEST_ON");
        mat.EnableKeyword("_ALPHABLEND_ON");
        mat.DisableKeyword("_ALPHAPREMULTIPLY_ON");
        mat.renderQueue = 3000;

        // aplica a transparência
        Color cor = mat.color;
        cor.a = alpha;
        mat.color = cor;
    }
}

