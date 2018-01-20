using Plugin.Settings;
using Plugin.Settings.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto.Helpers
{
  /// <summary>
  /// This is the Settings static class that can be used in your Core solution or in any
  /// of your client applications. All settings are laid out the same exact way with getters
  /// and setters. 
  /// </summary>
  public static class Settings
{
    private static ISettings AppSettings
    {
        get
        {
            return CrossSettings.Current;
        }
    }

    #region Setting Constants

    private const string LastUserName = "Last_UserName";
    private static readonly string SettingsDefault = string.Empty;

    #endregion


    public static string RememberUserName
    {
        get
        {
            return AppSettings.GetValueOrDefault(LastUserName, SettingsDefault);
        }
        set
        {
            AppSettings.AddOrUpdateValue(LastUserName, value);
        }
    }

}
}
