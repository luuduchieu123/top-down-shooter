using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    public Transform player;
    public Vector2 lastPlayerPosition;
    public float bgUpdateThreshold;
    public int bgWidth;
    public int bgHeight;

    public List<GameObject> bgList;



    private void Start()
    {
        lastPlayerPosition = transform.position;

        for (int y = 0; y < 2; y++)
        {
            for (int x = 0; x < 2; x++)
            {
                bgList[x + y * 2].transform.position = new Vector2(x * bgWidth - bgWidth / 2, y * bgHeight - bgHeight / 2);
            }
        }



    }

    private void Update()
    {
        if (Vector2.Distance(player.position, lastPlayerPosition) > bgUpdateThreshold)
        {
            lastPlayerPosition = player.position;
            int posX = Mathf.RoundToInt(player.position.x / bgWidth);
            int posY = Mathf.RoundToInt(player.position.y / bgHeight);

            for (int y = 0; y < 2; y++)
            {
                for (int x = 0; x < 2; x++)
                {
                    bgList[x + y * 2].transform.position = new Vector2((posX + x) * bgWidth - bgWidth / 2, (posY + y) * bgHeight - bgHeight / 2);
                }
            }
        }
    }
}



  

