using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DataBase;
using UnityEngine;

namespace Building
{
    public class Building
    {
       
        public string LangCode { get; set; }
        public Vector3 Position { get; set; }
        public BuildCondition Condition { get; set; } = BuildCondition.Empty;
        public int Lvl { get; set; }
        public bool BuildMode { get; set; } = false;
        public List<Product> prodsInWork { get; set; } = new List<Product>();
        public Dictionary<string, int> readyProds { get; set; } = new Dictionary<string, int>(); //string is LangCode, int is count

        public void AddProduction(string receptLangCode)
        {
            if (IsCanToProduction(receptLangCode))
            {
                var recept = Memory.Recepts.First(x => x.LangCode == receptLangCode);
                foreach (var key in recept.Requirements.Keys)
                {
                    Memory.Player.Ingredients[key] -= recept.Requirements[key];
                }

                prodsInWork.Add(new Product(recept.LangCode, 1, prodsInWork.LastOrDefault()?.EndTime ?? DateTime.Now,
                    recept.Time));
            }
        }
        public bool IsCanToProduction(string receptLangCode)
        {
            if (prodsInWork.Count < Lvl+1)
            {
                var recept = Memory.Recepts.First(x=>x.LangCode == receptLangCode);
                foreach (var key in recept.Requirements.Keys)
                {
                    if (!Memory.Player.Ingredients.ContainsKey(key) || Memory.Player.Ingredients[key] < recept.Requirements[key])
                    {
                        return false;
                    }
                }
                return true;
            }
            return false;
        }
        public void TakeProductsToPlayer()
        {
            foreach (var key in readyProds.Keys)
            {
                Memory.Player.AddIngredients(key, readyProds[key]);
            }
            readyProds = new Dictionary<string, int>();
        }
        public void CheckProds()
        {
            List<Product> tempProd = new List<Product>();
            prodsInWork.ForEach((prod)=>{
                if (prod.EndTime <= DateTime.Now)
                {
                    tempProd.Add(prod);
                }
            });
            tempProd.ForEach((prod) =>
            {
                prodsInWork.Remove(prod);
                if (!readyProds.ContainsKey(prod.LangCode)) readyProds.Add(prod.LangCode, 0);
                readyProds[prod.LangCode] += prod.Count;
            });
            
        }

        public IEnumerator CheckProductCoroutine()
        {
            while (true)
            {
                CheckProds();
                yield return new WaitForSeconds(1f);
            }
        }

        public string CheckTime()
        {
            string timeText = null;
            var product = prodsInWork.FirstOrDefault();
            TimeSpan? result = product?.EndTime - DateTime.Now;
            TimeSpan resForText = new TimeSpan(result?.Hours ?? 0, result?.Minutes ?? 0, result?.Seconds ?? 0);
            TimeSpan nulTimeSpan = new TimeSpan(0, 0, 0);
            if (resForText < nulTimeSpan)
            {
                resForText = nulTimeSpan;
            }
            timeText = resForText.ToString();
            
            return timeText;
        }

        public GameObject GetPrefab()
        {
            return Memory.BuildingPrefabs[LangCode][Lvl];
        }
        
    }
}
