using METANIT_Dialogs.Services;
using System;

namespace METANIT_Dialogs.Models
{
    public class Model
    {
        public string MText { get;  set; }
        IDialogService _dialogService;
        internal Model(IDialogService dialogService)
        {
            _dialogService = dialogService;
            dialogService.LoadTextEvent += (s, e) => ChangeText?.Invoke(this, e);
        }
       // private void OnChangeText (string str) => ChangeText?.Invoke (this, str);
        public event EventHandler<string>? ChangeText;
        public bool ExistsPath => _dialogService.ExistsPath;
        public void LoadText() => _dialogService.LoadText();
        public void SaveText(string text) => _dialogService.SaveText(text);
        public void SaveAsText(string text) => _dialogService.SaveAsText(text);
        public void ClearText() => ChangeText?.Invoke(this, string.Empty);
    }
}
