using METANIT_Dialogs.Services;
using System;

namespace METANIT_Dialogs.Models
{
    public class Model
    {
        public string? MText { get; set; }
        IDialogService _dialogService;
        internal Model(IDialogService dialogService)
        {
            _dialogService = dialogService;
            dialogService.LoadTextEvent += (s, e) => OnChangeText(e);
        }
        private void OnChangeText(string str)
        {
            MText = str;
            ChangeText?.Invoke(this, str);
        }
        public event EventHandler<string>? ChangeText;
        public bool ExistsPath => _dialogService.ExistsPath;
        public void LoadText()
        {
            if (!_dialogService.LoadText()) _dialogService.ShowMessage("Документ не загружен");
        }

        public void SaveText(string MText) => _dialogService.SaveText(MText);


        public void SaveAsText(string MText)
        {
            if (!_dialogService.SaveAsText(MText)) _dialogService.ShowMessage("Документ не сохранён");
        }    
        public void ClearText() => OnChangeText(string.Empty);
    }
}
