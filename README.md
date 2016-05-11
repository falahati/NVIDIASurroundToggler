# NVIDIA Surround Toggler
NVidia Surround Toggler is a simple tool/program that try to fill the main gap left by NVIDIA in their surround technology's user experience by letting the user toggle between the two modes (Surround and Extended) as fast and with less pain as possible.

The program's main feature is saving of both surround and extended settings and possibility to run a program in a specific display mode.

Inspired by <a href="http://hardforum.com/showthread.php?t=1590030">"Unknown-One"'s "NVSToggle"</a> (Even using the same icon)

## WHERE TO DOWNLOAD
To download the latest version of this program, take a look at the <a href="https://github.com/falahati/NVIDIASurroundToggler/releases">releases page</a>.

## HOW TO USE
You can toggle surround mode by right clicking on desktop and selecting 'NVIDIA Surround' option. You also can force a program to start in a specific mode by right clicking on the executable file and following the same instructions.
![Screenshot](/contextmenus.jpg?raw=true "Screenshot")

## SETTINGS AND TOOLS
If your NVIDIA Control Panel's language is not the same as your Windows language, you may need to manually specify the correct language of NVIDIA Control Panel in the 'Options' page for program to function properly. This page also allows you to reset the saved Extended and Surround settings.

It is also possible to create advanced shortcuts using the program's 'Tools' page. This is useful for games and programs that cannot be started directly; like Steam games and other game launchers.
![Screenshot](/screenshot.jpg?raw=true "Screenshot")

## KNOWN ISSUES
This program supports most (if not all) of the 'NVIDIA Control Panel' languages. Still, if you have a problem with one specific language, open an <a href="https://github.com/falahati/NVIDIASurroundToggler/issues">Issue</a> and help us fix it in the next release.

Unfortunately this program is not compatible with SLI setups YET! We try our best to add this functionality to the program as soon as possible.

## BEHIND THE SCENE
The real reason for writing and sharing of this code was to see how much we can use the Microsoft UIAutomation framework and its extending frameworks ( _in this case the White framework_ ) to automate a simple procedure as clean as possible.

As you can clearly see in the code, we soon found both frameworks very weak and decided to use WinAPI to make the process smoother. This is a fact that UIAutomation framework can help a lot of folks to achieve automation of simple procedures, but it also has lot of disadvantages especially in terms of performance, user experience and possibilities we can expect of it.

## GUARANTEE
Please note that this program created for research propose only and there is no guarantee for it to work or function properly. In fact, the only testing machine was an x64 Windows 10 system with the latest version of NVidia Graphic Driver and Control Panel (v355.60) installed. But you can report issues and I will try my best to solve them.

## LICESNE
This program and its source code is under GNU General Public License.
