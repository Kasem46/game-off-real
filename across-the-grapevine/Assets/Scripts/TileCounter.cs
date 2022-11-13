using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TileCounter : MonoBehaviour
{

    public Text forkDownCounter; public Text forkRightCounter; public Text forkLeftCounter; public Text forkUpCounter; public Text downRightCornerCounter; public Text downLeftCornerCounter; public Text upLeftCornerCounter; public Text upRightCornerCounter; public Text fourWayCounter; public Text verticalLineCounter; public Text lineHorizontalCounter; //don't you love declaring variables
    public int forkDownCounterNumber; public int forkRightCounterNumber; public int forkLeftCounterNumber; public int forkUpCounterNumber; public int downRightCornerCounterNumber; public int downLeftCornerCounterNumber; public int upLeftCornerCounterNumber; public int upRightCornerCounterNumber; public int fourWayCounterNumber; public int verticalLineCounterNumber; public int lineHorizontalCounterNumber;

    public Text[] texts;
    public int[] numbers;

    // Start is called before the first frame update
    void Start()
    {
        texts = new Text[] { forkDownCounter, forkRightCounter, forkLeftCounter, forkUpCounter, downRightCornerCounter, downLeftCornerCounter, upLeftCornerCounter, upRightCornerCounter, fourWayCounter, verticalLineCounter, lineHorizontalCounter };
        numbers = new int[] { forkDownCounterNumber, forkRightCounterNumber, forkLeftCounterNumber, forkUpCounterNumber, downRightCornerCounterNumber, downLeftCornerCounterNumber, upLeftCornerCounterNumber, upRightCornerCounterNumber, fourWayCounterNumber , verticalLineCounterNumber , lineHorizontalCounterNumber };
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < numbers.Length; i++){
            texts[i].text = "X " + numbers[i];
        }
    }

    public void RemoveTile(int i) {
        numbers[i] -= 1;
    }

}
