using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RandomizeAnimationLocation : MonoBehaviour
{

    //protected Animation anim;
    protected Vector3 pos, nextpos;
    protected float topLimit, botLimit, leftLimit, rightLimit;
    public bool rotate;

    protected Animator animator;


    // Use this for initialization
    virtual protected void Start()
    {
        setupLimits();
        animator = GetComponent<Animator>();
        //anim = GetComponent<Animation>();
        pos = new Vector3(0, 0, 0);
        transform.position = pos;
        if (rotate)
        {
            Vector3 rot = transform.rotation.eulerAngles;
            transform.rotation = Quaternion.Euler(rot.x, rot.y, Random.Range(315, 45));
        }
        AnimationChangePosition();
    }

    virtual public void ChangePosition()
    {

        //Compute position for next time
        nextpos = new Vector3(Random.Range(rightLimit, leftLimit), Random.Range(topLimit, botLimit), 0);
        transform.position = nextpos;

    }

    public void AnimationChangePosition()
    {
        StartCoroutine(Wait());
    }

    IEnumerator Wait()
    {
        animator.ResetTrigger("Play");
        ChangePosition();
        yield return new WaitForSeconds(Random.Range(0.2f, 2.0f));
        animator.SetTrigger("Play");
    }

    protected virtual void setupLimits()
    {
        this.topLimit = Screen.height;
        this.botLimit = 0;
        this.leftLimit = 0;
        this.rightLimit = Screen.width;
    }
}