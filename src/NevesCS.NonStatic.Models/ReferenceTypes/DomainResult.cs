using NevesCS.Abstractions.Traits;
using NevesCS.NonStatic.Models;

namespace NevesCS.NonStatic.ReferenceTypes
{
    public class DomainResult : IAuditableUtcCreation
    {
        public DateTimeOffset CreationUtcDateTime { get; } = DateTimeOffset.UtcNow;

        public ResultType Outcome { get; private set; } = ResultType.Success;

        public bool IsSuccess => Outcome is not ResultType.Failure;

        public bool IsFailure => Outcome is ResultType.Failure;

        public bool HasWarningMessages => WarningMessages.Count > 0;

        private List<string> WarningMessages { get; } = [];

        private List<string> ErrorMessages { get; } = [];

        public DomainResult SetOutcome(ResultType resultType)
        {
            if (resultType == ResultType.Failure)
            {
                Outcome = ResultType.Failure;

                return this;
            }

            if (Outcome is ResultType.Failure or ResultType.Warning)
            {
                return this;
            }

            Outcome = resultType;

            return this;
        }

        public IEnumerable<string> GetWarningMessages()
        {
            return WarningMessages;
        }

        public DomainResult AddWarningMessage(string message)
        {
            SetOutcome(ResultType.Warning);
            WarningMessages.Add(message);

            return this;
        }

        public DomainResult AddErrorMessage(string message)
        {
            SetOutcome(ResultType.Failure);
            ErrorMessages.Add(message);

            return this;
        }

        public DomainResult Combine(DomainResult result)
        {
            SetOutcome(result.Outcome);

            WarningMessages.AddRange(result.WarningMessages);
            ErrorMessages.AddRange(result.ErrorMessages);

            return this;
        }
    }
}
