using System;
using DotNetTool.Labs;
using McMaster.Extensions.CommandLineUtils;

namespace DotNetTool;

class Program
{
    public static int Main(string[] args)
    {
        var app = new CommandLineApplication
        {
            Name = "Labworks",
            Description = "Lab 1-3",
        };

        app.HelpOption(inherited: true);
        app.Command("run", configCmd =>
        {
            configCmd.OnExecute(() =>
            {
                Console.WriteLine("Shoose number of lab");
                configCmd.ShowHelp();
                return 1;
            });

            // ./DotNetTool run lab1 -I "dataIn.txt" -O "dataOut.txt"
            configCmd.Command("lab1", setCmd =>
            {
                setCmd.Description = "Laboratory 1";
                var folder = GetDefaultFilePath();
                var input = setCmd.Option("-I|--input <INPUT>", "Input file path", CommandOptionType.SingleValue);
                var output = setCmd.Option("-O|--output <OUTPUT>", "Output file path", CommandOptionType.SingleValue);
                input.DefaultValue = $"{folder}/INPUT.txt";
                output.DefaultValue = $"{folder}/OUTPUT.txt";
                setCmd.OnExecute(() =>
                {
                    Console.WriteLine($"Set input file path: {input.Value()}");
                    Console.WriteLine($"Set output file path: {output.Value()}");
                    var app = new Lab1(input.Value(), output.Value());
                    app.Main();
                });
            });

            // ./DotNetTool run lab2 -I "dataIn.txt" -O "dataOut.txt"
            configCmd.Command("lab2", setCmd =>
            {
                setCmd.Description = "Laboratory 2";
                var folder = GetDefaultFilePath();
                var input = setCmd.Option("-I|--input <INPUT>", "Input file path", CommandOptionType.SingleValue);
                var output = setCmd.Option("-O|--output <OUTPUT>", "Output file path", CommandOptionType.SingleValue);
                input.DefaultValue = $"{folder}/INPUT.txt";
                output.DefaultValue = $"{folder}/OUTPUT.txt";
                setCmd.OnExecute(() =>
                {
                    Console.WriteLine($"Set input file path: {input.Value()}");
                    Console.WriteLine($"Set output file path: {output.Value()}");
                    var app = new Lab2(input.Value(), output.Value());
                    app.Main();
                });
            });

            // ./DotNetTool run lab3 -I "dataIn.txt" -O "dataOut.txt"
            configCmd.Command("lab3", setCmd =>
            {
                setCmd.Description = "Laboratory 3";
                var folder = GetDefaultFilePath();
                var input = setCmd.Option("-I|--input <INPUT>", "Input file path", CommandOptionType.SingleValue);
                var output = setCmd.Option("-O|--output <OUTPUT>", "Output file path", CommandOptionType.SingleValue);
                input.DefaultValue = $"{folder}/INPUT.txt";
                output.DefaultValue = $"{folder}/OUTPUT.txt";
                setCmd.OnExecute(() =>
                {
                    Console.WriteLine($"Input path: {input.Value()}");
                    Console.WriteLine($"Output path: {output.Value()}");
                    var app = new Lab3(input.Value(), output.Value());
                    app.Main();
                });
            });
        });

        app.Command("version", configCmd =>
        {
            configCmd.OnExecute(() =>
            {
                System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
                System.Diagnostics.FileVersionInfo fileVersionInfo = System.Diagnostics.FileVersionInfo.GetVersionInfo(assembly.Location);
                string version = fileVersionInfo.FileVersion;
                Console.WriteLine("App version: {0}", version);
            });
        });

        app.OnExecute(() =>
        {
            Console.WriteLine("Specify aplication:");
            app.ShowHelp();
            return 1;
        });

        return app.Execute(args);
    }

    private static string GetDefaultFilePath()
    {
        string path = Environment.GetEnvironmentVariable("LAB_PATH") ?? "";
        if (path.Length > 0) return path;
        else return Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
    }
}