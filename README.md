# Blackbaud-CRM-MultiSelect
Data lists have a variety of ways to filter data out-of-the-box. Users may wish to add even more options to filter. A recent request was a demonstration of how to allow multiple options to be selected in a checkbox. While this functionality isn't built-in, there are ways to accomplish this with UI Model code. This code sample will demonstrate an extendable multi-select filter with a basic data list that pulls financial transaction records for a constituent.

A more complete readme is in progress. 

## Prerequisites
*	An installation of CRM
*	Administrator-level access rights to said installation
*	Access to said installation's database and virtual directory
*	A specified and valid probe path in your installation's web config file
*	Basic knowledge of the SDK, page designer, html, and custom UI Model code.

Loading customizations is covered in our [SDK Guide](https://www.blackbaud.com/files/support/guides/infinitydevguide/infsdk-developer-help.htm) and other [code samples](https://github.com/blackbaud-community/Blackbaud-CRM-Fixer-Integration-Sample). So, we will not address that here.

## Deploying the Code
To simplify testing and deployment in a development environment, take the following steps:
*	Update the line "[UPDATE TO YOUR DEPLOY FOLDER]" in postbuild.bat to your deployment folder.
*	Update the project files to compile to bin\custom.
* 	If necessary, update the references to point to your copy of the product DLLs.

