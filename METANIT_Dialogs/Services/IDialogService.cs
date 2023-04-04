using System;

namespace METANIT_Dialogs.Services
{
    internal interface IDialogService
    {
        void ShowMessage(string message);   // показ сообщения
        bool LoadText();  // открытие файла
        bool SaveAsText(string str);  // сохранение файла
        bool SaveText(string str);  // сохранение файла по прежнему пути
        bool ExistsPath { get;  set; } // Существование пути к файлу
        public event EventHandler<string>? LoadTextEvent;
    }
}
