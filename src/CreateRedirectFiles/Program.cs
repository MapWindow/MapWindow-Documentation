// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

// List all files in the directory:
// Process the list of files found in the directory.
string[] fileEntries = Directory.GetFiles(@"D:\dev\MapWindow\MapWindow-Documentation\MapWinGIS\output\html", "*.html");
foreach (string fileName in fileEntries)
{
    var baseName = Path.GetFileName(fileName);
    Console.WriteLine(baseName);
    var path = Path.Combine(@"D:\dev\MapWindow\MapWindow-Documentation\Website\documentation\mapwingis4.9", baseName);
    using StreamWriter sw = File.CreateText(path);
    sw.WriteLine("<!DOCTYPE HTML>");
    sw.WriteLine("<html lang=\"en\">");
    sw.WriteLine("    <head>");
    sw.WriteLine("        <meta charset=\"utf-8\">");
    sw.WriteLine("        <meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\">");
    sw.WriteLine($"        <meta http-equiv=\"refresh\" content=\"0; URL=https://www.mapwindow.org/mapwingis/{baseName}\" />");
    sw.WriteLine($"        <title>MapWinGIS 4.9 Documentation - {Path.GetFileNameWithoutExtension(baseName)}</title>");
    sw.WriteLine($"        <link rel=\"canonical\" href=\"https://www.mapwindow.org/mapwingis/{baseName}\" />");
    sw.WriteLine("    </head>");
    sw.WriteLine("    <body>");
    sw.WriteLine("        <h1>");
    sw.WriteLine($"            This page been moved to <a href=\"https://www.mapwindow.org/mapwingis/{baseName}\">www.mapwindow.org/mapwingis/{baseName}</a>");
    sw.WriteLine("        </h1>");
    sw.WriteLine("    </body>");
    sw.WriteLine("</html>");
}

