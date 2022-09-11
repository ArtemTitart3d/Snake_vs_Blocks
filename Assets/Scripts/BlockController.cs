using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

public class BlockController : MonoBehaviour
{
    public TextMeshPro BlockStrengthText;
    private int BlockStrength;
    private float BlockColor;
    [SerializeField] private int _blockStrengthMin;
    [SerializeField] private int _blockStrengthMax;
    [SerializeField] private GameObject _block;
    [SerializeField] private ParticleSystem _expload;
    [SerializeField] private AudioSource _brakeBlock;

    void SetBlockCount()
    {
        BlockStrength = Random.Range(_blockStrengthMin, _blockStrengthMax + 1);
        BlockStrengthText.text = BlockStrength.ToString();
        BlockColor = (float)_blockStrengthMin / ((float)_blockStrengthMax + 1) * (float)BlockStrength;
        var BlockMaterial = _block.GetComponent<Renderer>().material;
        BlockMaterial.SetFloat("ColorCount", BlockColor);
    }

    private void Awake()
    {
        SetBlockCount();
        var ExploadMaterial = _expload.GetComponent<Renderer>().material;
        ExploadMaterial.SetFloat("ColorCount", BlockColor);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out SnakeMovement Snake))
        {
            if (BlockStrength < Snake.Length)
            {
                
                Snake.ReduceLenght(BlockStrength);
                Snake.HitTheBlock(BlockStrength);
                _expload.Play();
                _brakeBlock.Play();
                Destroy(_block);
                Destroy(BlockStrengthText);
                
                
            }
            else
            {
                Snake.Die();    
            }
            

        }
        
    }

}
