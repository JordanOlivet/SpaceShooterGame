using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 movementInput;

    private List<RaycastHit2D> collisions;

    #region Public Fields

    public float collisionOffset = 0.05f;
    public ContactFilter2D movementFilter;

    #endregion

    public float BaseMoveSpeed = 1;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        collisions = new List<RaycastHit2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        if (movementInput != Vector2.zero)
        {
            Debug.Log("movementInput != zero");
            int collisionCount = rb.Cast(movementInput, movementFilter, collisions, BaseMoveSpeed * Time.fixedDeltaTime + collisionOffset);

            if (collisionCount == 0)
            {
                rb.MovePosition(rb.position + BaseMoveSpeed * Time.fixedDeltaTime * movementInput);
            }
        }
    }

    void OnMove(InputValue movementValue)
    {
        movementInput = movementValue.Get<Vector2>();
    }
}
