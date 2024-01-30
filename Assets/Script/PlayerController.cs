using System.Collections;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    public float jumpForce = 5f;

    public TextMeshProUGUI nb_AbilityText;
    public int maxSpecialUses = 3;
    private int specialUses = 0;
    private int nb_Ability = 3 ;
    private bool isAactive = false;
    private int scorePointsAbility = 9;

    private Animator anim;

    private void Start()
    {
        nb_AbilityText.text = "" + nb_Ability;
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector2(rb.velocity.x, 0f);
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }

        if (Input.GetKeyDown(KeyCode.B) && specialUses < maxSpecialUses)
        {
            StartCoroutine(StopVerticalMovement());
        }
    }

    IEnumerator StopVerticalMovement()
    {
        anim.Play("Dance");
        isAactive = true;
        specialUses++;
        nb_Ability --;
        rb.constraints = (RigidbodyConstraints2D)RigidbodyConstraints.FreezePosition;
        if (specialUses == maxSpecialUses)
        {
            nb_AbilityText.text = "0";
        }
        else
        {
            nb_AbilityText.text = "" + nb_Ability;
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
                    scoreManager.IncreaseScore(scorePointsAbility);
                }
            }
        }
 
    }
}
