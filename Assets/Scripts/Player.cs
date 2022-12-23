using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    public int curHp;
    public int maxHp;
    public int coins;
    public int keys;
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
            transform.position += new Vector3(dir.x, dir.y, 0);
            EnemyManager.instance.OnPlayerMove();
            
    }

    public void OnMoveUp(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            Debug.Log("Move Up");
            Move(Vector2.up);
        }
    }
    public void OnMoveDown(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            Debug.Log("Move Down");
            Move(Vector2.down);
        }
    }
    public void OnMoveLeft(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            Debug.Log("Move Left");
            Move(Vector2.left);
        }
    }
    public void OnMoveRight(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            Debug.Log("Move Right");
            Move(Vector2.right);
        }
    }
    public void OnAttackUp(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            Debug.Log("Attack Up");
            TryAttack(Vector2.up);
        }
    }
    public void OnAttackDown(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            Debug.Log("Attack Down");
            TryAttack(Vector2.down);
        }
    }
    public void OnAttackLeft(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            Debug.Log("Attack Left");
            TryAttack(Vector2.left);
        }
    }
    public void OnAttackRight(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            Debug.Log("Attack Right");
            TryAttack(Vector2.right);
        }
    }

    void TryAttack(Vector2 dir)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, dir, 1.0f, attackLayerMask);

        if (hit.collider != null)
            hit.transform.GetComponent<Enemy>().TakeDamage(damage);
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
        if(sr.color == hitColor){
            sr.color = defaultColor;
        }
        
    }
    
    public void AddCoins(int amount)
    {
        coins += amount;
        // update the UI
    }

    public bool AddHealth(int amount)
    {
        if(curHp + amount <= maxHp)
        {
            curHp += amount;
            // update th UI
            return true;
        }

        return false;
    }
}
