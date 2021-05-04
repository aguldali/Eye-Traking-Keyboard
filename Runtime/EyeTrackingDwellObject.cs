using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Microsoft.MixedReality.Toolkit.Input;

[RequireComponent(typeof(EyeTrackingTarget))]
public class EyeTrackingDwellObject : MonoBehaviour
{
    EyeTrackingTarget _eyeTrackingTarget;
    
    [Range(0, 10)]
    public float dwellTimer;

    float timerReset;

    [SerializeField]
    bool dwellCompleted = false;

    [SerializeField]
    Image dwellImage;

    [SerializeField]
    [FormerlySerializedAs("OnDwellEndsAction")]
    private UnityEvent onDwellEndsAction = null;

    public UnityEvent OnDwellEndsAction
    {
        get { return onDwellEndsAction; }
        set { onDwellEndsAction = value; }
    }

    private void Start()
    {
        _eyeTrackingTarget = GetComponent<EyeTrackingTarget>();
        timerReset = dwellTimer;
    }

    private void Update()
    {
        if (_eyeTrackingTarget.IsDwelledOn == true && dwellCompleted == false)
        {
            dwellTimer -= Time.deltaTime;
            dwellImage.fillAmount += Time.deltaTime * (1 / timerReset);
            if(dwellTimer <= 0f)
            {
                dwellCompleted = true;
                dwellImage.fillAmount = 0;
                OnDwellEndsAction.Invoke();
            }
        }
        else if(_eyeTrackingTarget.IsDwelledOn == false)
        {
            dwellCompleted = false;
            dwellTimer = timerReset;
            dwellImage.fillAmount = 0;
        }
    }


}
