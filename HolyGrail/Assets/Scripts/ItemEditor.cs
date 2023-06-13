using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class ItemEditor : MonoBehaviour
{
    public Sprite holySprite;
    public Sprite maceSprite;
    public Sprite swordSprite;
    public Sprite keySprite;

    private Item.Type previousType;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Item item = GetComponent<Item>();
        Item.Type type = item.type;

        if (type != previousType)
        {
            previousType = type;
            SpriteRenderer sr = GetComponent<SpriteRenderer>();

            switch (type)
            {
                case Item.Type.Holy:
                    sr.sprite = holySprite;
                    break;

                case Item.Type.Mace:
                    sr.sprite = maceSprite;
                    break;

                case Item.Type.Sword:
                    sr.sprite = swordSprite;
                    break;

                case Item.Type.Key:
                    sr.sprite = keySprite;
                    break;
            }
        }
    }
}
