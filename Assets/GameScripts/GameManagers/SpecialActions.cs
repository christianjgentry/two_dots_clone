﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialActions : MonoBehaviour {

	#region  Singleton
  public static SpecialActions instance;
  private void Awake()
  {
    if (instance == null)
    {
      instance = this;
    }
  }

  #endregion
	

	public GameObject slotsParent;
	private List<TileSlot> tileSlots;
	ItemGeneratorController itemGenerator;
	void Start () {
		itemGenerator = ItemGeneratorController.instance;
		tileSlots = new List<TileSlot>(slotsParent.GetComponentsInChildren<TileSlot>());
	}
	
	public void ClearAllColor(ColorPalette color){
		itemGenerator.PreventColorSpawn(color);
		List<TileItem> tileItems = GetAllColor(color);
		foreach(TileItem item in tileItems){
			item.ClearItem();
		}
	}
	
	List<TileItem> GetAllColor(ColorPalette color){
		List<TileItem> tileItems = new List<TileItem>();
		foreach(TileSlot tileSlot in tileSlots){
			TileItem item = tileSlot.GetItem();
			if(item.itemColor==color) tileItems.Add(item);
		}
		return tileItems;
	}

	public void EmphasizeColor(ColorPalette color){
		List<TileItem> items = GetAllColor(color);
		foreach(TileItem tileItem in items){
			tileItem.EmphasizeItem();
		}
	}
}
