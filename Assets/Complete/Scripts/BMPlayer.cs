using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BMPlayer : MonoBehaviour
{
    public int bombs = 2;
    public float moveSpeed = 5f;
    public GameObject bombPrefab;

    public bool canMove = true;
    public bool canDrop = true;

    private Transform myTransform;
    private Rigidbody rigidBody;
    private Animator animator;

    void Start()
    {
        myTransform = transform;
        rigidBody = GetComponent<Rigidbody>();
        animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        PlayerMove();
    }

    void PlayerMove()
    {
        animator.SetBool("Walking", false);
        if (!canMove)
            return;

        if (Input.GetKey(KeyCode.W))
        {
            rigidBody.velocity = new Vector3(rigidBody.velocity.x, rigidBody.velocity.y, moveSpeed);
            myTransform.rotation = Quaternion.Euler(0, 0, 0);
            animator.SetBool("Walking", true);
        }

        if (Input.GetKey(KeyCode.A))
        {
            rigidBody.velocity = new Vector3(-moveSpeed, rigidBody.velocity.y, rigidBody.velocity.z);
            myTransform.rotation = Quaternion.Euler(0, -90, 0);
            animator.SetBool("Walking", true);
        }

        if (Input.GetKey(KeyCode.S))
        {
            rigidBody.velocity = new Vector3(rigidBody.velocity.x, rigidBody.velocity.y, -moveSpeed);
            myTransform.rotation = Quaternion.Euler(0, 180, 0);
            animator.SetBool("Walking", true);
        }

        if (Input.GetKey(KeyCode.D))
        {
            rigidBody.velocity = new Vector3(moveSpeed, rigidBody.velocity.y, rigidBody.velocity.z);
            myTransform.rotation = Quaternion.Euler(0, 90, 0);
            animator.SetBool("Walking", true);
        }

		if (Input.GetKeyDown(KeyCode.Space))
		{
            DropBomb();
        }
    }

    void DropBomb()
    {
        if (bombPrefab)
        {
            Vector3 bombPos = new Vector3(Mathf.RoundToInt(myTransform.position.x), myTransform.position.y, Mathf.RoundToInt(myTransform.position.z));
            var go = Instantiate(bombPrefab, bombPos, bombPrefab.transform.rotation);
        }
    }
}
