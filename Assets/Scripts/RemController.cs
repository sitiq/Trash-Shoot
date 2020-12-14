using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class RemController  : MonoBehaviour,IPointerDownHandler, IPointerUpHandler
{
    private static RemController _instance;

    public static RemController Instance { get { return _instance; } }

    private bool pointerDown;
    private float pointerDownTimer;

    public UnityEvent onLongClick;
    private Animator _animator;
    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        } else {
            _instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        _animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (pointerDown)
        {
            pointerDownTimer += Time.deltaTime;
        }
    }

    public bool IsPointerDown()
    {
        return this.pointerDown;
    }

    public float GetPointerDownTimer()
    {
        return pointerDownTimer;
    }
    
    public void OnPointerDown(PointerEventData eventData)
    {
        pointerDown = true;
        Debug.Log("OnPointerDown");
        _animator.SetBool("IsBrakeClicked",true);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Reset();
        pointerDown = false;
        Debug.Log("OnPointerUp");
        _animator.SetBool("IsBrakeClicked",false);
    }

    private void Reset()
    {
        pointerDown = false;
        pointerDownTimer = 0;
    }
}
