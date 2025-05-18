using FluentValidation;
using NzbDrone.Core.Annotations;
using NzbDrone.Core.Validation;

namespace NzbDrone.Core.Indexers.Spomix
{
    public class SpomixIndexerSettingsValidator : AbstractValidator<SpomixIndexerSettings>
    {
        public SpomixIndexerSettingsValidator()
        {
            RuleFor(c => c.BaseUrl).ValidRootUrl();
            RuleFor(c => c.Arl).NotEmpty().Length(192);
        }
    }

    public class SpomixIndexerSettings : IIndexerSettings
    {
        private static readonly SpomixIndexerSettingsValidator Validator = new SpomixIndexerSettingsValidator();

        public SpomixIndexerSettings()
        {
            BaseUrl = "http://localhost:6595";
        }

        [FieldDefinition(0, Label = "URL", HelpText = "The URL to your Spomix download client")]
        public string BaseUrl { get; set; }

        [FieldDefinition(1, Label = "Arl", Type = FieldType.Textbox)]
        public string Arl { get; set; }

        [FieldDefinition(2, Type = FieldType.Number, Label = "Early Download Limit", Unit = "days", HelpText = "Time before release date Lidarr will download from this indexer, empty is no limit", Advanced = true)]
        public int? EarlyReleaseLimit { get; set; }

        public NzbDroneValidationResult Validate()
        {
            return new NzbDroneValidationResult(Validator.Validate(this));
        }
    }
}
