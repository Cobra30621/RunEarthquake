using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Map
{
    public class MapHelper
    {
        public static List<MapObject> FindAllMapObject()
        {
            var mapObjects = Object.FindObjectsOfType<MapObject>();


            return mapObjects.ToList();
        }
        
        public static List<MapObject> FindMapObjectWithRow(int row)
        {
            var mapObjects = Object.FindObjectsOfType<MapObject>().ToList();

            return mapObjects.Where(x => x.Rows.Contains(row)).ToList();;
            
        }

        public static void DestroyAllItems()
        {
            var items = Object.FindObjectsOfType<Item>().ToList();
            foreach (var item in items)
            {
                Object.Destroy(item.gameObject);
            }
        }

    }
}