﻿// This is an open source non-commercial project. Dear PVS-Studio, please check it.

// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

namespace Common.Services.Validation.Pairs
{
    internal interface IValidationPair
    {
        public ValidationResult Validate();
    }
}