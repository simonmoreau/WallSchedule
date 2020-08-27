<p align="center"><img width=12.5% src="https://raw.githubusercontent.com/simonmoreau/WallSchedule/master/WallScheduleIcon.png"></p>
<h1 align="center">
  WallSchedule
</h1>

<h4 align="center">A Design Automation API Revit Addin to extract a wall schedule</h4>

# Overview

The WallSchedule Revit addin is a small application for extracting a (very) basic wall schedule from a Revit model. This addin works with the Design Automation API on Autodesk Forge and is only intended as sample for such an application.

# Getting Started

Edit _WallSchedule.csproj_, and make sure that the following lines a correctly pointing to your Revit installation folder:
* Line 41:     <HintPath>$(ProgramW6432)\Autodesk\Revit 2021\RevitAPI.dll</HintPath>
* Line 140 to 143: <PostBuildEvent>...</PostBuildEvent>

Edit _WallSchedule.csproj.user_, and make sure of the following:
* Line 5:     <StartProgram>_Point to your Revit executable_</StartProgram>
* Line 6:     <StartWorkingDirectory>_Point to your local Design Automation folder_</StartWorkingDirectory>
* Line 7:     <StartArguments>_Point to your local Revit input file_</StartArguments>

Open the solution in Visual Studio 2019, buid it, and hit "Start" to run in Revit in debug mode.

## Installation

You install Align just [like any other Revit add-in](http://help.autodesk.com/view/RVT/2018/ENU/?guid=GUID-4FFDB03E-6936-417C-9772-8FC258A261F7), by copying the add-in manifest (_"WallSchedule.addin"_) and the assembly DLL (_"WallSchedule.dll"_) to the Revit Add-Ins folder (%APPDATA%\Autodesk\Revit\Addins\2021).

If you specify the full DLL pathname in the add-in manifest, it can also be located elsewhere. However, this DLL, its dependanties and help files must be located in the same folder.

Futhermore, the Visual Studio solution contain all the necessary post-build scripts to copy these files into appropriates folders.

## Built With

* .NET Framework 4.8 and [Visual Studio Community](https://www.visualstudio.com/vs/community/)
* Samples from the [Design Automation API website](https://forge.autodesk.com/en/docs/design-automation/v3/tutorials/revit/about_this_tutorial/)

# Development

Want to contribute? Great, I would be happy to integrate your improvements!

To fix a bug or enhance an existing module, follow these steps:

* Fork the repo
* Create a new branch (`git checkout -b improve-feature`)
* Make the appropriate changes in the files
* Add changes to reflect the changes made
* Commit your changes (`git commit -am 'Improve feature'`)
* Push to the branch (`git push origin improve-feature`)
* Create a Pull Request

# Bug / Feature Request

If you find a bug (connection issue, error while uploading, ...), kindly open an issue [here](https://github.com/simonmoreau/WallSchedule/issues/new) by including a screenshot of your problem and the expected result.

If you'd like to request a new function, feel free to do so by opening an issue [here](https://github.com/simonmoreau/WallSchedule/issues/new). Please include workflows samples and their corresponding results.

# License

This project is licensed under the MIT License - see the [LICENSE.md](LICENSE) file for details

# Contact information

This software is an open-source project mostly maintained by myself, Simon Moreau. If you have any questions or request, feel free to contact me at [simon@bim42.com](mailto:simon@bim42.com) or on Twitter [@bim42](https://twitter.com/bim42?lang=en).