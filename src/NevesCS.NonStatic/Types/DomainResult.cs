
using CSharpFunctionalExtensions;

using NevesCS.Static.Enums;

namespace NevesCS.NonStatic.Types
{
    public class DomainResult
    {
        public ResultType Outcome { get; private set; } = ResultType.Success;

        public bool IsSuccess => Outcome == ResultType.Success || Outcome == ResultType.Warning;

        public bool IsFailure => Outcome == ResultType.Failure;

        public bool HasWarningMessages => WarningMessages.Count > 0;

        private List<string> WarningMessages { get; } = new List<string>();

        private List<string> ErrorMessages { get; } = new List<string>();

        public DomainResult SetOutcome(ResultType resultType)
        {
            if (resultType == ResultType.Failure)
            {
                Outcome = ResultType.Failure;

                return this;
            }

            if (Outcome == ResultType.Failure || Outcome == ResultType.Warning)
            {
                return this;
            }

            Outcome = resultType;

            return this;
        }

        /// <summary>
        /// Concatenates all waring messages separated by a new line char.
        /// </summary>
        public string GetWarningsText()
        {
            return string.Join('\n', WarningMessages);
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

        /// <summary>
        /// Concatenates all error messages separated by a new line char.
        /// </summary>
        public string GetErrorsText()
        {
            return string.Join('\n', ErrorMessages);
        }

        public DomainResult AddErrorMessage(string message)
        {
            SetOutcome(ResultType.Failure);
            ErrorMessages.Add(message);

            return this;
        }

        public DomainResult Combine(Result result)
        {
            return result.Match(
                () =>
                {
                    SetOutcome(ResultType.Success);

                    return this;
                },
                (err) =>
                {
                    AddErrorMessage(err);

                    return this;
                });
        }

        public DomainResult Combine(DomainResult migrationResultDto)
        {
            SetOutcome(migrationResultDto.Outcome);

            if (migrationResultDto.WarningMessages.Count > 0)
            {
                WarningMessages.AddRange(migrationResultDto.WarningMessages);
            }

            if (migrationResultDto.ErrorMessages.Count > 0)
            {
                ErrorMessages.AddRange(migrationResultDto.ErrorMessages);
            }

            return this;
        }
    }
}
