using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarBodyScript : MonoBehaviour
{
    private int bottleTriggerCount = 0;
    private int newsPaperTriggerCount = 0;
    private int cansTriggerCount = 0;
    private Animator _animator;
    private bool isFinished;
    private static CarBodyScript _instance;

    public static CarBodyScript Instance
    {
        get { return _instance; }
    }

    void Start()
    {
        bottleTriggerCount = 0;
        newsPaperTriggerCount = 0;
        cansTriggerCount = 0;
        _animator = GetComponent<Animator>();
        isFinished = false;

    }

    void Update()
    {
        int count = GetTrashTriggerCount()/100;
        if (count == 2)
        {
            _animator.SetInteger("TrashScore",1);
        }
        else if (count == 6)
        {
            _animator.SetInteger("TrashScore",2);
            
        }else if (count == 10)
        {
            _animator.SetInteger("TrashScore",3);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        other.gameObject.SetActive(false);
    
        if (other.gameObject.CompareTag("Bottle"))
        {
            bottleTriggerCount += 1;
        }

        else if (other.gameObject.CompareTag("Newspaper"))
        {
            newsPaperTriggerCount += 1;
        }

        else if (other.gameObject.CompareTag("Cans"))
        {
            cansTriggerCount += 1;
        }
        else if (other.gameObject.CompareTag("Finish"))
        {
            isFinished = true;
        }
    }
    
    public bool IsFinished()
    {
        return isFinished;
    }
    
    public int GetTrashTriggerCount()
    {
        Debug.Log(bottleTriggerCount.ToString() + " " + newsPaperTriggerCount.ToString() + " " + cansTriggerCount.ToString());
        return (bottleTriggerCount + newsPaperTriggerCount + cansTriggerCount) * 100;
    }
    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }
    
    
    public int[] GetTrashTriggerCountArr()
    {
        int[] result = {bottleTriggerCount,newsPaperTriggerCount,cansTriggerCount};
        return result;
    }
    
}
