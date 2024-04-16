using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hud : MonoBehaviour
{
    public Text kill;

    public Text time;

    public Text level;

    public Slider exp;

    public Slider health;

    public Image gameWin;

    private AudioSource audioSource;

    public AudioClip winClip;
    
    private bool isWin = false;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        kill.text = GameManager.instance.kill.ToString();
        level.text = GameManager.instance.level.ToString();

        float curExp = GameManager.instance.exp;
        float maxExp =
            GameManager.instance.nextExp[
                Mathf.Min(GameManager.instance.level, GameManager.instance.nextExp.Length - 1)];
        exp.value = curExp / maxExp;
        health.value = GameManager.instance.health / 100;

        float remainTime = GameManager.instance.maxGameTime - GameManager.instance.gameTime;
        int min = Mathf.FloorToInt(remainTime / 60);
        int sec = Mathf.FloorToInt(remainTime % 60);
        time.text = string.Format("{0:D2}:{1:D2}", min, sec);

        if (remainTime <= 1.5f && !isWin)
        {
            audioSource.PlayOneShot(winClip);
            isWin = true;
        }

        if (remainTime <= 1)
        {
            gameWin.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
    }
}