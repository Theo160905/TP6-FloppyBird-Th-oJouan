using System.Collections;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rb;
    private float _jumpForce = 10f;

    [SerializeField]
    private TextMeshProUGUI nb_AbilityText;
    private int _maxSpecialUses = 3;
    private int _specialUses = 0;
    private int _nb_Ability = 3 ;
    private bool isAactive = false;
    private int _scorePointsAbility = 9;

    private Animator anim;


    private void Start()
    {
        nb_AbilityText.text = "" + _nb_Ability;
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        if (Input.GetKeyDown(KeyCode.B) && _specialUses < _maxSpecialUses)
        {
            StartCoroutine(StopVerticalMovement());
        }
    }

    void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, 0f);
        rb.AddForce(new Vector2(0f, _jumpForce), ForceMode2D.Impulse);
    }

    IEnumerator StopVerticalMovement()
    {
        anim.Play("Dance");
        isAactive = true;
        _specialUses++;
        _nb_Ability --;
        rb.constraints = (RigidbodyConstraints2D)RigidbodyConstraints.FreezePosition;
        if (_specialUses == _maxSpecialUses)
        {
            nb_AbilityText.text = "0";
        }
        else
        {
            nb_AbilityText.text = "" + _nb_Ability;
        }
        yield return new WaitForSeconds(2f);
        rb.constraints = (RigidbodyConstraints2D)RigidbodyConstraints.None;
        rb.velocity = new Vector2(rb.velocity.x, 1f);
        anim.Play("Idle");
        isAactive = false;
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if ( isAactive == true)
        {
            if (collision.gameObject.CompareTag("Score"))
            {
                ScoreText scoreManager = FindObjectOfType<ScoreText>();
                if (scoreManager != null)
                {
                    scoreManager.IncreaseScore(_scorePointsAbility);
                }
            }
        }
 
    }
}
