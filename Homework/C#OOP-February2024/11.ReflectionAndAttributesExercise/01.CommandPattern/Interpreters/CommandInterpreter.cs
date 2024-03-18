﻿using CommandPattern.Core.Contracts;
using System;
using System.Linq;
using System.Reflection;

namespace CommandPattern.Interpreters
{
    public class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string args)
        {
            string[] parts = args
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string command = $"{parts[0]}Command";
            string[] commandArgs = parts.Skip(1).ToArray();

            Assembly assembly = Assembly.GetEntryAssembly();

            Type type = assembly.GetTypes().FirstOrDefault(t => t.Name == command);

            if (type == null)
            {
                throw new ArgumentException("Invalid type!");
            }

            ICommand instance = (ICommand)Activator.CreateInstance(type);

            return instance.Execute(commandArgs);
        }
    }
}
