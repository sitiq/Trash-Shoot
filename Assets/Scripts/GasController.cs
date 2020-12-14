using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GasController : MonoBehaviour,IPointerDownHandler, IPointerUpHandler
{
  

    private bool pointerDown;
    private float pointerDownTimer;

    public UnityEvent onLongClick;
    private Animator _animator;
    private static GasController _instance;
    public static GasController Instance { get { return _instance; } }
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
        Reset();
        pointerDown = true;
        Debug.Log("OnPointerDown");
        _animator.SetBool("IsGassClicked",true);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Reset();
        pointerDown = false;
        Debug.Log("OnPointerUp");
        _animator.SetBool("IsGassClicked",false);
    }

    private void Reset()
    {
        pointerDown = false;
        pointerDownTimer = 0;
    }
}
