using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;

    private bool isMoving;

    private Vector2 input;

    private Animator animator;

    public LayerMask solidObjectsLayer;

    public LayerMask interactableLayer;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    // James: How is this being called? Why not use the standard unity Update?
    public void HandleUpdate()
    {
       //  Debug.Log(isMoving);
        if (!isMoving)
        {
            input.x = Input.GetAxisRaw("Horizontal");
            input.y = Input.GetAxisRaw("Vertical");

            // Debug.Log("this is input.x" + input.x);
            // Debug.Log("this is input.y" + input.y);
            if (input.x != 0)
            {
                input.y = 0;
            }

            if (input != Vector2.zero)
            {
                animator.SetFloat("moveX", input.x);
                animator.SetFloat("moveY", input.y);

                var targetPos = transform.position;
                targetPos.x += input.x;
                targetPos.y += input.y;

                if (IsWalkable(targetPos)){
                    StartCoroutine(Move(targetPos));
                } else {
                    Debug.Log("Not walkable!");
                }
            }
        }

        animator.SetBool("isMoving", isMoving);

        if (Input.GetKeyDown(KeyCode.Z)){
            Interact();
        }
    }

    void Interact()
    {
        var facingDir =
            new Vector3(animator.GetFloat("moveX"), animator.GetFloat("moveY"));
        var interactPos = transform.position + facingDir;

        // Debug.DrawLine(transform.position, interactPos, Color.red, 1f);
        var collider = Physics2D.OverlapCircle(interactPos, 0.2f, interactableLayer);
        if (collider != null)
        {
            collider.GetComponent<Interactable>()?.Interact();
        }
    }

    IEnumerator Move(Vector3 targetPos)
    {
        
        // Identical behaviour as >Epsilon but 1. Reduces bouncing and 2. Doesn't randomly break for some fucking reason
        while ((targetPos - transform.position).sqrMagnitude > 0.005f)//Mathf.Epsilon)
        {
            Debug.Log(targetPos);
            Debug.Log(transform.position);
            isMoving = true;
            transform.position =
                Vector3
                    .MoveTowards(transform.position,
                    targetPos,
                    moveSpeed * Time.deltaTime);
            yield return null;
        }
        transform.position = targetPos;
        Debug.Log((targetPos - transform.position).sqrMagnitude);

        isMoving = false;
        
    }

    private bool IsWalkable(Vector3 targetPos)
    {
        if (Physics2D.OverlapCircle(targetPos, 0.2f, solidObjectsLayer | interactableLayer) != null)
        {
            return false;
        }
        return true;
    }
}
