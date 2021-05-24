// This is an open source non-commercial project. Dear PVS-Studio, please check it.

// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System.Threading;
using System.Threading.Tasks;
using Core.Models;
using Core.Services;
using MediatR;

namespace Application.Requests.Tests.Get
{
    internal class GetTestEntryRequestHandler : IRequestHandler<GetTestEntryRequest, TestEntry>
    {
        private readonly IValidator<TestEntry> _validator;

        public GetTestEntryRequestHandler(IValidator<TestEntry> validator)
        {
            _validator = validator;
        }

        public Task<TestEntry> Handle(GetTestEntryRequest request, CancellationToken cancellationToken)
        {
            _validator.Validate(request.PropertyOne, entry => entry.PropertyOne);
            _validator.Validate(request.PropertyTwo, entry => entry.PropertyTwo);
            _validator.Validate(request.PropertyThree, entry => entry.PropertyThree);

            return Task.FromResult(new TestEntry { PropertyOne = "1", PropertyTwo = 2, PropertyThree = "3" });
        }
    }
}
