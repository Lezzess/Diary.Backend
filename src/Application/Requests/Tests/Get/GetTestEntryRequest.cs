// This is an open source non-commercial project. Dear PVS-Studio, please check it.

// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using Core.Models;
using MediatR;

namespace Application.Requests.Tests.Get
{
    public class GetTestEntryRequest : IRequest<TestEntry>
    {
        public string PropertyOne { get; init; }
        public int? PropertyTwo { get; init; }
        public string PropertyThree { get; init; }
    }
}
