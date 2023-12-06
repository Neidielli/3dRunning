using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScriptUI : MonoBehaviour
{
    public scriptPlayer player;
    public TextMeshProUGUI pointsText;
    public TextMeshProUGUI shotsText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        pointsText.text = player.points.ToString();
        shotsText.text = player.shots.ToString();
    }
}
