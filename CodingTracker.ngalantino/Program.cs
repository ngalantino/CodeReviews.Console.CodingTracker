﻿using System.Configuration;
using System.Collections.Specialized;
using Microsoft.Data.Sqlite;
using Spectre.Console;
using System.Net;

public class Program()
{
    public static async Task Main(string[] args)
    {
        Menu menu = new Menu();

        menu.Display();     

    }
}

