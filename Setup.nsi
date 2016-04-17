SetCompressor /SOLID lzma

!include "nsProcess.nsh"
!include "Locate.nsh"
!include "x64.nsh"
;--------------------------------
;Include Modern UI
   !include "MUI2.nsh"
   ; include for some of the windows messages defines
   !include "winmessages.nsh"
;--------------------------------
;General
  ;Name and file
  !define VERSION "1.1.0"
  Name "NVidia Surround Toggler v${VERSION}"
  OutFile "NVIDIA Surround Toggle Setup.exe"

  ;Default installation folder
  InstallDir "$PROGRAMFILES\NVIDIA Surround Toggler"

  ;Get installation folder from registry if available
  InstallDirRegKey HKLM "Software\NVIDIA Surround Toggler" ""

  ;Request application privileges for Windows Vista
  RequestExecutionLevel admin ;Require admin rights on NT6+ (When UAC is turned on)

  !include LogicLib.nsh

  BrandingText "NVIDIA Surround Toggler"

;--------------------------------
;Interface Configuration
  !define MUI_HEADERIMAGE
  !define MUI_ABORTWARNING

;--------------------------------
;Pages

  !insertmacro MUI_PAGE_LICENSE "LICENSE"
  !insertmacro MUI_PAGE_COMPONENTS
  !insertmacro MUI_PAGE_DIRECTORY
  Page Custom ShowLockedFilesList
  !insertmacro MUI_PAGE_INSTFILES
  !insertmacro MUI_PAGE_FINISH
  
  !insertmacro MUI_UNPAGE_CONFIRM
  UninstPage Custom un.ShowLockedFilesList
  !insertmacro MUI_UNPAGE_INSTFILES
  !insertmacro MUI_UNPAGE_FINISH
  
!macro MYMACRO un
Function ${un}ShowLockedFilesList
  ${If} ${RunningX64}
    File /oname=$PLUGINSDIR\LockedList64.dll `${NSISDIR}\Plugins\LockedList64.dll`
  ${EndIf}
  !insertmacro MUI_HEADER_TEXT `Searching for locked files` `Free all locked files before proceeding by closing the applications listed below`
  ${locate::Open} "$INSTDIR" `/F=1 /D=0 /-X=crt /M=*.* /B=1` $0
    StrCmp $0 0 close
    loop:
    ${locate::Find} $0 $1 $2 $3 $4 $5 $6
      StrCmp $1 '' close
      LockedList::AddFile $1
      goto loop
    close:
  ${locate::Close} $0

  ${locate::Open} "$INSTDIR" `/F=1 /D=0 /X=exe|dll /M=*.* /B=1` $0
    StrCmp $0 0 close2
    loop2:
    ${locate::Find} $0 $1 $2 $3 $4 $5 $6
      StrCmp $1 '' close2
      LockedList::AddModule $1
      goto loop2
    close2:
  ${locate::Close} $0
  ${locate::Unload}

  LockedList::Dialog /autonext
  Pop $R0
FunctionEnd
!macroend
!insertmacro MYMACRO ""
!insertmacro MYMACRO "un."
;--------------------------------
;Languages

  !insertmacro MUI_LANGUAGE "English"

;--------------------------------
;Installer Sections

Section "Main Application" SecMain
  SectionIn RO
  SetOutPath "$INSTDIR"
  ;File "GPL.txt"
  File  /r /x "*.xml" /x "*.pdb" "NVIDIASurroundToggle\bin\x86\Release\*"


  ;Store installation folder
  WriteRegStr HKLM "Software\NVIDIA Surround Toggler" "InstallDir" $INSTDIR
  WriteRegStr HKLM "Software\NVIDIA Surround Toggler" "Version" ${VERSION}

  CreateShortCut "$SMPROGRAMS\Toggle NVIDIA Surround.lnk" "$INSTDIR\NVIDIA Surround Toggle.exe"

  ;Create uninstaller
  WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\NVIDIA Surround Toggler" "DisplayName" "NVIDIA Surround Toggler ${VERSION} for Windows (remove only)"
  WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\NVIDIA Surround Toggler" "UninstallString" "$INSTDIR\Uninstall NVIDIA Surround Toggler.exe"
  WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\NVIDIA Surround Toggler" "Publisher" "Soroush Falahati (falahati.net)"

  WriteUninstaller "$INSTDIR\Uninstall NVIDIA Surround Toggler.exe"
SectionEnd

Function .onInit
	UserInfo::GetAccountType
	pop $0
	${If} $0 != "admin" ;Require admin rights on NT4+
		MessageBox MB_ICONSTOP "Administrator rights required! Try running this file as Admin."
		SetErrorLevel 740 ;ERROR_ELEVATION_REQUIRED
		Quit
	${EndIf}
	CALL CheckNetFramework4Client
FunctionEnd

Function CheckNetFramework4Client
    ClearErrors
    ReadRegDWORD $0 HKLM "SOFTWARE\Microsoft\NET Framework Setup\NDP\v4\Full" "Release"
    IfErrors NotDetected
    Return
    NotDetected:
    MessageBox MB_ICONSTOP "Microsoft .NET Framework 4.5 is not installed, we will now redirect you to the Microsoft Website to download it."
    ExecShell open "http://www.microsoft.com/en-us/download/details.aspx?id=30653"
    Quit
FunctionEnd
;--------------------------------
;Descriptions

  ;Language strings
  LangString DESC_SecMain ${LANG_ENGLISH} "NVIDIA Surround Toggler for Windows"

  ;Assign language strings to sections
  !insertmacro MUI_FUNCTION_DESCRIPTION_BEGIN
    !insertmacro MUI_DESCRIPTION_TEXT ${SecMain} ${DESC_SecMain}
  !insertmacro MUI_FUNCTION_DESCRIPTION_END

;--------------------------------
;Uninstaller Section

Section "Uninstall"
  RMDir /r "$INSTDIR\*.*"
  RMDir "$INSTDIR"
  Delete "$SMPROGRAMS\Toggle NVIDIA Surround.lnk"

  DeleteRegKey /ifempty HKLM "Software\NVIDIA Surround Toggler"
  DeleteRegKey HKLM "SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\NVIDIA Surround Toggler for Windows"
SectionEnd

Function un.onInit
	UserInfo::GetAccountType
	pop $0
	${If} $0 != "admin" ;Require admin rights on NT4+
		MessageBox MB_ICONSTOP "Administrator rights required! Try running this file as Admin."
		SetErrorLevel 740 ;ERROR_ELEVATION_REQUIRED
		Quit
	${EndIf}
FunctionEnd