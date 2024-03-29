﻿// This is an open source non-commercial project. Dear PVS-Studio, please check it.

// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Reflection;

namespace Core.Exceptions
{
    public class AssemblyResourceNotFoundException : Exception
    {
        public AssemblyResourceNotFoundException(Assembly assembly, string filePath)
            : base($"Requested resource {filePath} was not found in the assembly {assembly}")
        {

        }
    }
}
