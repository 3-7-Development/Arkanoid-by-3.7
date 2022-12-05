using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class levelGenerator : MonoBehaviour
{

    public Texture2D map;
    public colorToPref[] colorMap;

    void Start()
    {
        generate();
    }

    void spawn(int x,int y)
    {
        Color pixel = map.GetPixel(x,y);

        if(pixel.a == 0)
        {
            return;
        }

        foreach(var color in colorMap)
        {
            if(color.color.Equals(pixel))
            {
                Vector2 pos= new Vector2(-13.51f+x*1.93f,-2.27f+y*0.55f);
                Instantiate(color.prefab,pos, Quaternion.identity);
            }
        }

    }

    void generate()
    {
        for(int x = 0 ; x < map.width; x++)
        {
            for(int y = 0; y < map.height; y++)
            {
                spawn(x, y);
            }
        }
    }

}
