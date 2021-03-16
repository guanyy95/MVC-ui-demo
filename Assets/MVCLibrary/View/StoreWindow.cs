using System.Collections;
using System.Collections.Generic;
using Game.Controller;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Game.View
{
    public class StoreWindow : BaseWindow
    {
        public StoreWindow()
        {
            resName = "UI/Window/StoreWindow";
            resident = true;
            _selfType = WindowType.StoreWindow;
            _sceneType = SceneType.Login;
        }
    
        protected override void Awake()
        {
            base.Awake();
        }
    
        protected override void RegisterUIEvent()
        {
            base.RegisterUIEvent();
            foreach (var button in buttonList)
            {
                switch (button.name)
                {
                    case "BuyButton":
                        button.onClick.AddListener(OnBuyButtonClick);
                        break;
                }
            }
        }
    
        private void OnBuyButtonClick()
        {
            Debug.Log("BuyButton 点击了！");
            StoreController.Instance.SaveProp(new Prop());
            // var prop = StoreController.Instance.GetProp(1001);
        }
    
        protected override void OnAddListener()
        {
            base.OnAddListener();
        }
    
        protected override void OnRemoveListener()
        {
            base.OnRemoveListener();
        }
    
        protected override void OnEnable()
        {
            base.OnEnable();
        }
    
        protected override void OnDisable()
        {
            base.OnDisable();
        }
    
        protected override void Update(float deltaTime)
        {
            base.Update(deltaTime);
            if (Input.GetKeyDown(KeyCode.C))
            {
                Close();
            }
        }
    }
}

