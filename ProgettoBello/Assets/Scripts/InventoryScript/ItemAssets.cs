using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAssets : MonoBehaviour
{
    public static ItemAssets Instance { get; private set; }
    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
    }
    public Transform pfItemWorld;
    // Update is called once per frame
    public Sprite KeySprite;
    public Sprite MapSprite;
    public Sprite PuzzleItem1Sprite;
    public Sprite PuzzleItem2Sprite;
}
