using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControllerScipt : MonoBehaviour
{
    public Animator GasAnimator;
    public Animator RemAnimator;
    public GameObject GameOverPanel;
    public GameObject FinishPanel;
    public Text scoreText;
    public Text scoreGameOverText;
    public Text bottleText;
    public Text cansText;
    public Text newspaperText;
    public Text resultText;
    public Text scoreFinishText;
    private int score = 0;
    private GasController _gasController;
    private CarBodyScript _carBody;
    private RemController _remController;
    private CarController _carController;
    private GroundController _groundController;
    private int countDown = 90;
    private int nextUpdate = 1;
    private bool isGameOver = false;
    public Text timer;

    private double PRICE_BOTTLE = 2500;
    private double PRICE_CANS= 500;
    private double PRICE_NEWSPAPER= 1500;
    
    // Start is called before the first frame update
    void Start()
    {
        _gasController = GasController.Instance;
        _remController = RemController.Instance;
        _carController = CarController.Instance;
        _carBody = CarBodyScript.Instance;
        _groundController = GroundController.Instance;
        GameOverPanel.SetActive(false);
        FinishPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        if (!isGameOver && !_carBody.IsFinished())
        {
            isGameOver = _groundController.IsCarUpTriggered();
            
            score = _carBody.GetTrashTriggerCount();
            scoreText.text = "Score :\n" + score.ToString();
            FindObjectOfType<AudioManagerScript>().PlaySound("gameOver");

            
            if (_gasController.IsPointerDown())
            {
                Debug.Log("Car Moving Forward");
                _carController.MoveForward(_gasController.GetPointerDownTimer());
            }
            else if (_remController.IsPointerDown())
            {
                Debug.Log("Car Moving Backward");
                _carController.MoveBackward(_remController.GetPointerDownTimer());
            }
            else
            {
                // _carController.MoveForward(0);
            }
        
            if(Time.time>=nextUpdate){
                nextUpdate=Mathf.FloorToInt(Time.time)+1;
                UpdateEverySecond();
            }
        }else
        {
			_carController.ClearTorque();
			
			if(isGameOver)
            {
                scoreGameOverText.text = "Score : " + score.ToString();
                GameOverPanel.SetActive(true);
            }

            if (_carBody.IsFinished())
            {
                //        int[] result = {bottleTriggerCount,newsPaperTriggerCount,cansTriggerCount};
                int[] scoreArr = _carBody.GetTrashTriggerCountArr();
                
                /*
                 *     public Text scoreGameOverText;
                        public Text bottleText;
                        public Text cansText;
                        public Text newspaperText;
                        public Text resultText;
                        public Text scoreFinishText;
                            private double PRICE_CANS= 500;
    private double PRICE_NEWSPAPER= 1.500;
                 */

                bottleText.text = "Botol : " + scoreArr[0].ToString() + "(kg) x Rp " + PRICE_BOTTLE.ToString() + " = Rp " +
                                  ((double) scoreArr[0] * PRICE_BOTTLE).ToString();
                newspaperText.text = "Koran : " + scoreArr[1].ToString() + "(kg) x Rp " + PRICE_NEWSPAPER.ToString() + " = Rp " +
                                     ((double) scoreArr[1] * PRICE_NEWSPAPER).ToString();
                cansText.text = "Kaleng : " + scoreArr[2].ToString() + "(kg) x Rp " + PRICE_CANS.ToString() + " = Rp " +
                                ((double) scoreArr[2] * PRICE_CANS).ToString();
                scoreFinishText.text = "Score : " + score.ToString();
                resultText.text = "Total Rp " + ((((double) scoreArr[0] * PRICE_BOTTLE))
                                                 + (((double) scoreArr[1] * PRICE_NEWSPAPER))
                                                 + (((double) scoreArr[2] * PRICE_CANS))).ToString();
                FinishPanel.SetActive(true);
            }
		}
    }
    public void RetryGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
    public void BackToMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }
    void UpdateEverySecond()
    {
        countDown--;
        timer.text = "Waktu Tersisa : \n" + countDown.ToString();
    }

}
