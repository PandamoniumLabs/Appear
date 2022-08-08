using Appear.Data.Repos;
using Appear.Domain.Enum;
using Appear.Domain.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appear.Services.Data
{
    public static class SettingsManager
    {
        private static UserSettings userSettings;
        private static AppSettings appSettings;
        public static PresentMode DefaultPresentMode
        {
            get { return PresentMode.Manual; }
        }

        private static UserSettingRepository _userRepository = null;
        private static UserSettingRepository userRepository()
        {
            if (_userRepository == null) _userRepository = new UserSettingRepository();
            return _userRepository;
        }

        private static ApplicationSettingsRepository _appRepository = null;
        private static ApplicationSettingsRepository appRepository()
        {
            if (_appRepository == null) _appRepository = new ApplicationSettingsRepository();
            return _appRepository;
        }

        public static UserSettings UserSettings()
        {
            if(userSettings == null)
            {
                userSettings = userRepository().GetUserSettings();
            }

            return userSettings;
        }

        public static AppSettings AppSettings()
        {
            if(appSettings == null)
            {
                appSettings = appRepository().Get();
            }

            return appSettings;
        }

        public static void SetStyle(int styleId)
        {
            var settings = UserSettings();
            settings.StyleId = styleId;
            userRepository().Update(settings);
        }

        public static void SetMaxOnStart(bool value)
        {
            var settings = UserSettings();
            settings.MaximizeOnStart = value;
            userRepository().Update(settings);
        }

        public static void SetUpdateOnStart(bool value)
        {
            var settings = UserSettings();
            settings.UpdateOnStart = value;
            userRepository().Update(settings);
        }

        public static void SetDockPosition(DockPosition position)
        {
            var settings = UserSettings();
            settings.DockPosition = position;
            userRepository().Update(settings);
        }

        public static string GetSettingByValue(string value)
        {
            UserSettings settings = UserSettings();

            switch (value)
            {
                case "DockPositions":
                    return Enum.GetName(typeof(DockPosition), settings.DockPosition);
                case "Modes":
                    return Enum.GetName(typeof(PresentMode), SettingsManager.DefaultPresentMode);
                case "Styles":
                    return StyleManager.CurrentStyle().Name;
                default: return "";
            }
        }

        public static string GetSettingByProperty(string prop)
        {
            UserSettings settings = UserSettings();

            switch (prop)
            {
                case "DockPosition":
                    return Enum.GetName(typeof(DockPosition), settings.DockPosition);
                case "PresentMode":
                    return DefaultPresentMode.ToString();
                default: return "";
            }
        }

        internal static void SetDisplayWidth(DisplayWidth displayWidth)
        {
            var settings = UserSettings();
            settings.DisplayWidth = displayWidth;
            userRepository().Update(settings);
        }
    }
}
