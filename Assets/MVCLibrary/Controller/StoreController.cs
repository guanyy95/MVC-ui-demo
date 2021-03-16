using System.Collections;
using System.Collections.Generic;
using Game.Model;
using UnityEngine;

namespace Game.Controller
{
    public class StoreController : Singleton<StoreController>
    {
        // 将View数据保存到Model类
        public void SaveProp(Prop prop)
        {
            StoreModel.Instance.Add(prop);
        }

        public Prop GetProp(int id)
        {
            return StoreModel.Instance.propDic[id];
        }
    }
}

