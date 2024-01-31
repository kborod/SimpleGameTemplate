using Kborod.Model;
using Kborod.UI.UIScreenManager;
using TMPro;
using UnityEngine;
using Zenject;

namespace Kborod.UI.Screens
{
    [UIScreen("UI/Screens/GameScreen.prefab", true)]
    public class GameScreen : UIScreenBase
    {
        private const string HELLO_MESSAGE = "Hello, {0}!";

        [SerializeField] private TMP_Text _nameText;

        private AccountModel _accountModel;

        [Inject]
        public void Construct(AccountModel accountModel)
        {
            _accountModel = accountModel;
        }

        private void Start()
        {
            RefreshName();
        }

        private void RefreshName()
        {
            _nameText.text = string.Format(HELLO_MESSAGE, _accountModel.Name);
        }
    }
}
