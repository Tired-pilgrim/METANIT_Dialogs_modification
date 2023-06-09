﻿using Microsoft.Win32;
using System;
using System.IO;
using System.Text;
using System.Windows;

namespace METANIT_Dialogs.Services
{
    internal class DefaultDialogService : IDialogService
    {
        private OpenFileDialog _openFileDialog;
        private SaveFileDialog _saveFileDialog;
        private readonly string TextFolder = Environment.CurrentDirectory + @"\Документы\";
        public DefaultDialogService() 
        {
            Directory.CreateDirectory(TextFolder);
            _openFileDialog = new()
            {
                Filter = "Текст(*.txt)|*.txt| Все файлы (*.*)|*.*",
                FileName = "Документ",
                DefaultExt = ".txt",
                InitialDirectory = TextFolder
            };
            _saveFileDialog = new()
            {
                Filter = "Текст(*.txt)|*.txt| Все файлы (*.*)|*.*",
                FileName = "Документ",
                DefaultExt = ".txt",
                InitialDirectory = TextFolder
            };

        }
        /// <summary>Есть ли путь для сохранения в файл</summary>
        public bool ExistsPath { get;  set; } = false;
        /// <summary>Текущий путь к файлу</summary>
        private string _currebtPath = string.Empty;
        public event EventHandler<string>? LoadTextEvent;
        public bool LoadText()
        {
            if (_openFileDialog.ShowDialog() == true)
            {
                ExistsPath = true;
                _currebtPath = _openFileDialog.FileName;
                LoadTextEvent?.Invoke(this, File.ReadAllText(_openFileDialog.FileName, Encoding.UTF8));
                return true; 
            }
            else
            {
                return false;
            }            
        }

        public bool SaveAsText(string str)
        {
            if (_saveFileDialog.ShowDialog() == true)
            {
                ExistsPath = true;
                _currebtPath = _saveFileDialog.FileName;
                return SaveText(str);
            }
            else
            {
                return false;
            }
        }
        public bool SaveText(string str)
        {
            if (_currebtPath != string.Empty)
            {
                File.WriteAllText(_currebtPath, str, Encoding.UTF8);
                return true;
            }
            else
            {
                return false;
            }
        }
       

        public void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }
    }
}
