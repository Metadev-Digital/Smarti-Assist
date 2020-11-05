<!--
*** Thanks for checking out this README Template. If you have a suggestion that would
*** make this better, please fork the repo and create a pull request or simply open
*** an issue with the tag "enhancement".
*** Thanks again! Now go create something AMAZING! :D
-->





<!-- PROJECT SHIELDS -->
<!--
*** I'm using markdown "reference style" links for readability.
*** Reference links are enclosed in brackets [ ] instead of parentheses ( ).
*** See the bottom of this document for the declaration of the reference variables
*** for contributors-url, forks-url, etc. This is an optional, concise syntax you may use.
*** https://www.markdownguide.org/basic-syntax/#reference-style-links
-->
[![Contributors][contributors-shield]][contributors-url]
[![Forks][forks-shield]][forks-url]
[![Stargazers][stars-shield]][stars-url]
[![Issues][issues-shield]][issues-url]
[![MIT License][license-shield]][license-url]
[![LinkedIn][linkedin-shield]][linkedin-url]



<!-- PROJECT LOGO -->
<br />
<p align="center">
  <a href="https://github.com/Metadev-Digital/Smarti-Assist">
    <img src="https://www.metadevdigital.com/images/acr.png" alt="Logo">
  </a>

  <h3 align="center">Smart-i Assist</h3>

  <p align="center">
    Smart Injector labeling/tracability assistant for Acrelec America 
    <br />
    <a href="https://github.com/Metadev-Digital/Smarti-Assist"><strong>Explore the docs »</strong></a>
    <br />
    <br />
    <a href="https://www.nuget.org/packages/Smarti-Assist/">Download the Package</a>
    ·
    <a href="https://github.com/Metadev-Digital/Smarti-Assist/issues">Report Bug</a>
    ·
    <a href="https://github.com/Metadev-Digital/Smarti-Assist/issues">Request Feature</a>
  </p>
</p>



<!-- TABLE OF CONTENTS -->
## Table of Contents

* [About the Project](#about-the-project)
  * [Built With](#built-with)
* [Getting Started](#getting-started)
  * [Prerequisites](#prerequisites)
  * [Installation](#installation)
* [Usage](#usage)
* [Roadmap](#roadmap)
* [Contributing](#contributing)
* [License](#license)
* [Contact](#contact)
* [Acknowledgements](#acknowledgements)



<!-- ABOUT THE PROJECT -->
## About The Project

<img src="https://www.metadevdigital.com/acrelec/aainfo/proj.png" alt="Smarti-Assist Download">

Smart-i Assist provides a solution to better automate tracability and labeling in C#. This tool was created during an attempt to simplify and automate process taken by Order Fullfillmentfor Acrelec America. By creating this as it's own stand-alone tool, Smart-i Assist allows users to scan parts and print labels en-masse, greatly improving efficiency and accuracy.

Services contained in Smart-i Assist:
* Persistent variables/settings
* Importing/Exporting Configuration Sets
* Viewable in-application training documents
* Sending documents straight to printer or save as PDF
* Error reporting meant for users to directly submit trouble tickets to developers to keep the tools up and running day-to-day.

Of course, no one solution will serve all projects since your needs may be different. So I'll be adding more in the near future. You may also suggest changes by forking this repo and creating a pull request or opening an issue.

### Built With

* [C#](https://docs.microsoft.com/en-us/dotnet/csharp/)
* [HTML5](https://html.com/html5/)
* [Deployed with Visual Studio](https://visualstudio.microsoft.com/)


<!-- GETTING STARTED -->
## Getting Started

Smart-i Assist is hosted on a secure server at the address www.metadevdigital.com/acrelec. Using that site, you can select the particular version you would like to install. To maintain functionality, it is recommended that you always download the latest version. However, in case it were ever to be necessary to roll back to a prior version of Smart-i Assist, other versions are listed if they do not contain critical up-dates. Some versions will be omitted as time goes on, as it is always recommended to stay as current as possible. Download the tool with account credentials provided by the order fullfillment manager at Acrelec America's Pittsburgh location. 

### Prerequisites

Windows Operating System XP or newer

### Installation

With the executable downloaded, the application is ready to install. An active internet connection is recommended for the install. This will ensure that there are no mandatory patches that need to be pushed, in the event that the executable that you are trying to run is dangerously out of date.
* Unzip the archive and open the resulting folder.
* Run “Setup.exe”

This will open a standard application installer after a brief check for updates from the download server. To ensure that the software will be properly functioning, make sure you have an active internet connection during install.

Next through the installation instructions ensuring to select more info and run anyway in the event of a Windows SmartScreen message.

Note: Smart-i Assist is signed with a self-signed certificate. Seeing as I have no method of obtaining a code-signing EV certificate for Acrelec America, this may prompt warnings from Windows prior to install.

<!-- USAGE EXAMPLES -->
## Usage

Smart-I Assist has one main process, printing the traceability labels for the HyperView systems. To com-plete this task you must follow the steps below:
1) Import serials
2) Determine options
3) Validate input and decide output method
4) Print or PDF
These steps must be followed during every production run to ensure the data validity as well as to avoid label waste. To ensure there is no waste, you must be conscious of the commands you are sending to the application.

### Import Serials
Each data type has an option for importing from the excel document that is maintained for our HyperView Systems. This process can be started by pressing the respective “Import” button. Once pressed, this will open up an input dialogue asking for the serial data separated by enter lines.

To collect the data for import, open up the excel document, and mouse over the header for the column respective to the option you selected to import. Mouse over the top of the header and click to select the entire column at once. Copy the data through right click -> copy or through CTRL + C.
Once copied, tab back to the input dialogue, select inside of the text box, then paste through either right click -> paste or CTRL + V. This will enter the data into the box. Note that if the header is included, this is fine. The process of validating the serials will automatically exclude the expected headers as well as additional enter lines.

Repeat this process for both ARKs and Smart Injectors. Once your window has data in both fields you are ready to move onto the next step, determine options.
Note: If you wish to clear your data, either re-import to replace, navigate to File -> Clear, or use the short-cut CTRL+SHIFT+R.

<img src="https://www.metadevdigital.com/acrelec/smarti/snipet.png" alt="Smart-i Assist primed with data">

### Determine Options

While it is recommended that all of these options be enabled, they can be disabled through the panel “Include Options” displayed on the right side of the main window. 
The number of copies refers to the number of labels with specific data that are included in the document or sent to the printer. By default this number is set to one, but standard practice would be to print two copies of each label. One for the bottom of the unit. One for the original box to assist in order fulfillment’s traceability. To change the Technician field or Purchase Order field, select the option for the field you wish to change through Edit or use the shortcuts CTRL+SHIFT+T for Technicians, or CTRL+SHIFT+N for Purchase Order.

<img src="https://www.metadevdigital.com/acrelec/smarti/snipet2.png" alt="Smart-i Assist primed with data">

### Validate Input

For the sake of consistency and accuracy, take the time to verify the data is correct and the options are properly set!

### Print or PDF

*Printing*

When you are ready to print and data is imported, select print via the Print Button, File -> Print, or the shortcut CTRL+P. Once selected, the program will validate the input to make sure that it does not see any uncaught user errors, then it will prompt the user with a standard print dialogue . When prompted, select your desired printer. Note: Make sure you check the Printer Properties. By default, the program selects the page size to be 3 inches by 3 inches. Verify that this property is set before sending to job to the printer.

*PDF*

When you are ready to create your pdf and data is imported, select print via the Print Button, File -> Save as PDF, or the shortcut CTRL+S. Once selected, the program will validate the input to make sure that it does not see any uncaught user errors, then it will prompt the user with a standard file dialogue. When prompted, select your desired directory for output. The name of the file will be automatically generated for you upon choosing a directory. Once the file has been constructed it will notify you with a message box. Note: A software that can read PDF’s is still required to open and manipulate the file.

<!-- ROADMAP -->
## Roadmap

See the [open issues](https://github.com/Metadev-Digital/Smarti-Assist/issues) for a list of proposed features (and known issues).


<!-- CONTRIBUTING -->
## Contributing

Contributions are what make the open source community such an amazing place to be learn, inspire, and create. Any contributions you make are **greatly appreciated**.

1. Fork the Project
2. Create your Feature Branch (`git checkout -b feature/AmazingFeature`)
3. Commit your Changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the Branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request


<!-- LICENSE -->
## License

Distributed under the MIT License. See `LICENSE` for more information.



<!-- CONTACT -->
## Contact

Kevin Sherman - [@CMetadev](https://twitter.com/cmetadev) - contact@metadevdigital.com

Project Link: [https://github.com/Metadev-Digital/Smarti-Assist](https://github.com/Metadev-Digital/Smarti-Assist)



<!-- ACKNOWLEDGEMENTS -->
## Acknowledgements
* [Img Shields](https://shields.io)
* [AAInfo] (https://github.com/Metadev-Digital/Smarti-Assist)
* [Best-README-Template](https://github.com/othneildrew/Best-README-Template/blob/master/README.md)


<!-- MARKDOWN LINKS & IMAGES -->
<!-- https://www.markdownguide.org/basic-syntax/#reference-style-links -->


[contributors-shield]: https://img.shields.io/github/contributors/metadev-digital/Smarti-Assist.svg?style=flat-square
[contributors-url]: https://github.com/Metadev-Digital/Smarti-Assist/graphs/contributors
[forks-shield]: https://img.shields.io/github/forks/metadev-digital/Smarti-Assist.svg?style=flat-square
[forks-url]: https://github.com/Metadev-Digital/Smarti-Assist/network/members
[stars-shield]: https://img.shields.io/github/stars/metadev-digital/Smarti-Assist.svg?style=flat-square
[stars-url]: https://github.com/Metadev-Digital/Smarti-Assist/stargazers
[issues-shield]: https://img.shields.io/github/issues/metadev-digital/Smarti-Assist.svg?style=flat-square
[issues-url]: https://github.com/Metadev-Digital/Smarti-Assist/issues
[license-shield]: https://img.shields.io/github/license/metadev-digital/Smarti-Assist.svg?style=flat-square
[license-url]: https://github.com/Metadev-Digital/Smarti-Assist/blob/master/LICENSE
[linkedin-shield]: https://img.shields.io/badge/-LinkedIn-black.svg?style=flat-square&logo=linkedin&colorB=555
[linkedin-url]: https://www.linkedin.com/company/metadev-digital/
[product-screenshot]: https://www.metadevdigital.com/images/proj.png
