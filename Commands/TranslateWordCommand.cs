using BookWorm.Api;
using BookWorm.ViewModel;
using System;
using System.Threading.Tasks;
using System.Windows;

namespace BookWorm.Commands
{
    public class TranslateWordCommand : AsyncCommandBase
    {
        private IBase _mainSelectorVm;
        public TranslateWordCommand(IBase mainSelectorVm) { 

            this._mainSelectorVm = mainSelectorVm;
        }
        protected async override Task ExecuteAsync(object? parameter)
        {
            try
            {
                if (Clipboard.ContainsText())
                {
                    string selectedText = Clipboard.GetText();
                    if (!string.IsNullOrEmpty(selectedText))
                    {
                        var fromLn = _mainSelectorVm.ReadingModeVM.FromLanguage;
                        var toLn = _mainSelectorVm.ReadingModeVM.ToLanguage;

                        var translationDto = await ApisClient.TranslateTextAsync(selectedText, fromLn, toLn);

                        string translation = "";
                        translationDto?.ForEach(translate => translate.Translations?.ForEach(i => translation += i.Text + ","));

                        if (!string.IsNullOrEmpty(translation))
                        {

                            _mainSelectorVm.ReadingModeVM.Translate = translation;
                        }
                        else
                        {
                            _mainSelectorVm.ReadingModeVM.Translate = "Відсутні співпадіння для перекладу!";
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
