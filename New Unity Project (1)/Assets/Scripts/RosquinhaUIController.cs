using System;
using UnityEngine;
using TMPro;

public class RosquinhaUIController : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private TMP_Text rosquinhasText;

    private void OnEnable()
    {
        PlayerObserverManager.OnRosquinhasChanged += UpdateRosquinhasText;
    }

    private void OnDisable()
    {
        PlayerObserverManager.OnRosquinhasChanged -= UpdateRosquinhasText;
    }

    private void UpdateRosquinhasText(int newRosquinhasValue)
    {
        rosquinhasText.text = newRosquinhasValue.ToString();
    }
}
