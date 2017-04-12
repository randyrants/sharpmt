# SharpMT

# Project Description
SharpMT is an offline Blog writer that is designed for MovableType based systems.  There are three versions of the application: desktop, PocketPC, and SmartPhone, all of which share the same file format for offline drafts.  The project files included have three different versions - one for each platform - as well as installation and help system project files.

The application uses text boxes for post entry: it was a design goal to not support WYSIWYG.  It also includes the infrastructure to support plugins and XML-RPC calls that were designed to inteface with MT or TypePad.  

Coded in C# it uses the 2.0 version of the .NET Framework and has been through four major revisions since 2003.

In the source you'll find:
- ExamplePlugIn - for SharpMT
- Mobile SharpMT
  - Phone SharpMT - the SmartPhone version (requires the SmartPhone 5.0 SDK or greater installed)
	  - Release - the released bits of 4.0 (used by the VSInstall project)
  - Pocket SharpMT - the Pocket PC version (requires the devices options from with VS 2005 or the PPC SDK)
    - Release - the released bits of 4.0 (used by the VSInstall project)
  - SPOpenFileDialog - used by Phone SharpMT, to make up for the lack of common dialogs
- SharpMT - the desktop version (requires .NET 2.0)
  - Help - the compiled chm and raw HTM files
  - Release - the released bits of 4.0 (used by the VSInstall project)
  - SharpMT - source code
- SharpMTPlugIn2 - the interface used by ExamplePlugIn
- VSInstall - VS-based installer bits
