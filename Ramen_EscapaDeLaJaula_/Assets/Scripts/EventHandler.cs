using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using UnityEngine.Video;

public class EventHandler : MonoBehaviour
{
    public static Dictionary<Variable, int> Variables = new Dictionary<Variable, int>();
    public GameObject pelota;


    

    void Awake()
    {
        foreach (Variable variable in Enum.GetValues(typeof(Variable)))
        {
            if (!Variables.ContainsKey(variable))
            {
                Variables.Add(variable, 0);

            }
        }
    }

    void Update()
    {
        CheckValues();
    }

    private void CheckValues()
    {

        if (Variables[Variable.bolaEjercicio] > 0)
        {
            pelota.SetActive(true);
        }
        else
        {
            pelota.SetActive(false);
        }
       
    }
    public void Salida(GameObject videoPrefab, VideoClip videoClip,GameObject UI)
    {

        GameObject video;
        videoPrefab.GetComponentInChildren<VideoPlayer>().clip = videoClip;
        video = Instantiate(videoPrefab);
        long totalFrames = video.GetComponentInChildren<VideoPlayer>().frameCount.ConvertTo<long>();
        StartCoroutine(CheckFrames(video,totalFrames,UI));

    }

    private IEnumerator CheckFrames(GameObject video, long frameCount,GameObject UI)
    {
        long currentFrame = video.GetComponentInChildren<VideoPlayer>().frame;
        while (currentFrame <=frameCount - 2 )
        {
            if (Variables[Variable.final_sad] <= 0 && Variables[Variable.final_happy] <= 0)
            {
                UI = GameObject.FindGameObjectWithTag("UI");
                if (UI == null)
                {
                    break;
                }
            }
              currentFrame = video.GetComponentInChildren<VideoPlayer>().frame;
                yield return null;
            
           

            
        }
        Destroy(video);
        if (Variables[Variable.final_sad] > 0 || Variables[Variable.final_happy] > 0)
        {
            
            ReStartUI();
        }

    }

    private void ResetGame()
    {
       
        foreach (Variable variable in Enum.GetValues(typeof(Variable)))
        {           
                Variables[variable] = 0;           
        }
    }
    public void ReStartUI()
    {
        ResetGame();

        SceneManager.LoadScene("SampleScene");
    }
          
    
}
