using System.Text.RegularExpressions;
using Fit.BusinessLogic;


//while (true)
//{
//    Console.WriteLine("Enter parcel dimensions, and widths of segments (separated by comma), x for exit:");
//    string? input = Console.ReadLine();
//    if (input == "x" || input == null)
//        break;
//    try
//    {
//        // remove whitespaces
//        input = Regex.Replace(input, @"\s+", "");

//        // split input string into parcel and pipe dimensions
//        List<int> dims = input.Split(',').Select(int.Parse).ToList();

//        Fitter f = new Fitter(dims[0], dims[1]);
//        List<int> pipeDims = dims.GetRange(2, dims.Count - 2);
//        if (f.fits(pipeDims))
//            Console.WriteLine("Fits!");
//        else Console.WriteLine("Does not fit.");
//    }
//    catch(FormatException)
//    {
//        Console.WriteLine("Invalid input.");
//    }
//    catch(Exception ex)
//    {
//        Console.WriteLine($"Exception:{ex.Message}");
//    }
//}
//Environment.Exit(0);


while (true)
{
    Console.WriteLine("Enter parcel dimensions, and widths of segments (separated by comma), x for exit:");
    string? input = Console.ReadLine();
    if (input == "x" || input == null)
        break;
    try
    {
        InputFormatter formatter = new InputFormatter(input);

        Fitter f = new Fitter(formatter.a, formatter.b);
        if (f.fits(formatter.pipeSegments))
            Console.WriteLine("Fits!");
        else Console.WriteLine("Does not fit.");
    }
    catch (FormatException fex)
    {
        if (fex.Message == "")
            Console.WriteLine("Invalid input.");
        else
            Console.WriteLine(fex.Message);
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Exception:{ex.Message}");
    }
}
Environment.Exit(0);