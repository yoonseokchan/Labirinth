using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class EnemyEditor : MonoBehaviour
{
    public Sprite demonSprite;
    public Sprite jellySprite;
    public Sprite wolfSprite;
    public Sprite chestSprite;

    private Enemy.Type previousType;

    private void Update()
    {
        Enemy enemy = GetComponent<Enemy>();
        Enemy.Type type = enemy.type;

        if ( type != previousType )
        {
            previousType = type;
            SpriteRenderer sr = GetComponent<SpriteRenderer>();

            switch (type)
            {
                case Enemy.Type.Demon:
                    sr.sprite = demonSprite;
                    break;

                case Enemy.Type.Jelly:
                    sr.sprite = jellySprite;
                    break;

                case Enemy.Type.Wolf:
                    sr.sprite = wolfSprite;
                    break;

                case Enemy.Type.Chest:
                    sr.sprite = chestSprite;
                    break;
            }
        }
    }
}
