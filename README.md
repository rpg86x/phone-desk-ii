# Phone Desk II

Movable Windows desktop phone window, with the Oppo Find X5 Pro profile by default. Current existing local build imported without changes. Source and executable are under `A/source` and `A/windows`.

Download ZIP, extract and open `A/windows/Phone Desk II.exe`. Requires Windows and .NET Framework 4.x. The executable is unsigned.

The shared profile file `phone-desk-settings.xml` is read beside the executable. Personal settings are excluded from Git. To configure the profile, download [Phone Desk Settings](https://github.com/rpg86x/phone-desk-settings) and place its executable beside Phone Desk II. Settings manages five profiles; enable only the downloaded device when using its launch button.

The Meter button requires the separate Codex Meter 1.4.0 phone-profile runtime at `Codex Meter 1.4.0/windows/Codex Meter.exe` beside this executable. It is not bundled in this repository; without it the button reports the missing dependency. The phone window can run independently.

Build from the repository root with PowerShell:

```powershell
& C:\Windows\Microsoft.NET\Framework64\v4.0.30319\csc.exe /nologo /target:winexe '/out:A\windows\Phone Desk II.exe' /reference:System.Windows.Forms.dll /reference:System.Drawing.dll 'A\source\Phone Desk II.cs' 'A\source\PhoneDeskConfig.cs'
```

The existing build has no reliable numeric release metadata. Git Sync records its version as `current`. Publication of this exact existing build was requested by the owner. The original installed Phone Desk suite remains unchanged.
