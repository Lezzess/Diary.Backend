// This is an open source non-commercial project. Dear PVS-Studio, please check it.

// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using Core.Basis;

namespace Core.Exceptions
{
    public class ModelNotFoundException : Exception
    {
        protected ModelNotFoundException(string message)
            : base(message)
        {

        }
    }

    public class ModelNotFoundException<TModel> : ModelNotFoundException
        where TModel : AggregateRoot
    {
        public ModelNotFoundException()
            : base($"Requested model of type {typeof(TModel)} was not found in the database")
        {

        }
    }
}
