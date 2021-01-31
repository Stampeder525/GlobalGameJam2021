using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelCustomizer : MonoBehaviour
{
    public SkinnedMeshRenderer skinRenderer;
    public List<Material> skinMaterials;
    public List<Material> clothMaterials;

    private Material skinMaterial;
    private Material clothMaterial;

    public void Start()
    {
        Material[] mats = skinRenderer.materials;
        mats[0] = clothMaterials[Random.Range(0, clothMaterials.Count)];
        mats[1] = skinMaterials[Random.Range(0, skinMaterials.Count)];

        skinRenderer.materials = mats;
    }
}
