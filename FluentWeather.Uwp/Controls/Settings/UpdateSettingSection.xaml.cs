using FluentWeather.Uwp.Helpers.Update;
using FluentWeather.Uwp.Helpers;
using FluentWeather.Uwp.Shared;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Microsoft.AppCenter.Analytics;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Toolkit.Uwp.Helpers;

//https://go.microsoft.com/fwlink/?LinkId=234236 上介绍了“用户控件”项模板

namespace FluentWeather.Uwp.Controls.Settings
{
    public sealed partial class UpdateSettingSection : UserControl
    {
        public UpdateSettingSection()
        {
            this.InitializeComponent();
        }

        private async void CheckUpdateButton_Click(object sender, RoutedEventArgs e)
        {
            var versionString = Package.Current.Id.Version.ToFormattedString();
            Analytics.TrackEvent("UpdateManualChecked",new Dictionary<string, string> { { "CurrentVersion", versionString } });
            try
            {
                var info = await UpdateHelper.CheckUpdateAsync("zxbmmmmmmmmm", "FluentWeather-Lite", new Version(versionString));
                var viewAction = new Action(() =>
                {
                    Launcher.LaunchUriAsync(new Uri(info.HtmlUrl));
                });
                if (info.IsExistNewVersion)
                {
                    var dialog = new ContentDialog { Title = $"更新 {info.TagName}",PrimaryButtonText="下载",Content = info.Changelog,CloseButtonText="关闭"};
                    dialog.PrimaryButtonClick += (s, e) =>
                    {
                        Launcher.LaunchUriAsync(new Uri("https://wwxk.lanzouj.com/b02x4spkd"));
                    };
                    dialog.ShowAsync();
                }
                else
                {
                    var dialog = new ContentDialog { Title = "应用已是最新版本", Content = info.Changelog, CloseButtonText = "关闭" };
                    dialog.ShowAsync();
                }
            }
            catch (Exception ex)
            {
                var dialog = new ContentDialog { Title = $"检查更新失败", Content = "请检查当前网络或尝试开启代理", CloseButtonText = "关闭" };
                dialog.ShowAsync();
                Common.LogManager.GetLogger("UpdateHelper").Error("检查更新失败", ex);
            }
        }
    }
}
