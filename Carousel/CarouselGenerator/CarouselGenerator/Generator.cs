// See https://aka.ms/new-console-template for more information
Console.WriteLine("************************");
Console.WriteLine("Welcome to the Carousel Template");
Console.WriteLine("You will be prompted for a folder location that contains the images to be displayed in the Carousel.");
Console.WriteLine("Please provide a location.");
Console.WriteLine("Please be aware, the images will be loaded into the Carousel in sorted order.");
Console.WriteLine("The easiest way to ensure you receive the desired order, is to number the images; 1-Castle, 2-Planets...");
Console.WriteLine("************************\n\n");

Console.Write("Please provide an image folder location: ");
var folder = Console.ReadLine();

// Make Sure there's a folder entered
if (folder == null || folder.Trim() == String.Empty)
{
    Console.WriteLine("No Folder entered. Program stopping, hit any key to continue.");
    Console.Read();
    return;
}
Console.WriteLine("\n\nYou have entered: "+ folder);

DirectoryInfo d = new DirectoryInfo(folder);
FileInfo[] Files = d.GetFiles("*.*"); 
int i = 0;
var lst = new List<string>();
foreach (FileInfo file in Files)
{
    lst.Add(file.Name.Trim());    
    i++;
}
Console.WriteLine("The directory contains {0} images", i);
Console.WriteLine("Sorting...");
lst.Sort();

var template = @"<div class='Containers'><img src='.\images\#imageName#' class='sliding' /></div>";

var html = string.Empty;
foreach (var item in lst)
{
    var t = template;
    html += t.Replace("#imageName#", item);
}

// Read in template.html
var temp = File.ReadAllText(@"..\..\..\Markup\template.html");

temp = temp.Replace("<!-- #images# -->", html);


// Create another index.html
using (StreamWriter sw = File.CreateText(@"..\..\..\Markup\index.html"))
{
    sw.WriteLine(temp);
}

// Package Output




Console.WriteLine("\n\nThank you, process is complete. Please hit any key.");
Console.Read();




