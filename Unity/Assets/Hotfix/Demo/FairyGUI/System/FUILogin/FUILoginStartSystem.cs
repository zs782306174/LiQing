
using ETModel;
using UnityEngine;
using ETHotfix.FUIGlobal;
namespace ETHotfix
{
    [ObjectSystem]
    public class FUILoginStartSystem: StartSystem<FUILogin>
    {
        public override void Start(FUILogin self)
        {
            
            self.loginButton.self.onClick.Add(() => LoginBtnOnClick(self));
            self.registerButton.self.onClick.Add(() => RegisterBtnOnClick(self));
        }

        private void RegisterBtnOnClick(FUILogin self)
        {
            self.registerButton.self.visible = false;
            RegisterHelper.OnRegisterAsync(self.accountInput.text, self.passwordInput.text).Coroutine();
        }

        public void LoginBtnOnClick(FUILogin self)
        {
            self.loginButton.self.visible = false;
            LoginHelper.OnLoginAsync(self.accountInput.text, self.passwordInput.text).Coroutine();
        }
    }
    
}