using UnityEngine;
using UnityEngine.UI;

public class BallHealt : MonoBehaviour
{
    private BallControl bControl;
    private void Start()
    {
        bControl= GetComponent<BallControl>();
    }
    public void TakeDamage(int _amount)
    {
       BallControl.healt -= _amount;
       bControl.UpdateTexts(bControl.healtText.gameObject.name);
    }

    public void IncreaseHealt(int _amount , int _timeAmount)
    {
        if(BallControl.healt < 5) 
        BallControl.healt += _amount;
        
        BallControl.timeCounter += _timeAmount;
        bControl.UpdateTexts(bControl.healtText.gameObject.name);
    }

    public bool IsDead()
    {
        bool val = true;

        if (BallControl.healt == 0)
        {
            val = false;
        }
        else
        {
            val = true;
        }

        return val;
    }
}
