using Appear.Data.Repos;
using Appear.Domain.Enum;
using Appear.Domain.Settings;
using Appear.Services.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace Appear.Services
{
    public static class StyleManager
    {
        private static WindowState currentState;
        private static WindowState previousState;

        private static Domain.Settings.Style currentStyle;

        public static Domain.Settings.Style CurrentStyle()
        {
            if(currentStyle == null)
            {
                currentStyle = repository().GetCurrentStyle();
            }

            return currentStyle;
        }

        private static StyleRepository _repository = null;
        private static StyleRepository repository()
        {
            if (_repository == null) _repository = new StyleRepository();
            return _repository;
        }

        public static void SetCurrentStyle(string name)
        {
            currentStyle = repository().GetStyleByName(name);
            SettingsManager.SetStyle(currentStyle.Id);
            SetTheme();
        }

        public static void StartUp(Window window)
        {
            SetPreferences(window);
            SetTheme();
        }

        public static void SetPreferences(Window window)
        {
            if (SettingsManager.UserSettings().MaximizeOnStart)
            {
                currentState = WindowState.Normal;
                SetWindowState(window, "Maximize");
            }
            else
            {
                currentState = WindowState.Normal;
                previousState = WindowState.Normal;
            }

            UpdateStyle(currentState);
        }

        public static void SetWindowState(Window window, string state)
        {
            switch (state)
            {
                case "Maximize":
                    if(window.WindowState != WindowState.Maximized)
                    {
                        window.WindowState = WindowState.Maximized;
                        previousState = currentState;
                        currentState = window.WindowState;
                    }
                    UpdateStyle(currentState);
                    break;
                case "Restore":
                    window.WindowState = previousState;
                    previousState = currentState;
                    currentState = window.WindowState;
                    UpdateStyle(currentState);
                    break;
                case "Present":
                    window.WindowState = WindowState.Maximized;
                    break;
                case "StopPresenting":
                    window.WindowState = currentState;
                    break;
                default:
                    break;
            }
        }

        public static void SetTheme()
        {
            ApplyTheme(CurrentStyle().ColorPairs);
        }

        public static void UpdateStyle()
        {
            StyleManager.UpdateStyle(currentState);
        }

        private static void UpdateStyle(WindowState state)
        {
            switch (state)
            {
                case WindowState.Maximized:
                    App.Current.Resources["Corner_Bar"] = new CornerRadius(0);
                    App.Current.Resources["Corner"] = new CornerRadius(0);
                    break;
                case WindowState.Normal:
                    App.Current.Resources["Corner"] = new CornerRadius(25);
                    switch (StyleManager.GetUserSettings().DockPosition)
                    {
                        case DockPosition.Top:
                            App.Current.Resources["Corner_Bar"] = new CornerRadius(20, 20, 0, 0);
                            break;
                        case DockPosition.Bottom:
                            App.Current.Resources["Corner_Bar"] = new CornerRadius(0, 0, 20, 20);
                            break;
                        default:
                            break;
                    }
                    break;
                default:
                    break;
            }
        }

        private static void ApplyTheme(Dictionary<string, Color> pairs)
        {
            foreach(var pair in pairs)
            {
                App.Current.Resources[pair.Key] = new SolidColorBrush(pair.Value);
            }
        }

        public static UserSettings GetUserSettings()
        {
            return SettingsManager.UserSettings();
        }

        public static List<string> GetStyleNames()
        {
            var list = new List<string>();
            var styles = repository().GetAll();

            foreach(var style in styles)
            {
                list.Add(style.Name);
            }

            return list;
        }
    }
}
