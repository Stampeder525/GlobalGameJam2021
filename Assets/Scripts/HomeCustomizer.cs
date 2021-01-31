using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeCustomizer : MonoBehaviour
{
    public List<Material> homeMaterials;
    private MeshRenderer[] renderers;

    private void Start()
    {
        renderers = GetComponentsInChildren<MeshRenderer>();
        SetRandomHomeMaterial();
    }

    public MeshRenderer[] GetHomeRendererList()
    {
        return renderers;
    }

    public void UpdateHomeMaterials(Material material)
    {
        foreach(MeshRenderer renderer in renderers)
        {
            renderer.material = material;
        }
    }

    public void SetRandomHomeMaterial()
    {
        UpdateHomeMaterials(homeMaterials[Random.Range(0, homeMaterials.Count)]);
    }
}
