using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    public int curHp;
    public int maxHP;
    public int coins;
    public int damage = 1;
    public bool hasKey;
    public Color hitColor = Color.red;
    public float hitColorDuration = 0.2f;

    
    public SpriteRenderer sr;

    public LayerMask moveLayerMask;
    public LayerMask attackLayerMask;

    void Move(Vector2 dir)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, dir, 1.0f, moveLayerMask);

        if (hit.collider == null)
        {
            transform.position += new Vector3(dir.x, dir.y, 0);
        }
    }

    public void OnMoveUp(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            Debug.Log("Move LEFT");
            Move(Vector2.up);
        }
    }
    public void OnMoveDown(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            Debug.Log("Move LEFT");
            Move(Vector2.down);
        }
    }
    public void OnMoveLeft(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            Debug.Log("Move LEFT");
            Move(Vector2.left);
        }
    }
    public void OnMoveRight(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            Debug.Log("Move LEFT");
            Move(Vector2.right);
        }
    }
    public void OnAttackUp(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            Debug.Log("Attack UP");
            TryAttack(Vector2.up);
        }
    }
    public void OnAttackDown(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            Debug.Log("Attack DOWN");
            TryAttack(Vector2.down);
        }
    }
    public void OnAttackLeft(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            Debug.Log("Attack LEFT");
            TryAttack(Vector2.left);
        }
    }
    public void OnAttackRight(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            Debug.Log("Attack RIGHT");
            TryAttack(Vector2.right);
        }
    }

    void TryAttack(Vector2 dir)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, dir, 1.0f, attackLayerMask);

        if (hit.collider != null)
        {
            hit.transform.GetComponent<Enemy>().TakeDamage(damage);
        }
    }

    public void TakeDamage(int damageToTake)
    {
        curHp -= damageToTake;

        StartCoroutine(DamageFlash());

        if (curHp <= 0)
        { SceneManager.LoadScene(0); }

    }


    IEnumerator DamageFlash()
    {
        Color defaultColor = sr.color;
        sr.color = hitColor;

        yield return new WaitForSeconds(hitColorDuration);

        sr.color = defaultColor;
    }
}
