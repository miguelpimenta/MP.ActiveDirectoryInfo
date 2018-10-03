using MahApps.Metro.Controls.Dialogs;

namespace MP.ActiveDirectoryInfo
{
    public class DialogSettings
    {
        #region Singleton

        private static DialogSettings instance = null;
        private static readonly object lockThis = new object();

        public static DialogSettings Instance
        {
            get
            {
                lock (lockThis)
                {
                    if (instance == null)
                    {
                        instance = new DialogSettings();
                    }

                    return instance;
                }
            }
        }

        #endregion Singleton

        private DialogSettings()
        {
        }

        public MetroDialogSettings DlgDefaultSet => new MetroDialogSettings()
        {
            AffirmativeButtonText = "OK",
            DialogTitleFontSize = 32,
            DialogMessageFontSize = 24,
            AnimateHide = true,
            AnimateShow = true,
            ColorScheme = MetroDialogColorScheme.Theme,
        };

        public MetroDialogSettings DlgErrorSet => new MetroDialogSettings()
        {
            AffirmativeButtonText = "OK",
            DialogTitleFontSize = 32,
            DialogMessageFontSize = 24,
            AnimateHide = true,
            AnimateShow = true,
            ColorScheme = MetroDialogColorScheme.Inverted,
        };

        public MetroDialogSettings DlgYesNoSet => new MetroDialogSettings()
        {
            AffirmativeButtonText = "Sim",
            NegativeButtonText = "Não",
            DialogTitleFontSize = 32,
            DialogMessageFontSize = 24,
            AnimateHide = true,
            AnimateShow = true,
            ColorScheme = MetroDialogColorScheme.Theme,
        };
    }
}