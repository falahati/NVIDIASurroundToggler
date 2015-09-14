## NVIDIA Surround Toggler
DOWNLOAD: <a href="https://github.com/falahati/NVIDIASurroundToggler/releases">Releases Page</a>

NVidia Surround Toggler is a simple tool/program that try to fill the main gap left by NVIDIA in their surround technology's user experience by letting the user toggle between the two modes (Surround and Extended) as fast and with less pain as possible.

The program's main feature is saving of both surround and extended settings and possibility to run a program in a specific display mode.

Having this in mind, the real reason for writing and sharing of this code was to see how much we can use the Microsoft UIAutomation framework and its extending frameworks _in this case the White framework_ to automate a simple procedure as clean as possible.

As you can clearly see in the code, we soon found both frameworks very weak and decided to use WinAPI to make the process smoother. This is a fact that UIAutomation framework can help a lot of folks to achieve automation of simple procedures, but it also has lot of disadvantages especially in terms of performance, user experience and possibilities we can expect of it.


Please note that this program created for research propose only and there is no guarantee for it to work or function properly. In fact the only testing machine was an x64 Windows 10 system with the latest version of NVidia Graphic Driver and Control Panel (v355.60) installed. But you can report issues and I will try my best to solve them.


Inspired by <a href="http://hardforum.com/showthread.php?t=1590030">"Unknown-One"'s "NVSToggle"</a> (Even using the same icon)