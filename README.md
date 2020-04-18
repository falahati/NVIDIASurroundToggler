_THIS PROJECT IS CURRENTLY OUTDATED AND MAY NOT WORK AS EXPECTED. IT IS ALSO NOT UNDER ACTIVE DEVELOPMENT OR MAINTENANCE ANYMORE._

**Please consider checking out my other project that should do what this project intended to do, even better:**
https://github.com/falahati/HeliosDisplayManagement


# NVIDIA Surround Toggler
[![](https://img.shields.io/github/license/falahati/NVIDIASurroundToggler.svg?style=flat-square)](https://github.com/falahati/NVIDIASurroundToggler/blob/master/LICENSE)
[![](https://img.shields.io/github/commit-activity/y/falahati/NVIDIASurroundToggler.svg?style=flat-square)](https://github.com/falahati/NVIDIASurroundToggler/commits/master)
[![](https://img.shields.io/github/issues/falahati/NVIDIASurroundToggler.svg?style=flat-square)](https://github.com/falahati/NVIDIASurroundToggler/issues)

NVidia Surround Toggler is a simple tool/program that tries to fill the main gap left by NVIDIA in their surround technology's user experience by letting the user toggle between the two modes (Surround and Extended) as fast and with less pain as possible.

The program's main feature is saving both surround and extended settings and the possibility to run a program in a specific display mode.

Inspired by <a href="http://hardforum.com/showthread.php?t=1590030">"Unknown-One"'s "NVSToggle"</a> (Even using the same icon)

## How to get
[![](https://img.shields.io/github/downloads/falahati/NVIDIASurroundToggler/total.svg?style=flat-square)](https://github.com/falahati/NVIDIASurroundToggler/releases)
[![](https://img.shields.io/github/tag-date/falahati/NVIDIASurroundToggler.svg?label=version&style=flat-square)](https://github.com/falahati/NVIDIASurroundToggler/releases)

To download the latest version of this program, take a look at the <a href="https://github.com/falahati/NVIDIASurroundToggler/releases">releases page</a>.

## Help me fund my own Death Star

[![](https://img.shields.io/badge/crypto-CoinPayments-8a00a3.svg?style=flat-square)](https://www.coinpayments.net/index.php?cmd=_donate&reset=1&merchant=820707aded07845511b841f9c4c335cd&item_name=Donate&currency=USD&amountf=20.00000000&allow_amount=1&want_shipping=0&allow_extra=1)
[![](https://img.shields.io/badge/shetab-ZarinPal-8a00a3.svg?style=flat-square)](https://zarinp.al/@falahati)
[![](https://img.shields.io/badge/usd-Paypal-8a00a3.svg?style=flat-square)](https://www.paypal.com/cgi-bin/webscr?cmd=_donations&business=ramin.graphix@gmail.com&lc=US&item_name=Donate&no_note=0&cn=&curency_code=USD&bn=PP-DonationsBF:btn_donateCC_LG.gif:NonHosted)

**--OR--**

You can always donate your time by contributing to the project or by introducing it to others.

## How to use
You can toggle surround mode by right-clicking on the desktop and selecting the 'NVIDIA Surround' option. You also can force a program to start in a specific mode by right-clicking on the executable file and following the same instructions.
![Screenshot](/contextmenus.jpg?raw=true "Screenshot")

## Settings and Tools
If your NVIDIA Control Panel's language is not the same as your Windows language, you may need to manually specify the correct language of the NVIDIA Control Panel in the 'Options' page for the program to function properly. This page also allows you to reset the saved Extended and Surround settings.

It is also possible to create advanced shortcuts using the program's 'Tools' page. This is useful for games and programs that cannot be started directly; like Steam games and other game launchers.
![Screenshot](/screenshot.jpg?raw=true "Screenshot")

## Known issues
This program supports most (if not all) of the 'NVIDIA Control Panel' languages. Still, if you have a problem with one specific language, open an <a href="https://github.com/falahati/NVIDIASurroundToggler/issues">Issue</a> and help us fix it in the next release.

Unfortunately, this program is not compatible with SLI setups YET! We try our best to add this functionality to the program as soon as possible.

## Behind the scene
The real reason for writing and sharing this code was to see how much we can use the Microsoft UIAutomation framework and its extending frameworks ( _in this case the White framework_ ) to automate a simple procedure as clean as possible.

As you can see in the code, we soon found both frameworks very weak and decided to use WinAPI to make the process smoother. This is a fact that the UIAutomation framework can help a lot of folks to achieve automation of simple procedures, but it also has a lot of disadvantages especially in terms of performance, user experience and possibilities we can expect of it.

## Guarantee
Please note that this program created for research proposes only and there is no guarantee for it to work or function properly. The only testing machine was an x64 Windows 10 system with the latest version of the NVidia Graphic Driver and Control Panel (v355.60) installed. But you can report issues and I will try my best to solve them.

## License
Copyright (C) 2015-2017 Soroush Falahati

This project is licensed under the GNU Lesser General Public License ("LGPL") and therefore can be used in closed source or commercial projects. 
However, any commit or change to the main code must be public and there should be a read me file along with the DLL clarifying the license and its terms as part of your project as well as a hyperlink to this repository. [Read more about LGPL](LICENSE).
