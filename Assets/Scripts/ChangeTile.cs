using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ChangeTile : MonoBehaviour {

	public TileBase[] currentTiles;
	public TileBase[] newTiles;
	public Type playerState;
	
	private Tilemap tileMap;

	// Use this for initialization
	void Start () {
		tileMap = GetComponent<Tilemap>();
	}

	public void ChangeTiles()
	{
		for (int i = 0; i < currentTiles.Length; i++)
		{
			tileMap.SwapTile(currentTiles[i], newTiles[i]);
		}
	}
}
