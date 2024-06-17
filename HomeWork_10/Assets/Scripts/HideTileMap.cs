using UnityEngine;
using UnityEngine.Tilemaps;

public class HideTileMap : MonoBehaviour
{
    private TilemapRenderer tilemap;

    public void Start()
    {
        tilemap = GetComponent<TilemapRenderer>();
        tilemap.enabled = false;
    }
}
