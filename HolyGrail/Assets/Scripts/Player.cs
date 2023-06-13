using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 4;

    private Animator animator;
    private Item holdItem;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 moveDir = Vector3.zero;

        if (Input.GetKey(KeyCode.UpArrow))
        {
            moveDir += Vector3.up;
            animator.Play("Hero_Up");
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            moveDir += Vector3.down;
            animator.Play("Hero_Down");
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            moveDir += Vector3.left;
            animator.Play("Hero_Left");
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            moveDir += Vector3.right;
            animator.Play("Hero_Right");
        }

        transform.position += moveDir * Time.deltaTime * moveSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var item = collision.gameObject.GetComponent<Item>();
        if (item != null)
        {
            ProcessItem(item);
        }

        var enemy = collision.gameObject.GetComponent<Enemy>();
        if (enemy != null)
        {
            ProcessEnemy(enemy);
        }
    }

    void ProcessItem(Item item)
    {
        if (holdItem == null)
        {
            holdItem = item;

            holdItem.transform.parent = transform;
            holdItem.transform.localPosition = Vector3.zero;

            holdItem.GetComponent<BoxCollider2D>().enabled = false;
        }
    }

    void ProcessEnemy(Enemy enemy)
    {
        if (holdItem != null)
        {
            var item = holdItem.GetComponent<Item>();

            int itemType = (int)item.type;
            int enemyType = (int)enemy.type;

            if (itemType == enemyType)
            {
                Destroy(holdItem.gameObject);
                holdItem = null;

                Destroy(enemy.gameObject);
            }
        }
    }
}
