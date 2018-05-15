using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneManager : MonoBehaviour
{
    public FadeImage currentImage;
    public FadeImage nextImage;
    //public DialogueTrigger[] dialogues;
    public bool isAutoRun;
    public int stateNow;
    public bool isTimeToNextScene;
    //public SceneEnum nextScene;
    // Use this for initialization
    void Start()
    {
        isTimeToNextScene = false;
    }
    void Update()
    {
        if (isAutoRun)
        {
            StartCutscene();
            isAutoRun = false;
        }
        if (isTimeToNextScene)
        {
            StartCoroutine(checkNextScene(2f));
        }
    }
    IEnumerator checkNextScene(float duration)
    {
        isTimeToNextScene = false;
        yield return new WaitForSeconds(duration);
        NextCutscene();
    }
    IEnumerator waitBothFadeOut(float duration)
    {
        isTimeToNextScene = false;
        yield return new WaitForSeconds(duration);
        BothFadeOut();
        isTimeToNextScene = true;
    }
    void StartCutscene()
    {
        //dialogues[0].SelectDialogue();
    }

    void OnEnable()
    {
        //DialogueState.Instance.OnStateChange += CutsceneFlow;
    }

    void OnDisable()
    {
        //DialogueState.Instance.OnStateChange -= CutsceneFlow;
    }

    void CutsceneFlow(string state)
    {
        if (state == "startCutScene")
        {
            currentImage.FadeOut(2f);
            currentImage.ChangeSourceImage(0);
            currentImage.FadeIn(2f);
        }
        if (state == "afterfirst")
        {
            DirectFadeImage(stateNow);
            StartCoroutine(waitBothFadeOut(2f));
        }
        if (state == "endScene")
        {
            currentImage.gameObject.SetActive(false);
            nextImage.gameObject.SetActive(false);
            //GamePhase.Instance.ChangePhase("Phase0");

            //SceneLoader.Instance.ChangeToScene(nextScene.ToString());
        }
    }

    void NextCutscene()
    {
        if (stateNow + 1 < currentImage.sprites.Length)
        {
            stateNow = stateNow + 1;
            currentImage.ChangeSourceImage(stateNow);
            //dialogues[stateNow].SelectDialogue();
            currentImage.FadeIn(1f);
        }
    }
    void DirectFadeImage(int index)
    {
        nextImage.ChangeSourceImage(index);
        nextImage.FadeIn(1f);
        currentImage.FadeOut(1f);
    }
    void BothFadeOut()
    {
        currentImage.FadeOut(1f);
        nextImage.FadeOut(1f);
    }
}
