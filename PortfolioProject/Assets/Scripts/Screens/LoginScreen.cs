using Kborod.Model;
using Kborod.UI.UIScreenManager;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Kborod.UI.Screens
{
    [UIScreen("UI/Screens/LoginScreen.prefab", true)]
    public class LoginScreen : UIScreenBase
    {
        [SerializeField] private TMP_InputField _inputfield;
        [SerializeField] private Button _loginButton;

        private AccountModel _accountModel;

        [Inject]
        public void Construct(AccountModel accountModel)
        {
            _accountModel = accountModel;
        }

        private void Start()
        {
            _inputfield.onValueChanged.AddListener(value => RefreshButtonInteractable());
            _loginButton.onClick.AddListener(LoginClickHandler);

            RefreshButtonInteractable();
        }

        private void OnDestroy()
        {
            _inputfield.onValueChanged.RemoveAllListeners(); 
            _loginButton.onClick.RemoveAllListeners();
        }

        private void RefreshButtonInteractable()
        {
            _loginButton.interactable = _inputfield.text.Length > 0;
        }

        private void LoginClickHandler()
        {
            var name = _inputfield.text;
            _accountModel.Login(name);
        }
    }
}
