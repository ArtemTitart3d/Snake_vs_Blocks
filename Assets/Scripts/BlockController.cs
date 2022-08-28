using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class BlockController : MonoBehaviour
{
    public TextMeshPro BlockStrengthText;
    private int BlockStrength;
    [SerializeField] private int _blockStrengthMin;
    [SerializeField] private int _blockStrengthMax;
    [SerializeField] private GameObject _block;
    
    void SetBlockCount()
    {
        BlockStrength = Random.Range(_blockStrengthMin, _blockStrengthMax + 1);
        BlockStrengthText.text = BlockStrength.ToString();
        float BlockColor = (float)_blockStrengthMin / ((float)_blockStrengthMax + 1) * (float)BlockStrength;
        var BlockMaterial = _block.GetComponent<Renderer>().material;
        BlockMaterial.SetFloat("ColorCount", BlockColor);
    }

    private void Awake()
    {
        SetBlockCount();
    }


}
