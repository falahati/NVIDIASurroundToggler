using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Automation;
using Castle.Core.Internal;
using Microsoft.Win32;
using NVIDIASurroundToggle.Extensions;
using NVIDIASurroundToggle.Native;
using NVIDIASurroundToggle.Native.Enums;
using NVIDIASurroundToggle.Native.Stractures;
using NVIDIASurroundToggle.Properties;
using NVIDIASurroundToggle.Resources;
using TestStack.White;
using TestStack.White.InputDevices;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.ListBoxItems;
using Rect = NVIDIASurroundToggle.Native.Stractures.Rect;

namespace NVIDIASurroundToggle
{
    public static class Surround
    {
        public static bool EnableSurround(bool showControls = true)
        {
            var result = false;
            if (!IsBusy())
            {
                new FrmSplash(() => result = ChangeNVidiaDisplayMode(true), showControls).ShowDialog();
            }
            return result;
        }

        public static bool DisableSurround(bool showControls = true)
        {
            var result = false;
            if (!IsBusy())
            {
                new FrmSplash(() => result = ChangeNVidiaDisplayMode(false), showControls).ShowDialog();
            }
            return result;
        }

        public static bool ToggleSurround(bool showControls = true)
        {
            var result = false;
            if (!IsBusy())
            {
                new FrmSplash(() => result = ChangeNVidiaDisplayMode(null), showControls).ShowDialog();
            }
            return result;
        }

        public static bool IsBusy()
        {
            return Utility.DefaultOnException(() => FrmSplash.Instance.Visible);
        }

        private static bool AutomateSurroundSettings(Application application)
        {
            // Waiting for form to become visible
            var setupDialog = Utility.DefaultOnException(() => application.GetWindow(NVidiaLocalization.NVIDIA_Surround_Caption_NVIDIA_Set_Up_Surround));
            if (setupDialog == null)
            {
                return true; // Control Panel somehow knows the settings
            }

            try
            {
                setupDialog.HideMinimize();
                setupDialog.WaitWhileBusy();
                setupDialog.ShowFocus();
                FrmSplash.Instance.Focus();
                System.Windows.Forms.Application.DoEvents();

                var topologyDropdown =
                    Utility.DefaultOnException(() => setupDialog.Get<ComboBox>(SearchCriteria.ByAutomationId("3484")));
                var resolutionDropdown =
                    Utility.DefaultOnException(() => setupDialog.Get<ComboBox>(SearchCriteria.ByAutomationId("3486")));
                var refreshRateDropdown =
                    Utility.DefaultOnException(() => setupDialog.Get<ComboBox>(SearchCriteria.ByAutomationId("3487")));

                setupDialog.HideMinimize();
                setupDialog.WaitWhileBusy();

                // Waiting a little for element to load, if not yet
                var enableButton = setupDialog.GetChildWindowWithControlId<Button>(3493, 5000);

                FrmSplash.Instance.Focus();
                System.Windows.Forms.Application.DoEvents();

                var bezel1TextBox = setupDialog.GetChildWindowWithControlId<TextBox>(3506);
                var bezel2TextBox = setupDialog.GetChildWindowWithControlId<TextBox>(3507);
                var bezel3TextBox = setupDialog.GetChildWindowWithControlId<TextBox>(3508);
                var bezel4TextBox = setupDialog.GetChildWindowWithControlId<TextBox>(3509);

                // Lets keep the current display setting before going any further 
                Utility.ContinueException(
                    () => Settings.Default.DisplaySettings = DisplaySetting.ArrayToXml(GetDisplaySettings()));

                if (!string.IsNullOrWhiteSpace(Settings.Default.Arrangement))
                {
                    // List of all monitors
                    var displays =
                        setupDialog.GetChildWindowWithControlId<ListView>(3489)
                            .AutomationElement.FindAll(
                                TreeScope.Descendants,
                                new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.CheckBox));

                    if (topologyDropdown != null && Settings.Default.Topology > -1)
                    {
                        var topologyDropdownItems = topologyDropdown.Items;
                        if (topologyDropdownItems.Count > Settings.Default.Topology)
                        {
                            topologyDropdownItems[Settings.Default.Topology].Select();
                            setupDialog.WaitWhileBusy();
                            Mouse.Instance.RestoreLocation();
                            FrmSplash.Instance.Focus();
                            System.Windows.Forms.Application.DoEvents();
                        }
                    }

                    foreach (var monitor in Settings.Default.Arrangement.Split('|'))
                    {
                        foreach (AutomationElement display in displays)
                        {
                            var cb = new CheckBox(display, null);
                            if (monitor.ToLower().Trim().Contains(cb.Text.ToLower().Trim()))
                            {
                                Utility.DoTimeout(
                                    () =>
                                    {
                                        Mouse.Instance.Location = cb.Bounds.Location + new Vector(22, 7);
                                        setupDialog.ExecuteAutomationAction(() => Mouse.Instance.Click());
                                        Mouse.Instance.RestoreLocation();
                                        FrmSplash.Instance.Focus();
                                        System.Windows.Forms.Application.DoEvents();
                                        return cb.Checked;
                                    });
                                break;
                            }
                        }
                    }

                    if (bezel1TextBox != null && Settings.Default.Bezel1 > -1)
                    {
                        bezel1TextBox.BulkText = Settings.Default.Bezel1.ToString();
                        setupDialog.WaitWhileBusy();
                    }

                    if (bezel2TextBox != null && Settings.Default.Bezel2 > -1)
                    {
                        bezel2TextBox.BulkText = Settings.Default.Bezel2.ToString();
                        setupDialog.WaitWhileBusy();
                    }

                    if (bezel3TextBox != null && Settings.Default.Bezel3 > -1)
                    {
                        bezel3TextBox.BulkText = Settings.Default.Bezel3.ToString();
                        setupDialog.WaitWhileBusy();
                    }

                    if (bezel4TextBox != null && Settings.Default.Bezel4 > -1)
                    {
                        bezel4TextBox.BulkText = Settings.Default.Bezel4.ToString();
                        setupDialog.WaitWhileBusy();
                    }

                    if (resolutionDropdown != null && Settings.Default.Resolution > -1)
                    {
                        var resolutionDropdownItems = resolutionDropdown.Items;
                        if (resolutionDropdownItems.Count > Settings.Default.Resolution)
                        {
                            resolutionDropdownItems[Settings.Default.Resolution].Select();
                            setupDialog.WaitWhileBusy();
                            Mouse.Instance.RestoreLocation();
                            FrmSplash.Instance.Focus();
                            System.Windows.Forms.Application.DoEvents();
                        }
                    }

                    if (refreshRateDropdown != null && Settings.Default.RefreshRate > -1)
                    {
                        var refreshRateDropdownItems = refreshRateDropdown.Items;
                        if (refreshRateDropdownItems.Count > Settings.Default.RefreshRate)
                        {
                            refreshRateDropdownItems[Settings.Default.RefreshRate].Select();
                            setupDialog.WaitWhileBusy();
                            Mouse.Instance.RestoreLocation();
                            FrmSplash.Instance.Focus();
                            System.Windows.Forms.Application.DoEvents();
                        }
                    }

                    // Let's see if the provided settings are satisfying
                    if (Utility.DoTimeout(
                        () =>
                        {
                            setupDialog.WaitWhileBusy();
                            return enableButton.Enabled;
                        }))
                    {
                        var result = Utility.DoTimeout(
                            () =>
                            {
                                setupDialog.ExecuteAutomationAction(
                                    () => Utility.ContinueException(() => enableButton.Click()));
                                Mouse.Instance.RestoreLocation();
                                System.Windows.Forms.Application.DoEvents();
                                application.WaitWhileBusy();
                                return !enableButton.Enabled
                                       || enableButton.Text.ToLower().Contains(NVidiaLocalization.NVIDIA_Surround_DisableButton_Disable.ToLower());
                            });
                        Utility.ContinueException(() => setupDialog.Close());
                        if (result)
                        {
                            Settings.Default.Save();
                        }
                        return result;
                    }
                }

                var arrangementPanel = setupDialog.GetChildWindowWithControlId<Button>(3490, 5000);
                if (arrangementPanel == null)
                {
                    throw new Exception(
                        Language.Surround_Arrangement_panel_is_not_accessible_from_our_side_can_t_save_your_settings_);
                }

                // Show the form and lets user to decide what to do
                setupDialog.ShowTopMost();
                Mouse.Instance.Location = setupDialog.Location
                                          + new Vector(setupDialog.Bounds.Width/2, setupDialog.Bounds.Height/2);
                Mouse.Instance.SavePosition();

                while (!setupDialog.IsClosed)
                {
                    try
                    {
                        if (topologyDropdown != null)
                        {
                            Settings.Default.Topology = Methods.SendMessage(topologyDropdown.GetHWnd(), 0x0147, 0, "");
                        }
                        if (resolutionDropdown != null)
                        {
                            Settings.Default.Resolution = Methods.SendMessage(
                                resolutionDropdown.GetHWnd(),
                                0x0147,
                                0,
                                "");
                        }
                        if (refreshRateDropdown != null)
                        {
                            Settings.Default.RefreshRate = Methods.SendMessage(
                                refreshRateDropdown.GetHWnd(),
                                0x0147,
                                0,
                                "");
                        }

                        Utility.ContinueException(
                            () =>
                            {
                                Settings.Default.Bezel1 = (!string.IsNullOrWhiteSpace(bezel1TextBox?.Text))
                                    ? bezel1TextBox.Text.TryParseIntOrDefault()
                                    : 0;
                                Settings.Default.Bezel2 = (!string.IsNullOrWhiteSpace(bezel2TextBox?.Text))
                                    ? bezel2TextBox.Text.TryParseIntOrDefault()
                                    : 0;
                                Settings.Default.Bezel3 = (!string.IsNullOrWhiteSpace(bezel3TextBox?.Text))
                                    ? bezel3TextBox.Text.TryParseIntOrDefault()
                                    : 0;
                                Settings.Default.Bezel4 = (!string.IsNullOrWhiteSpace(bezel4TextBox?.Text))
                                    ? bezel4TextBox.Text.TryParseIntOrDefault()
                                    : 0;
                            });

                        Utility.ContinueException(
                            () =>
                            {
                                if (!arrangementPanel.IsOffScreen)
                                {
                                    Settings.Default.Arrangement = string.Join(
                                        "|",
                                        arrangementPanel.AutomationElement.FindAll(
                                            TreeScope.Children,
                                            Condition.TrueCondition)
                                            .Cast<AutomationElement>()
                                            .Select(el => new Panel(el, null))
                                            .OrderBy(panel => panel.Bounds.Right)
                                            .ThenBy(panel => panel.Bounds.Bottom)
                                            .Select(panel => panel.Text));
                                }
                            });

                        setupDialog.WaitWhileBusy();
                        if (enableButton.Text.ToLower().Contains(NVidiaLocalization.NVIDIA_Surround_DisableButton_Disable.ToLower()))
                        {
                            Settings.Default.Save();
                            setupDialog.Close();
                            System.Windows.Forms.Application.DoEvents();
                            setupDialog.WaitWhileBusy();
                            return true;
                        }

                        Thread.Sleep(100);
                        setupDialog.WaitWhileBusy();
                        System.Windows.Forms.Application.DoEvents();
                    }
                    catch (Exception)
                    {
                        break;
                    }
                }
                Utility.ContinueException(
                    () =>
                    {
                        setupDialog.Close();
                        setupDialog.WaitWhileBusy();
                    });
                Settings.Default.Reload();
                return false;
            }
            catch (Exception)
            {
                setupDialog.Close();
                setupDialog.WaitWhileBusy();
                throw;
            }
        }

        private static void ApplyExtendedSettings()
        {
            Utility.DoTimeout(
                () =>
                {
                    System.Windows.Forms.Application.DoEvents();
                    var displays = GetDisplays();
                    if ((displays.Count > 1)
                        || (displays.Count == 1 && displays[0].Monitor.Top == 0 && displays[0].Monitor.Left == 0
                            && displays[0].Monitor.Bottom != 0 && displays[0].Monitor.Right != 0
                            && (displays[0].Monitor.Right/16 == displays[0].Monitor.Bottom/9
                                || displays[0].Monitor.Right/16 == displays[0].Monitor.Bottom/10
                                || displays[0].Monitor.Right/4 == displays[0].Monitor.Bottom/3)))
                    {
                        Thread.Sleep(5000);
                        return true;
                    }
                    return false;
                },
                20000,
                500);
            Cleanup();
            System.Windows.Forms.Application.DoEvents();
            if (!string.IsNullOrWhiteSpace(Settings.Default.DisplaySettings))
            {
                Utility.ContinueException(
                    () => ApplyDisplaySettings(DisplaySetting.XmlToArray(Settings.Default.DisplaySettings)));
                System.Windows.Forms.Application.DoEvents();
                Thread.Sleep(2000);
            }
            else
            {
                Process.Start("control.exe", "desk.cpl,Settings,@Settings");
                Thread.Sleep(10000);
            }
        }

        private static bool AutomateControlPanel(Application application, bool? goSurround)
        {
            var window = application.GetWindow(NVidiaLocalization.NVIDIA_ControlPanel_Caption_NVIDIA_Control_Panel);
            try
            {
                window.HideMinimize(); // Hiding also applies the settings we want
                var surroundTreeItem = window.GetChildWindowWithControlId<UIItem>(4100, 5000);
                if (surroundTreeItem == null)
                {
                    throw new Exception(Language.Surround_Can_t_find_the_surround_settings);
                }
                CheckBox surroundCheckbox = null;
                Utility.DoTimeout(
                    () =>
                    {
                        window.ExecuteAutomationAction(
                            () =>
                            {
                                Utility.ContinueException(() => surroundTreeItem.Click());
                                Mouse.Instance.RestoreLocation();
                            });
                        application.WaitWhileBusy();
                        surroundCheckbox = window.GetChildWindowWithControlId<CheckBox>(1866);
                        return surroundCheckbox != null;
                    });
                if (surroundCheckbox == null)
                {
                    throw new Exception(Language.Surround_Can_t_find_the_surround_settings);
                }

                if (goSurround != null && surroundCheckbox.Checked == goSurround)
                {
                    window.Close();
                    window.WaitWhileBusy();
                    return false;
                }

                goSurround = !surroundCheckbox.Checked;
                var success = window.ExecuteAutomationAction(
                    () =>
                    {
                        if (Utility.DoTimeout(
                            () =>
                            {
                                Utility.ContinueException(() => surroundCheckbox.Checked = goSurround.Value);
                                Mouse.Instance.RestoreLocation();
                                window.WaitWhileBusy();
                                application.WaitWhileBusy();
                                return surroundCheckbox.Checked == goSurround;
                            }))
                        {
                            var applyButton =
                                Utility.DefaultOnException(
                                    () => window.Get<Button>(SearchCriteria.ByAutomationId("1021")));
                            if (applyButton != null && Utility.DoTimeout(
                                () =>
                                {
                                    window.ExecuteAutomationAction(
                                        () => Utility.ContinueException(() => applyButton.Click()));
                                    Mouse.Instance.RestoreLocation();
                                    window.WaitWhileBusy();
                                    application.WaitWhileBusy();
                                    return applyButton.IsOffScreen || !applyButton.Enabled;
                                }))
                            {
                                return true;
                            }
                        }
                        return false;
                    });

                if (!success)
                {
                    throw new Exception(Language.Surround_Failed_to_change_the_surround_settings);
                }

                var result = true;
                if (goSurround.Value)
                {
                    result = AutomateSurroundSettings(application);
                }
                System.Windows.Forms.Application.DoEvents();
                window.Close();
                window.WaitWhileBusy();
                if (!goSurround.Value)
                {
                    ApplyExtendedSettings();
                }
                System.Windows.Forms.Application.DoEvents();
                Mouse.Instance.RestoreLocation();
                return result;
            }
            catch (Exception)
            {
                window.Close();
                window.WaitWhileBusy();
                throw;
            }
        }

        public static void Cleanup()
        {
            Process.GetProcesses().Where(pr => pr.ProcessName == "nvcplui").ForEach(
                pr =>
                {
                    pr.Kill();
                    pr.WaitForExit();
                });
            Utility.ContinueException(
                () =>
                {
                    var key =
                        RegistryKey.OpenBaseKey(
                            RegistryHive.CurrentUser,
                            Environment.Is64BitOperatingSystem ? RegistryView.Registry64 : RegistryView.Registry32)
                            .OpenSubKey(@"SOFTWARE\NVIDIA Corporation");
                    if (key != null)
                    {
                        foreach (var subKeyName in key.GetSubKeyNames())
                        {
                            if (subKeyName.Trim()
                                .StartsWith("NVControlPanel", StringComparison.CurrentCultureIgnoreCase))
                            {
                                using (var subkey = key.OpenSubKey(subKeyName))
                                {
                                    if (subkey != null)
                                    {
                                        if (subkey.GetSubKeyNames().Contains("Client"))
                                        {
                                            using (var clientSubkey = subkey.OpenSubKey("Client", true))
                                            {
                                                if (clientSubkey != null)
                                                {
                                                    clientSubkey.DeleteValue("LastPage", false);
                                                    clientSubkey.DeleteValue("WindowPlacement", false);
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        key.Close();
                    }
                });
        }

        private static bool ChangeNVidiaDisplayMode(bool? on)
        {
            Cleanup();
            try
            {
                var nvcpAddress = GetNvidiaControlPanelAddress();
                if (string.IsNullOrWhiteSpace(nvcpAddress))
                {
                    throw new Exception(Language.Surround_NVIDIA_Control_Panel_is_absent_on_this_system);
                }
                var application =
                    Application.Launch(new ProcessStartInfo(nvcpAddress) {WindowStyle = ProcessWindowStyle.Minimized});
                application.WaitWhileBusy();
                Mouse.Instance.SavePosition();
                var result = AutomateControlPanel(application, on);
                Utility.ContinueException(() => application.WaitWhileBusy());
                Cleanup();
                return result;
            }
            catch (Exception)
            {
                Cleanup();
                throw;
            }
        }

        private static bool ApplyDisplaySettings(DisplaySetting[] settings)
        {
            var allDisplays = GetDisplays();
            foreach (var setting in settings)
            {
                allDisplays.Remove(
                    allDisplays.FirstOrDefault(
                        ex => ex.DeviceName.ToLower().Trim() == setting.DisplayName.ToLower().Trim()));
                var flags = ChangeDisplaySettingsFlags.Updateregistry | ChangeDisplaySettingsFlags.Global
                            | ChangeDisplaySettingsFlags.Noreset;
                if (setting.Devmode.Position.X == 0 && setting.Devmode.Position.Y == 0)
                {
                    flags |= ChangeDisplaySettingsFlags.SetPrimary;
                }
                var devMode = setting.Devmode;
                if (Methods.ChangeDisplaySettingsEx(setting.DisplayName, ref devMode, IntPtr.Zero, flags, IntPtr.Zero)
                    != ChangeDisplaySettingsExResults.Successful)
                {
                    return false;
                }
            }

            // Disable missing monitors
            foreach (var display in allDisplays)
            {
                var emptyDev = DevMode.GetEmpty();
                Methods.ChangeDisplaySettingsEx(
                    display.DeviceName,
                    ref emptyDev,
                    IntPtr.Zero,
                    ChangeDisplaySettingsFlags.Updateregistry | ChangeDisplaySettingsFlags.Global
                    | ChangeDisplaySettingsFlags.Noreset,
                    IntPtr.Zero);
            }

            // Apply all settings
            Methods.ChangeDisplaySettingsEx(
                null,
                IntPtr.Zero,
                IntPtr.Zero,
                ChangeDisplaySettingsFlags.Reset,
                IntPtr.Zero);

            return true;
        }

        private static List<MonitorInfoEx> GetDisplays()
        {
            var result = new List<MonitorInfoEx>();

            Methods.EnumDisplayMonitors(
                IntPtr.Zero,
                IntPtr.Zero,
                (IntPtr hMonitor, IntPtr hdcMonitor, ref Rect lprcMonitor, IntPtr dwData) =>
                {
                    var mi = new MonitorInfoEx().Init();
                    var success = Methods.GetMonitorInfo(hMonitor, ref mi);
                    if (success)
                    {
                        result.Add(mi);
                    }
                    return true;
                },
                IntPtr.Zero);
            return result;
        }

        private static DisplaySetting[] GetDisplaySettings()
        {
            var settings = new List<DisplaySetting>();
            foreach (var display in GetDisplays())
            {
                var devMode = new DevMode().Init();
                if (Methods.EnumDisplaySettings(display.DeviceName, DisplaySettingsMode.CurrentSettings, ref devMode))
                {
                    settings.Add(new DisplaySetting {DisplayName = display.DeviceName, Devmode = devMode});
                }
            }
            return settings.ToArray();
        }

        private static string GetNvidiaControlPanelAddress()
        {
            string result = null;
            Utility.ContinueException(
                () =>
                {
                    var key =
                        RegistryKey.OpenBaseKey(
                            RegistryHive.LocalMachine,
                            Environment.Is64BitOperatingSystem ? RegistryView.Registry64 : RegistryView.Registry32)
                            .OpenSubKey(@"SOFTWARE\NVIDIA Corporation");
                    if (key != null)
                    {
                        foreach (var subKeyName in key.GetSubKeyNames())
                        {
                            if (subKeyName.Trim()
                                .StartsWith("NVControlPanel", StringComparison.CurrentCultureIgnoreCase))
                            {
                                using (var subkey = key.OpenSubKey(subKeyName))
                                {
                                    if (subkey != null)
                                    {
                                        result = subkey.GetValue("InstalledClient", null) as string;
                                        if (result != null && File.Exists(result))
                                        {
                                            break;
                                        }
                                        result = null;
                                    }
                                }
                            }
                        }
                        key.Close();
                    }
                });
            return result;
        }
    }
}